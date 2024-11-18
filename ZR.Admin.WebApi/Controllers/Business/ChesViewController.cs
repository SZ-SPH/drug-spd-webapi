using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-08-06
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 码信息
    /// </summary>
    //[Verify]
    //[Route("[controller]/[action]")]
    [Route("business/ChesView")]
    [AllowAnonymous]
    public class ChesViewController : BaseController
    {
        /// <summary>
        /// 码信息接口
        /// </summary>
        private readonly IChesViewService _ChesViewService;

        public ChesViewController(IChesViewService ChesViewService)
        {
            _ChesViewService = ChesViewService;
        }

        /// <summary>
        /// 查询码信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "ChesView:list")]
        public IActionResult QueryChesView([FromQuery] ChesViewQueryDto parm)
        {
            var response = _ChesViewService.GetList(parm);
            var s = _ChesViewService.GetAll();

            return SUCCESS(response);
        }


        /// <summary>
        /// 查询码信息详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "ChesView:query")]
        public IActionResult GetChesView(int Id)
        {
            var response = _ChesViewService.GetInfo(Id);
            
            var info = response.Adapt<ChesViewDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加码信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "ChesView:add")]
        [Log(Title = "码信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddChesView([FromBody] ChesViewDto parm)
        {
            var modal = parm.Adapt<ChesView>().ToCreate(HttpContext);

            var response = _ChesViewService.AddChesView(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新码信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "ChesView:edit")]
        [Log(Title = "码信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateChesView([FromBody] ChesViewDto parm)
        {
            var modal = parm.Adapt<ChesView>().ToUpdate(HttpContext);
            var response = _ChesViewService.UpdateChesView(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除码信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "ChesView:delete")]
        [Log(Title = "码信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteChesView([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_ChesViewService.Delete(idArr));
        }

        /// <summary>
        /// 导出码信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "码信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "ChesView:export")]
        public IActionResult Export([FromQuery] ChesViewQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _ChesViewService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "码信息", "码信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空码信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "码信息", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "ChesView:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_ChesViewService.TruncateChesView());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "码信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "ChesView:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<ChesViewDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<ChesViewDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_ChesViewService.ImportChesView(list.Adapt<List<ChesView>>()));
        }

        /// <summary>
        /// 码信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "码信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<ChesViewDto>() { }, "ChesView");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}