using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using SqlSugar;
using ZR.Service.Business;

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
        private readonly IWarehouseReceiptService _WarehouseReceiptService;

        public WarehouseReceiptController(IWarehouseReceiptService WarehouseReceiptService)
        {
            _WarehouseReceiptService = WarehouseReceiptService;
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

        public static string GenerateInvoiceNumber()
        {
            // 获取当前日期，格式为 YYYYMMDD
            string currentDate = DateTime.Now.ToString("yyyyMMdd");

            // 检查字典中是否存在当前日期的键，如果不存在则添加并初始化为 0
            if (!dailySequence.ContainsKey(currentDate))
            {
                dailySequence[currentDate] = 0;
            }

            // 增加流水号
            dailySequence[currentDate]++;

            // 获取当前日期的流水号
            int sequenceNumber = dailySequence[currentDate];

            // 生成单据编号，格式为 YYYYMMDD-XXX
            string invoiceNumber = $"RKD{currentDate}{sequenceNumber:D3}";

            return invoiceNumber;
        }







        /// <summary>
        /// 确认收货入库
        /// </summary>
        /// <returns></returns>
        [HttpPost("sendOutWarehouseReceipt")]
        [ActionPermissionFilter(Permission = "warehousereceipt:add")]
        [Log(Title = "入库单", BusinessType = BusinessType.INSERT)]
        public IActionResult SendOutWarehouseReceipt([FromBody]List<warehouseStorageDto> parmlist)
        { 
            var rids=new List<int>();
            var wids =new List<int>();
            //获取数据 进行循环选择
        //    foreach (var item in parmlist)
        //    {
        //       item.Warehouse_Code;
        //       item.Supplier_Id;
        //       item.ReceiptId;
        ////查询关于这个的id 的发药数
                   
        //    }
            //parm.Warehouse_Code = GenerateInvoiceNumber();
            //parm.Org_Id =;
            //parm.Supplier_Id =;
            //parm.Med_List[0].


           
            return SUCCESS("123");
        }






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