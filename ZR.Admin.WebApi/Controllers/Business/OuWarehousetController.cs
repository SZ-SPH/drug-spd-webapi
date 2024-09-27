using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.Business;
using Microsoft.AspNetCore.Mvc.Formatters;
using Aliyun.OSS;
using SqlSugar;

//创建时间：2024-09-26
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 出库
    /// </summary>
    [Verify]
    [Route("business/OuWarehouset")]
    public class OuWarehousetController : BaseController
    {
        /// <summary>
        /// 出库接口
        /// </summary>
        private readonly IOuWarehousetService _OuWarehousetService;
        private readonly IApplicationPlanService _ApplicationPlanService;
        private readonly IStockService _StockService;



        public OuWarehousetController(IOuWarehousetService OuWarehousetService, IApplicationPlanService ApplicationPlanService
            , IStockService stockService)
        {
            _OuWarehousetService = OuWarehousetService;
            _ApplicationPlanService = ApplicationPlanService;
            _StockService = stockService;
        }

        /// <summary>
        /// 查询出库列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "ouwarehouset:list")]
        public IActionResult QueryOuWarehouset([FromQuery] OuWarehousetQueryDto parm)
        {
            var response = _OuWarehousetService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询出库详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "ouwarehouset:query")]
        public IActionResult GetOuWarehouset(int Id)
        {
            var response = _OuWarehousetService.GetInfo(Id);
            
            var info = response.Adapt<OuWarehousetDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加出库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "ouwarehouset:add")]
        [Log(Title = "出库", BusinessType = BusinessType.INSERT)]
        public IActionResult AddOuWarehouset([FromBody] OuWarehousetDto parm)
        {
            var modal = parm.Adapt<OuWarehouset>().ToCreate(HttpContext);

            var response = _OuWarehousetService.AddOuWarehouset(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新出库
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "ouwarehouset:edit")]
        [Log(Title = "出库", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateOuWarehouset([FromBody] OuWarehousetDto parm)
        {
            var modal = parm.Adapt<OuWarehouset>().ToUpdate(HttpContext);
            var response = _OuWarehousetService.UpdateOuWarehouset(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除出库
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "ouwarehouset:delete")]
        [Log(Title = "出库", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteOuWarehouset([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_OuWarehousetService.Delete(idArr, "删除出库"));
        }

        /// <summary>
        /// 导出出库
        /// </summary>
        /// <returns></returns>
        [Log(Title = "出库", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "ouwarehouset:export")]
        public IActionResult Export([FromQuery] OuWarehousetQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _OuWarehousetService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "出库", "出库");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空出库
        /// </summary>
        /// <returns></returns>
        [Log(Title = "出库", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "ouwarehouset:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_OuWarehousetService.TruncateOuWarehouset());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "出库导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "ouwarehouset:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<OuWarehousetDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<OuWarehousetDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_OuWarehousetService.ImportOuWarehouset(list.Adapt<List<OuWarehouset>>()));
        }

        /// <summary>
        /// 出库导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "出库模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<OuWarehousetDto>() { }, "OuWarehouset");
            return ExportExcel(result.Item2, result.Item1);
        }




        /// <summary>
        ///  
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        [HttpPost("stockAdd")]
        [ActionPermissionFilter(Permission = "stock:list")]
        public IActionResult ALLADDplanStock([FromBody] List<int> idlist)
        {
            //默认匹配药房
            var response = _ApplicationPlanService.AllGetInfo(idlist);

            foreach (var item in response) { 
            
                OuWarehousetDto ouWarehouset = new OuWarehousetDto();

                ouWarehouset.DrugId = item.DrugId;
                 var x= _StockService.SGetList((int)item.DrugId);
                ouWarehouset.OutWarehouseID =x.WarehouseID;
                ouWarehouset.InpharmacyId = item.PharmacyId;
                ouWarehouset.Qty = item.Qty;
                ouWarehouset.PharmacyId = item.Id;
                ouWarehouset.Times = DateTime.Now;
                var modal = ouWarehouset.Adapt<OuWarehouset>().ToCreate(HttpContext);
                var s = _OuWarehousetService.AddOuWarehouset(modal);
            }
            return SUCCESS(response);

        }
    }
}