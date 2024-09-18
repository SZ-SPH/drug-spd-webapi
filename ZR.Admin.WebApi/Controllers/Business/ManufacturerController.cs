using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-08-30
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 生产厂家
    /// </summary>
    [Verify]
    [Route("business/Manufacturer")]
    public class ManufacturerController : BaseController
    {
        /// <summary>
        /// 生产厂家接口
        /// </summary>
        private readonly IManufacturerService _ManufacturerService;

        public ManufacturerController(IManufacturerService ManufacturerService)
        {
            _ManufacturerService = ManufacturerService;
        }

        /// <summary>
        /// 查询生产厂家列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "manufacturer:list")]
        public IActionResult QueryManufacturer([FromQuery] ManufacturerQueryDto parm)
        {
            var response = _ManufacturerService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询生产厂家详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "manufacturer:query")]
        public IActionResult GetManufacturer(int Id)
        {
            var response = _ManufacturerService.GetInfo(Id);
            
            var info = response.Adapt<ManufacturerDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加生产厂家
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "manufacturer:add")]
        [Log(Title = "生产厂家", BusinessType = BusinessType.INSERT)]
        public IActionResult AddManufacturer([FromBody] ManufacturerDto parm)
        {
            var modal = parm.Adapt<Manufacturer>().ToCreate(HttpContext);

            var response = _ManufacturerService.AddManufacturer(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新生产厂家
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "manufacturer:edit")]
        [Log(Title = "生产厂家", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateManufacturer([FromBody] ManufacturerDto parm)
        {
            var modal = parm.Adapt<Manufacturer>().ToUpdate(HttpContext);
            var response = _ManufacturerService.UpdateManufacturer(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除生产厂家
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "manufacturer:delete")]
        [Log(Title = "生产厂家", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteManufacturer([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_ManufacturerService.Delete(idArr));
        }

        /// <summary>
        /// 导出生产厂家
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产厂家", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "manufacturer:export")]
        public IActionResult Export([FromQuery] ManufacturerQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _ManufacturerService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "生产厂家", "生产厂家");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空生产厂家
        /// </summary>
        /// <returns></returns>
        [Log(Title = "生产厂家", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "manufacturer:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_ManufacturerService.TruncateManufacturer());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "生产厂家导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "manufacturer:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<ManufacturerDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<ManufacturerDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_ManufacturerService.ImportManufacturer(list.Adapt<List<Manufacturer>>()));
        }

        /// <summary>
        /// 生产厂家导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "生产厂家模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<ManufacturerDto>() { }, "Manufacturer");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}