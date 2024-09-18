using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.Business;

//创建时间：2024-08-27
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 入库计划药品
    /// </summary>
    [Verify]
    [Route("business/InventoryPlanDrugs")]
    public class InventoryPlanDrugsController : BaseController
    {
        /// <summary>
        /// 入库计划药品接口
        /// </summary>
        private readonly IInventoryPlanDrugsService _InventoryPlanDrugsService;

        public InventoryPlanDrugsController(IInventoryPlanDrugsService InventoryPlanDrugsService)
        {
            _InventoryPlanDrugsService = InventoryPlanDrugsService;
        }

        /// <summary>
        /// 查询入库计划药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inventoryplandrugs:list")]
        public IActionResult QueryInventoryPlanDrugs([FromQuery] InventoryPlanDrugsQueryDto parm)
        {
            var response = _InventoryPlanDrugsService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询入库计划药品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "inventoryplandrugs:query")]
        public IActionResult GetInventoryPlanDrugs(int Id)
        {
            var response = _InventoryPlanDrugsService.GetInfo(Id);
            
            var info = response.Adapt<InventoryPlanDrugsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加入库计划药品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inventoryplandrugs:add")]
        [Log(Title = "入库计划药品", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInventoryPlanDrugs([FromBody]List<InventoryPlanDrugsDto> parmList)
        {
            //var modal = parm.Adapt<InventoryPlanDrugs>().ToCreate(HttpContext);

            //var response = _InventoryPlanDrugsService.AddInventoryPlanDrugs(modal);
            foreach (var parm in parmList)
            {
                var modal = parm.Adapt<InventoryPlanDrugs>().ToCreate(HttpContext);

                var response = _InventoryPlanDrugsService.AddInventoryPlanDrugs(modal);

            }
            return SUCCESS("All items processed successfully.");

        }

        /// <summary>
        /// 更新入库计划药品
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inventoryplandrugs:edit")]
        [Log(Title = "入库计划药品", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInventoryPlanDrugs([FromBody] InventoryPlanDrugsDto parm)
        {
            var modal = parm.Adapt<InventoryPlanDrugs>().ToUpdate(HttpContext);
            var response = _InventoryPlanDrugsService.UpdateInventoryPlanDrugs(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除入库计划药品
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inventoryplandrugs:delete")]
        [Log(Title = "入库计划药品", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInventoryPlanDrugs([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_InventoryPlanDrugsService.Delete(idArr));
        }

        /// <summary>
        /// 导出入库计划药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "入库计划药品", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inventoryplandrugs:export")]
        public IActionResult Export([FromQuery] InventoryPlanDrugsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InventoryPlanDrugsService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "入库计划药品", "入库计划药品");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空入库计划药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "入库计划药品", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "inventoryplandrugs:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_InventoryPlanDrugsService.TruncateInventoryPlanDrugs());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "入库计划药品导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "inventoryplandrugs:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<InventoryPlanDrugsDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<InventoryPlanDrugsDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_InventoryPlanDrugsService.ImportInventoryPlanDrugs(list.Adapt<List<InventoryPlanDrugs>>()));
        }

        /// <summary>
        /// 入库计划药品导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "入库计划药品模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<InventoryPlanDrugsDto>() { }, "InventoryPlanDrugs");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}