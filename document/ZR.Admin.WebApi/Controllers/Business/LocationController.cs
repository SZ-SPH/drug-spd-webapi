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
    /// 货位
    /// </summary>
    [Verify]
    [Route("business/Location")]
    public class LocationController : BaseController
    {
        /// <summary>
        /// 货位接口
        /// </summary>
        private readonly ILocationService _LocationService;

        public LocationController(ILocationService LocationService)
        {
            _LocationService = LocationService;
        }

        /// <summary>
        /// 查询货位列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "location:list")]
        public IActionResult QueryLocation([FromQuery] LocationQueryDto parm)
        {
            var response = _LocationService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询货位详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "location:query")]
        public IActionResult GetLocation(int Id)
        {
            var response = _LocationService.GetInfo(Id);
            
            var info = response.Adapt<LocationDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加货位
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "location:add")]
        [Log(Title = "货位", BusinessType = BusinessType.INSERT)]
        public IActionResult AddLocation([FromBody] LocationDto parm)
        {
            var modal = parm.Adapt<Location>().ToCreate(HttpContext);

            var response = _LocationService.AddLocation(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新货位
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "location:edit")]
        [Log(Title = "货位", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateLocation([FromBody] LocationDto parm)
        {
            var modal = parm.Adapt<Location>().ToUpdate(HttpContext);
            var response = _LocationService.UpdateLocation(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除货位
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "location:delete")]
        [Log(Title = "货位", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteLocation([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_LocationService.Delete(idArr, "删除货位"));
        }

        /// <summary>
        /// 导出货位
        /// </summary>
        /// <returns></returns>
        [Log(Title = "货位", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "location:export")]
        public IActionResult Export([FromQuery] LocationQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _LocationService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "货位", "货位");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空货位
        /// </summary>
        /// <returns></returns>
        [Log(Title = "货位", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "location:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_LocationService.TruncateLocation());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "货位导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "location:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<LocationDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<LocationDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_LocationService.ImportLocation(list.Adapt<List<Location>>()));
        }

        /// <summary>
        /// 货位导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "货位模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<LocationDto>() { }, "Location");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}