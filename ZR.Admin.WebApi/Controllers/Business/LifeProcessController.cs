using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-08-27
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 生命周期
    /// </summary>
    [Verify]
    [Route("business/LifeProcess")]
    public class LifeProcessController : BaseController
    {
        /// <summary>
        /// 生命周期接口
        /// </summary>
        private readonly ILifeProcessService _LifeProcessService;

        public LifeProcessController(ILifeProcessService LifeProcessService)
        {
            _LifeProcessService = LifeProcessService;
        }

        /// <summary>
        /// 查询生命周期列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "lifeprocess:list")]
        public IActionResult QueryLifeProcess([FromQuery] LifeProcessQueryDto parm)
        {
            var response = _LifeProcessService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生命周期详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "lifeprocess:query")]
        public IActionResult GetLifeProcess(int Id)
        {
            var response = _LifeProcessService.GetInfo(Id);

            var info = response.Adapt<LifeProcessDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生命周期
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "lifeprocess:add")]
        [Log(Title = "生命周期", BusinessType = BusinessType.INSERT)]
        public IActionResult AddLifeProcess([FromBody] LifeProcessDto parm)
        {
            var modal = parm.Adapt<LifeProcess>().ToCreate(HttpContext);

            var response = _LifeProcessService.AddLifeProcess(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生命周期
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "lifeprocess:edit")]
        [Log(Title = "生命周期", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateLifeProcess([FromBody] LifeProcessDto parm)
        {
            var modal = parm.Adapt<LifeProcess>().ToUpdate(HttpContext);
            var response = _LifeProcessService.UpdateLifeProcess(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生命周期
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "lifeprocess:delete")]
        [Log(Title = "生命周期", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteLifeProcess([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_LifeProcessService.Delete(idArr));
        }

        /// <summary>
        /// 导出生命周期
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生命周期", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "lifeprocess:export")]
        public IActionResult Export([FromQuery] LifeProcessQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _LifeProcessService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生命周期", "生命周期");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空生命周期
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生命周期", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "lifeprocess:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_LifeProcessService.TruncateLifeProcess());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "生命周期导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "lifeprocess:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<LifeProcessDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<LifeProcessDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_LifeProcessService.ImportLifeProcess(list.Adapt<List<LifeProcess>>()));
        }

        /// <summary>
        /// 生命周期导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生命周期模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<LifeProcessDto>() { }, "LifeProcess");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}
