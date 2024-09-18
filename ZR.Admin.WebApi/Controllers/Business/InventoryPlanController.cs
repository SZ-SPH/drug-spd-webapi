using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.Business;
using Aliyun.OSS;
using SqlSugar;

//创建时间：2024-08-27
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 入库计划
    /// </summary>
    [Verify]
    [Route("business/InventoryPlan")]
    public class InventoryPlanController : BaseController
    {
        /// <summary>
        /// 入库计划接口
        /// </summary>
        private readonly IInventoryPlanService _InventoryPlanService;
        private readonly IStockOrderService _StockOrderService;



        public InventoryPlanController(IInventoryPlanService InventoryPlanService, IStockOrderService StockOrderService)
        {
            _InventoryPlanService = InventoryPlanService;
            _StockOrderService = StockOrderService;
        }
        /// <summary>
        /// 查询入库计划列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inventoryplan:list")]
        public IActionResult QueryInventoryPlan([FromQuery] InventoryPlanQueryDto parm)
        {
            var response = _InventoryPlanService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询入库计划详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "inventoryplan:query")]
        public IActionResult GetInventoryPlan(int Id)
        {
            var response = _InventoryPlanService.GetInfo(Id);
            
            var info = response.Adapt<InventoryPlanDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加入库计划
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inventoryplan:add")]
        [Log(Title = "入库计划", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInventoryPlan([FromBody] InventoryPlanDto parm)
        {
            var modal = parm.Adapt<InventoryPlan>().ToCreate(HttpContext);

            var response = _InventoryPlanService.AddInventoryPlan(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新入库计划
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inventoryplan:edit")]
        [Log(Title = "入库计划", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInventoryPlan([FromBody] List<InventoryPlanDto> parmList)
        {  
            foreach (var parm in parmList)
            {
                var modal = parm.Adapt<InventoryPlan>().ToCreate(HttpContext);
                var response = _InventoryPlanService.UpdateInventoryPlan(modal);                               
            }
            //if (parmList[0].States== "已发送")
            //{
            //    foreach (var item in parmList)
            //    {
            //        StockOrderDto stockOrderDto = new StockOrderDto();                 
            //        stockOrderDto.ReceiptId = item.Id;
            //        stockOrderDto.DrugId = 0;
            //        stockOrderDto.DeliveryQuantity = 0;
            //        stockOrderDto.DeliveryHospital = "";
            //        stockOrderDto.DeliveryAddress ="";
            //        stockOrderDto.Remarks = item.Remarks;
            //        stockOrderDto.DeliveryTime = "";
            //        stockOrderDto.DeliveryPerson = "";
            //        var modal = stockOrderDto.Adapt<StockOrder>().ToCreate(HttpContext);
            //        var response = _StockOrderService.AddStockOrder(modal);
            //        List<SugarParameter> list = new List<SugarParameter>();
            //        //list.Add(new SugarParameter("@planid", 参数值1));
            //        list.Add(new SugarParameter("@planid", item.Id));
            //        _InventoryPlanService.AddStockProc("InsertDrugData",list);

            //    }            
            //}
         
        
            return SUCCESS("All items processed successfully.");

            //return ToResponse(response);
        }

        /// <summary>
        /// 删除入库计划
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inventoryplan:delete")]
        [Log(Title = "入库计划", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInventoryPlan([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_InventoryPlanService.Delete(idArr));
        }

        /// <summary>
        /// 导出入库计划
        /// </summary>
        /// <returns></returns>
        [Log(Title = "入库计划", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inventoryplan:export")]
        public IActionResult Export([FromQuery] InventoryPlanQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InventoryPlanService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "入库计划", "入库计划");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空入库计划
        /// </summary>
        /// <returns></returns>
        [Log(Title = "入库计划", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "inventoryplan:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_InventoryPlanService.TruncateInventoryPlan());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "入库计划导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inventoryplan:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<InventoryPlanDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InventoryPlanDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InventoryPlanService.ImportInventoryPlan(list.Adapt<List<InventoryPlan>>()));
        }

        /// <summary>
        /// 入库计划导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "入库计划模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InventoryPlanDto>() { }, "InventoryPlan");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}