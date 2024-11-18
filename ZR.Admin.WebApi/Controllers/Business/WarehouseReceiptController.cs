using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using SqlSugar;
using ZR.Service.Business;
using Aliyun.OSS;
using System;
using Newtonsoft.Json;
using System.Text;

//创建时间：2024-08-28
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 入库单
    /// </summary>
    [Verify]
    [Route("business/WarehouseReceipt")]
    public class WarehouseReceiptController : BaseController
    {
        /// <summary>
        /// 入库单接口
        /// </summary>
        private readonly IInWarehousingService _InWarehousingService;
        private readonly IWarehouseReceiptService _WarehouseReceiptService;
        private readonly ICodeDetailsService _ICodeDetailsService;


        public WarehouseReceiptController(IWarehouseReceiptService WarehouseReceiptService
            ,IInWarehousingService InWarehousingService,ICodeDetailsService CodeDetailsService
            )
        {
            _WarehouseReceiptService = WarehouseReceiptService;
            _InWarehousingService = InWarehousingService;
            _ICodeDetailsService = CodeDetailsService;

        }

        /// <summary>
        /// 查询入库单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "warehousereceipt:list")]
        public IActionResult QueryWarehouseReceipt([FromQuery] WarehouseReceiptQueryDto parm)
        {
            var response = _WarehouseReceiptService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询入库单详情
        /// </summary>
        /// <param name="ReceiptId"></param>
        /// <returns></returns>
        [HttpGet("{ReceiptId}")]
        [ActionPermissionFilter(Permission = "warehousereceipt:query")]
        public IActionResult GetWarehouseReceipt(int ReceiptId)
        {
            var response = _WarehouseReceiptService.GetInfo(ReceiptId);

            var info = response.Adapt<WarehouseReceiptDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "warehousereceipt:add")]
        [Log(Title = "入库单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWarehouseReceipt([FromBody] WarehouseReceiptDto parm)
        {
            parm.ReceiptCode = GenerateInvoiceNumber();
            var modal = parm.Adapt<WarehouseReceipt>().ToCreate(HttpContext);

            var response = _WarehouseReceiptService.AddWarehouseReceipt(modal);

            return SUCCESS(response);
        }
        private static Dictionary<string, int> dailySequence = new Dictionary<string, int>();

        public  string GenerateInvoiceNumber()
        {
            // 获取当前日期，格式为 YYYYMMDD
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            var num = _WarehouseReceiptService.GetCode().Count;
            // 增加流水号
            // 获取当前日期的流水号
                        // 生成单据编号，格式为 YYYYMMDD-XXX
            string invoiceNumber = $"RKD{currentDate}{num++:D3}";
            return invoiceNumber;
        }



        /// <summary>
        /// 确认收货入库
        /// </summary>
        /// <returns></returns>
        [HttpPost("sendOutWarehouseReceipt")]
        [ActionPermissionFilter(Permission = "warehousereceipt:add")]
        [Log(Title = "入库单", BusinessType = BusinessType.INSERT)]
        public async Task<IActionResult> SendOutWarehouseReceiptAsync([FromBody] AllList parmlist)
        {
            List<WarehouseStorageRequest> requests = new List<WarehouseStorageRequest>();
            for (int i = 0; i < parmlist.ReceiptIds.Count; i++)
            {
                var storageDto = new WarehouseStorageRequest
                {
                    Warehouse_Code = parmlist.Warehousecode,
                    Org_Id = string.IsNullOrEmpty(parmlist.org_id) ? "RSS20171211000000001" : parmlist.org_id,
                    Med_List = new List<MedItem>()
                };

                // 查询入库单明细
                var response = _InWarehousingService.inGetList(parmlist.ReceiptIds[i]);
                foreach (var item in response)
                {
                    var medItem = new MedItem
                    {
                        Drug_Id = item.DrugId.ToString(),
                        Qty = item.InventoryQuantity.ToString(),
                        Batch_No = item.BatchNumber,
                        Indate = item.Exprie?.ToString(),
                        Prod_Date = item.DateOfManufacture?.ToString(),
                        Manufacturer_Id = item.ManufacturerId?.ToString(),
                        Price = item.Price?.ToString()
                    };

                    // 获取溯源码
                    var codes = await GetDrugTraceCodesAsync(item, parmlist.ReceiptIds[i]);
                    medItem.Drug_Trace_Code = string.Join(",", codes.Select(c => c.Code));
                    medItem.Approval_No = codes.LastOrDefault()?.ApprovalLicenceNo;

                    storageDto.Med_List.Add(medItem);
                }

                requests.Add(storageDto);
            }

            // 调用发送请求的方法
            string result = await SendRequestsAsync(requests);

            // 执行修改状态，成功的状态修改为已经推送
            return SUCCESS(result);
        }

        private async Task<List<CodeDetails>> GetDrugTraceCodesAsync(InWarehousing item, int receiptId)
        {
            var codeDetailsQuery = new CodeDetailsQueryDto
            {
                DrugId = item.DrugId,
                Receiptid = receiptId,
                InWarehouseId = item.Id
            };

            return  _ICodeDetailsService.AddGetList(codeDetailsQuery);
        }

        private async Task<string> SendRequestsAsync(List<WarehouseStorageRequest> requests)
        {
            using (var client = new HttpClient())
            {
                string url = "http://127.0.0.1:8080/xtHisService/xyxtSendAction!warehouseStorage.do";

                // 将 requests 转换为 JSON 字符串
                var json = JsonConvert.SerializeObject(requests);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // 处理错误
                    throw new Exception($"Error: {response.StatusCode}, Message: {response.ReasonPhrase}");
                }
            }
        }

        //public async Task<IActionResult> SendOutWarehouseReceiptAsync([FromBody] AllList parmlist)
        //{
        //    //从入库单中选出该入库单的药品 同时将该药的溯源码查询出来
        //    List<WarehouseStorageRequest> requests = new List<WarehouseStorageRequest>();
        //    for (int i = 0; i < parmlist.ReceiptIds.Count; i++)
        //    {
        //        WarehouseStorageRequest storageDto = new WarehouseStorageRequest();
        //        storageDto.Warehouse_Code = parmlist.Warehousecode;
        //        storageDto.Org_Id = parmlist.org_id;
        //        //查询 入库单明细
        //        var response = _InWarehousingService.inGetList(parmlist.ReceiptIds[i]);
        //        List<MedItem> items = new List<MedItem>();
        //        for (int j = 0; j < response.Count; j++)
        //        {
        //            MedItem medItem = new MedItem();
        //            medItem.Drug_Id = response[i].DrugId.ToString();
        //            medItem.Qty = response[i].InventoryQuantity.ToString();
        //            medItem.Batch_No = response[j].BatchNumber != null ? response[j].BatchNumber.ToString() : null;
        //            medItem.Indate = response[j].Exprie != null ? response[j].Exprie.ToString() : null;
        //            medItem.Prod_Date = response[j].DateOfManufacture != null ? response[j].DateOfManufacture.ToString() : null;
        //            medItem.Manufacturer_Id = response[j].ManufacturerId != null ? response[j].ManufacturerId.ToString() : null;
        //            medItem.Price = response[j].Price != null ? response[j].Price.ToString() : null;
        //            medItem.Drug_Trace_Code = response[j].ManufacturerId != null ? response[j].ManufacturerId.ToString() : null;
        //            CodeDetailsQueryDto codeDetailsQuery = new CodeDetailsQueryDto();
        //            codeDetailsQuery.DrugId = response[i].DrugId;
        //            codeDetailsQuery.Receiptid = parmlist.ReceiptIds[i];
        //            codeDetailsQuery.InWarehouseId = response[i].Id;
        //            var codes= _ICodeDetailsService.AddGetList(codeDetailsQuery);
        //            string appno = "";
        //            for (int k = 0; k < codes.Count; k++)
        //            {
        //                if (k==codes.Count-1)
        //                {
        //                    medItem.Drug_Trace_Code += codes[k].Code;
        //                    appno= codes[k].ApprovalLicenceNo;
        //                }
        //                else
        //                {
        //                    medItem.Drug_Trace_Code += codes[k].Code+",";
        //                }
        //            }



        //            medItem.Approval_No = appno;

        //            items.Add(medItem);
        //        }
        //        storageDto.Med_List = items;
        //        requests.Add(storageDto);                    
        //    }
        //    // 调用发送请求的方法
        //    string result = await SendRequestsAsync(requests);

        //    //执行修改状态 成功的状态修改为已经推送
        //    return SUCCESS("result");

        //}




        //private async Task<string> SendRequestsAsync(List<WarehouseStorageRequest> requests)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        // 设置请求的URL
        //        string url = "http://127.0.0.1:8080/xtHisService/xyxtSendAction!warehouseStorage.do";

        //        // 将 requests 转换为 JSON 字符串
        //        string json = JsonConvert.SerializeObject(requests); // 或者使用 System.Text.Json.JsonSerializer.Serialize(requests)

        //        // 创建 HttpContent
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        // 发送 POST 请求
        //        HttpResponseMessage response = await client.PostAsync(url, content);

        //        // 检查响应
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadAsStringAsync();
        //        }
        //        else
        //        {
        //            // 处理错误
        //            throw new Exception($"Error: {response.StatusCode}, Message: {response.ReasonPhrase}");
        //        }
        //    }
        //}
        /// <summary>
        /// 添加单
        /// </summary>
        /// <returns></returns>
        [HttpGet("DrugAdd/{StockId}")]
        //[ActionPermissionFilter(Permission = "warehousereceipt:add")]
        [Log(Title = "入库单", BusinessType = BusinessType.OTHER)]
        public IActionResult DrugAdd(int StockId)
        {
            List<SugarParameter> list = new List<SugarParameter>();
            list.Add(new SugarParameter("@stockid", StockId)); 
            _WarehouseReceiptService.AddReceiptdrug("InsertReceiptDrugData", list);
            return SUCCESS("true");
        }

        /// <summary>
        /// 更新入库单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "warehousereceipt:edit")]
        [Log(Title = "入库单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWarehouseReceipt([FromBody] WarehouseReceiptDto parm)
        {
            var modal = parm.Adapt<WarehouseReceipt>().ToUpdate(HttpContext);
            var response = _WarehouseReceiptService.UpdateWarehouseReceipt(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除入库单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "warehousereceipt:delete")]
        [Log(Title = "入库单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWarehouseReceipt([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_WarehouseReceiptService.Delete(idArr));
        }

        /// <summary>
        /// 导出入库单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "入库单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "warehousereceipt:export")]
        public IActionResult Export([FromQuery] WarehouseReceiptQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _WarehouseReceiptService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "入库单", "入库单");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空入库单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "入库单", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "warehousereceipt:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_WarehouseReceiptService.TruncateWarehouseReceipt());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "入库单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "warehousereceipt:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<WarehouseReceiptDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<WarehouseReceiptDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_WarehouseReceiptService.ImportWarehouseReceipt(list.Adapt<List<WarehouseReceipt>>()));
        }

        /// <summary>
        /// 入库单导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "入库单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<WarehouseReceiptDto>() { }, "WarehouseReceipt");
            return ExportExcel(result.Item2, result.Item1);
        }

    }


}