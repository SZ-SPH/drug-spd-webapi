using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Model.System;
using ZR.Model;
using SqlSugar;
using MapsterMapper;
using System.Configuration;
using static ZR.Admin.WebApi.Controllers.Business.DeliveryOrderController;
using Aliyun.OSS;
using System;
using ZR.Service.Business;
using System.IO;

//创建时间：2024-12-03
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 送货单
    /// </summary>
    [Verify]
    [Route("business/DeliveryOrder")]
    public class DeliveryOrderController : BaseController
    {
        /// <summary>
        /// 送货单接口
        /// </summary>
        private readonly IDeliveryOrderService _DeliveryOrderService;
        private readonly IDeliveryOrderDrugService _DeliveryOrderDrugService;
        private readonly IGYSCodeDetailsService _GYSCodeDetailsService;

        private readonly IInWarehousingService _InWarehousingService;
        private readonly IWarehouseReceiptService _WarehouseReceiptService;
        private readonly ICodeDetailsService _CodeDetailsService;
        private readonly IManufacturerService _ManufacturerService;
      
        private readonly ISupplierService _SupplierService;

        private readonly ISysUserService _SysUserService;

        private readonly IDrugService _DrugService;


        public DeliveryOrderController(IDeliveryOrderService DeliveryOrderService, IInWarehousingService inWarehousingService, IWarehouseReceiptService WarehouseReceiptService
         , ICodeDetailsService codeDetailsService, IGYSCodeDetailsService gYSCodeDetailsService, IDeliveryOrderDrugService deliveryOrderDrugService, ISupplierService supplierService,
              ISysUserService sysUserService, IManufacturerService manufacturerService, IDrugService drugService)
        {

            _DeliveryOrderService = DeliveryOrderService;
            _DeliveryOrderDrugService = deliveryOrderDrugService;
            _GYSCodeDetailsService = gYSCodeDetailsService;
            _InWarehousingService = inWarehousingService;
            _WarehouseReceiptService = WarehouseReceiptService;
            _CodeDetailsService = codeDetailsService;
            _SupplierService = supplierService;
            _SysUserService = sysUserService;
            _ManufacturerService = manufacturerService;
            _DrugService = drugService;
        }

        /// <summary>
        /// 查询送货单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "deliveryorder:list")]
        public IActionResult QueryDeliveryOrder([FromQuery] DeliveryOrderQueryDto parm)
        {
            var response = _DeliveryOrderService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询送货单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "deliveryorder:query")]
        public IActionResult GetDeliveryOrder(int Id)
        {
            var response = _DeliveryOrderService.GetInfo(Id);

            var info = response.Adapt<DeliveryOrderDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加送货单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "deliveryorder:add")]
        [Log(Title = "送货单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddDeliveryOrder([FromBody] DeliveryOrderDto parm)
        {
            parm.PushTime = new DateTime(1900, 1, 1, 00, 00, 00);
            parm.BillCode = GenerateInvoiceNumbers();
            var modal = parm.Adapt<DeliveryOrder>().ToCreate(HttpContext);

            var response = _DeliveryOrderService.AddDeliveryOrder(modal);

            return SUCCESS(response);
        }
        public string GenerateInvoiceNumbers()
        {
            // 获取当前日期，格式为 YYYYMMDD
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            var num = _WarehouseReceiptService.GetCode().Count;
            // 增加流水号
            // 获取当前日期的流水号
            // 生成单据编号，格式为 YYYYMMDD-XXX
            string invoiceNumber = $"SHD{currentDate}{num++:D3}";
            return invoiceNumber;
        }
        /// <summary>
        /// 更新送货单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "deliveryorder:edit")]
        [Log(Title = "送货单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateDeliveryOrder([FromBody] DeliveryOrderDto parm)
        {
            var modal = parm.Adapt<DeliveryOrder>().ToUpdate(HttpContext);
            var response = _DeliveryOrderService.UpdateDeliveryOrder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除送货单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "deliveryorder:delete")]
        [Log(Title = "送货单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteDeliveryOrder([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_DeliveryOrderService.Delete(idArr));
        }

        /// <summary>
        /// 导出送货单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "deliveryorder:export")]
        public IActionResult Export([FromQuery] DeliveryOrderQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _DeliveryOrderService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "送货单", "送货单");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空送货单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "deliveryorder:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_DeliveryOrderService.TruncateDeliveryOrder());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "送货单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "deliveryorder:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<DeliveryOrderDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<DeliveryOrderDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_DeliveryOrderService.ImportDeliveryOrder(list.Adapt<List<DeliveryOrder>>()));
        }

        /// <summary>
        /// 送货单导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "送货单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<DeliveryOrderDto>() { }, "DeliveryOrder");
            return ExportExcel(result.Item2, result.Item1);
        }
        [HttpGet("ModeMa")]

        public IActionResult ModeMa([FromQuery] int parm)
        {
            //改为 获取到药品 id 
            var drug = _DrugService.GetInfo(parm);
            
            //string str = row.manufacturer;
            string[] parts = drug.ProduceName.Split(',');
            List<Manufacturer> response =new();
            foreach (var item in parts)
            {
                response.Add(_ManufacturerService.GetnNameInfo(item));
            }
            //_ManufacturerService.GetnNameInfo(parm);

            return SUCCESS(response);
        }

        /// <summary>
        /// 推送同步按钮 
        /// </summary>
        /// <returns></returns>
        [HttpPost("Tuisong")]
        public IActionResult Tuisong([FromBody]List<int> Deids)
        {
            var id = HttpContext.GetUId();
            SysUser user = _SysUserService.SelectUserById(id);
            //传递 入库单据信息 传递当前登录的 供应商
            foreach (var deid in Deids)
            {
                DeliveryOrder deliveryOrder = _DeliveryOrderService.GetInfo(deid);
                if (deliveryOrder.States == "已推送")
                {
                    continue;
                }
                List<DeliveryOrderDrug> deliveryOrderDrug = _DeliveryOrderDrugService.DrugGetList(deid);
                if (deliveryOrderDrug == null || deliveryOrderDrug.Count<=0)
                {
                    continue;
                }
                AllSupplierQueryDto supplierQueryDto = new AllSupplierQueryDto();
                supplierQueryDto.SupplierName = user.NickName;
                List<Supplier> supplier = _SupplierService.AllGetList(supplierQueryDto);
                //获取 药品信息  先创建 入库单据 -- 药品 -- 码 相关联
                WarehouseReceipt warehouseReceipt = new();
                warehouseReceipt.ReceiptCode = GenerateInvoiceNumber();
                warehouseReceipt.StorageTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                warehouseReceipt.ChangeTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                warehouseReceipt.CreationTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                warehouseReceipt.SupplierId = supplier[0].Id;
                warehouseReceipt.InvoiceNumber = deliveryOrder.InvoiceNo;
                warehouseReceipt.Creator = user.NickName;
                warehouseReceipt.ModifiedBy = user.NickName;
                warehouseReceipt.State = "未推送";
                warehouseReceipt.Mark = $"由{user.NickName}推送，送货单为{deliveryOrder.BillCode}";
                warehouseReceipt.Decode = deliveryOrder.BillCode;
                var modal = warehouseReceipt.Adapt<WarehouseReceipt>().ToCreate(HttpContext);
                var response = _WarehouseReceiptService.AddWarehouseReceipt(modal);

                foreach (var item in deliveryOrderDrug)
                {
                    InWarehousing inWarehousing = new InWarehousing();
                    inWarehousing.Id = item.Id;
                    inWarehousing.DrugId = (int)item.DrugId;
                    inWarehousing.DrugCode = item.DrugCode;
                    inWarehousing.BatchNumber = item.DrugBatchNo;
                    inWarehousing.InventoryQuantity = (int)item.DrugQuantity;
                    inWarehousing.DrugSpecifications = item.DrugSpecification;
                    inWarehousing.ReceiptId = response.ReceiptId;
                    inWarehousing.ManufacturerId = item.Manufacturer;
                    inWarehousing.Exprie = item.Exprie;
                    inWarehousing.Price = item.UnitPrice;
                    inWarehousing.DateOfManufacture = item.DateOfManufacture;
                    inWarehousing.Minunit = item.Minunit;
                    inWarehousing.PackageRatio = item.PackageRatio;
                    inWarehousing.PackageUnit = item.PackageUnit;                  

                    var Inmodal = inWarehousing.Adapt<InWarehousing>().ToCreate(HttpContext);
                    var Inresponse = _InWarehousingService.AddInWarehousing(Inmodal);
                    List<GYSCodeDetails> gYSCodeDetails = _GYSCodeDetailsService.CodeGetList(deliveryOrder.Id,item.Id);
                    if (gYSCodeDetails == null || gYSCodeDetails.Count <= 0) continue;
                    foreach (var gysitem in gYSCodeDetails)
                    {
                        CodeDetails codeDetails = Mapset(gysitem, Inresponse.Id, response.ReceiptId);
                        _CodeDetailsService.AddCodeDetails(codeDetails);
                    }

                }
                deliveryOrder.States = "已推送";
                deliveryOrder.PushTime = DateTime.Now;

                var des =deliveryOrder.Adapt<DeliveryOrder>().ToUpdate(HttpContext);
               _DeliveryOrderService.UpdateDeliveryOrder(des);
            }
            return SUCCESS("true");
        }

        private CodeDetails Mapset(GYSCodeDetails gYSCodeDetails, int InWarehouseId, int Receiptid)
        {
            var codeDetails = new CodeDetails
            {
                Receiptid= Receiptid,
                InWarehouseId = InWarehouseId // 设置 OutOrderId
            };

            var GYSCodeProperties = typeof(GYSCodeDetails).GetProperties();
            var codeDetailsProperties = typeof(CodeDetails).GetProperties();

            foreach (var phaOutProp in GYSCodeProperties)
            {
                // 查找与 PhaOut 属性同名的 OuWarehouset 属性
                var matchingProp = codeDetailsProperties.FirstOrDefault(p => p.Name == phaOutProp.Name);
                if (matchingProp != null && matchingProp.CanWrite)
                {
                    // 复制属性值
                    matchingProp.SetValue(codeDetails, phaOutProp.GetValue(gYSCodeDetails));
                }
            }
            return codeDetails;
        }
        public string GenerateInvoiceNumber()
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



        //传入 送货单id 通过 送货单 -- 获取药品 下载输出对应的文件 
        /// <summary>
        /// 导出送货单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("DemoExport")]
        [ActionPermissionFilter(Permission = "deliveryorder:export")]
        public IActionResult DemoExport([FromQuery] List<int> parm)
        {
            List<adds> adds = new List<adds>();
            List<demoExport> demoExports = new List<demoExport>();
            foreach (var item in parm)
            {
                adds adds1 = new adds();
                adds1.dd = new List<demoExport>();
               var p = _DeliveryOrderService.GetInfo(item);
               var n=_DeliveryOrderDrugService.DrugGetList(item);          
                foreach (var dr in n)
                {
                demoExport demo = new demoExport();
                demo.DeliveyId = item;
                demo.DeliveyBilltime = p.BillCode;
                demo.DeliveyDrugId= dr.Id;
                demo.DrugId = dr.DrugId;
                demo.DrugName = dr.DrugName;
                demo.DrugCode=dr.DrugCode;
                demo.GYSCode = "";
                demo.GYSCodeLever = "1";
                demoExports.Add(demo);
                adds1.dd.Add(demo);
                adds.Add(adds1);
                }
            }


      
            if (demoExports == null || demoExports.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var value = new
            {
                a = new[] {
                        demoExports,                     
                    }
            };

            var result = ExportExcelMinis(adds[0], "送货单模板.xlsx", "送货单模板");
            return ExportExcel(result.Item2, result.Item1);
        }
        public class adds
        {
            public List<demoExport> dd {get;set;}   
        }
    }
}