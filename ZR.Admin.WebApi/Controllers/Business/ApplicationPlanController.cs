using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-09-26
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 申请计划
    /// </summary>
    [Verify]
    [Route("business/ApplicationPlan")]
    public class ApplicationPlanController : BaseController
    {
        /// <summary>
        /// 申请计划接口
        /// </summary>
        private readonly IApplicationPlanService _ApplicationPlanService;

        public ApplicationPlanController(IApplicationPlanService ApplicationPlanService)
        {
            _ApplicationPlanService = ApplicationPlanService;
        }

        /// <summary>
        /// 查询申请计划列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "applicationplan:list")]
        public IActionResult QueryApplicationPlan([FromQuery] ApplicationPlanQueryDto parm)
        {
            var response = _ApplicationPlanService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询申请计划详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "applicationplan:query")]
        public IActionResult GetApplicationPlan(int Id)
        {
            var response = _ApplicationPlanService.GetInfo(Id);
            
            var info = response.Adapt<ApplicationPlanDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加申请计划
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "applicationplan:add")]
        [Log(Title = "申请计划", BusinessType = BusinessType.INSERT)]
        public IActionResult AddApplicationPlan([FromBody] ApplicationPlanDto parm)
        {
            var modal = parm.Adapt<ApplicationPlan>().ToCreate(HttpContext);

            var response = _ApplicationPlanService.AddApplicationPlan(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新申请计划
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "applicationplan:edit")]
        [Log(Title = "申请计划", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateApplicationPlan([FromBody] ApplicationPlanDto parm)
        {
            var modal = parm.Adapt<ApplicationPlan>().ToUpdate(HttpContext);
            var response = _ApplicationPlanService.UpdateApplicationPlan(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除申请计划
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "applicationplan:delete")]
        [Log(Title = "申请计划", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteApplicationPlan([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_ApplicationPlanService.Delete(idArr, "删除申请计划"));
        }

        /// <summary>
        /// 导出申请计划
        /// </summary>
        /// <returns></returns>
        [Log(Title = "申请计划", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "applicationplan:export")]
        public IActionResult Export([FromQuery] ApplicationPlanQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _ApplicationPlanService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "申请计划", "申请计划");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空申请计划
        /// </summary>
        /// <returns></returns>
        [Log(Title = "申请计划", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "applicationplan:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_ApplicationPlanService.TruncateApplicationPlan());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "申请计划导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "applicationplan:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<ApplicationPlanDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<ApplicationPlanDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_ApplicationPlanService.ImportApplicationPlan(list.Adapt<List<ApplicationPlan>>()));
        }

        /// <summary>
        /// 申请计划导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "申请计划模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<ApplicationPlanDto>() { }, "ApplicationPlan");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}