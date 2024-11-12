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
    /// 供应商基础功能
    /// </summary>
    [Verify]
    [Route("business/Supplier")]
    public class SupplierController : BaseController
    {
        /// <summary>
        /// 供应商基础功能接口
        /// </summary>
        private readonly ISupplierService _SupplierService;

        public SupplierController(ISupplierService SupplierService)
        {
            _SupplierService = SupplierService;
        }

        /// <summary>
        /// 查询供应商基础功能列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "supplier:list")]
        public IActionResult QuerySupplier([FromQuery] SupplierQueryDto parm)
        {
            var response = _SupplierService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询供应商基础功能列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("AllList")]
        [ActionPermissionFilter(Permission = "supplier:list")]
        public IActionResult AllQuerySupplier([FromQuery] AllSupplierQueryDto parm)
        {
            var response = _SupplierService.AllGetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询供应商基础功能详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "supplier:query")]
        public IActionResult GetSupplier(int Id)
        {
            var response = _SupplierService.GetInfo(Id);

            var info = response.Adapt<SupplierDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加供应商基础功能
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "supplier:add")]
        [Log(Title = "供应商基础功能", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSupplier([FromBody] SupplierDto parm)
        {
            var modal = parm.Adapt<Supplier>().ToCreate(HttpContext);

            var response = _SupplierService.AddSupplier(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新供应商基础功能
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "supplier:edit")]
        [Log(Title = "供应商基础功能", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSupplier([FromBody] SupplierDto parm)
        {
            var modal = parm.Adapt<Supplier>().ToUpdate(HttpContext);
            var response = _SupplierService.UpdateSupplier(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除供应商基础功能
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "supplier:delete")]
        [Log(Title = "供应商基础功能", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSupplier([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_SupplierService.Delete(idArr));
        }

        /// <summary>
        /// 导出供应商基础功能
        /// </summary>
        /// <returns></returns>
        [Log(Title = "供应商基础功能", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "supplier:export")]
        public IActionResult Export([FromQuery] SupplierQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SupplierService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "供应商基础功能", "供应商基础功能");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空供应商基础功能
        /// </summary>
        /// <returns></returns>
        [Log(Title = "供应商基础功能", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "supplier:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_SupplierService.TruncateSupplier());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "供应商基础功能导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "supplier:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SupplierDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SupplierDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SupplierService.ImportSupplier(list.Adapt<List<Supplier>>()));
        }

        /// <summary>
        /// 供应商基础功能导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "供应商基础功能模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SupplierDto>() { }, "Supplier");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}