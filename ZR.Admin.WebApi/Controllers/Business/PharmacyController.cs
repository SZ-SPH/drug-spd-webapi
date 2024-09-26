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
    /// 药房
    /// </summary>
    [Verify]
    [Route("business/Pharmacy")]
    public class PharmacyController : BaseController
    {
        /// <summary>
        /// 药房接口
        /// </summary>
        private readonly IPharmacyService _PharmacyService;

        public PharmacyController(IPharmacyService PharmacyService)
        {
            _PharmacyService = PharmacyService;
        }

        /// <summary>
        /// 查询药房列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "pharmacy:list")]
        public IActionResult QueryPharmacy([FromQuery] PharmacyQueryDto parm)
        {
            var response = _PharmacyService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询药房详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "pharmacy:query")]
        public IActionResult GetPharmacy(int Id)
        {
            var response = _PharmacyService.GetInfo(Id);
            
            var info = response.Adapt<PharmacyDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加药房
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "pharmacy:add")]
        [Log(Title = "药房", BusinessType = BusinessType.INSERT)]
        public IActionResult AddPharmacy([FromBody] PharmacyDto parm)
        {
            var modal = parm.Adapt<Pharmacy>().ToCreate(HttpContext);

            var response = _PharmacyService.AddPharmacy(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新药房
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "pharmacy:edit")]
        [Log(Title = "药房", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdatePharmacy([FromBody] PharmacyDto parm)
        {
            var modal = parm.Adapt<Pharmacy>().ToUpdate(HttpContext);
            var response = _PharmacyService.UpdatePharmacy(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除药房
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "pharmacy:delete")]
        [Log(Title = "药房", BusinessType = BusinessType.DELETE)]
        public IActionResult DeletePharmacy([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_PharmacyService.Delete(idArr, "删除药房"));
        }

        /// <summary>
        /// 导出药房
        /// </summary>
        /// <returns></returns>
        [Log(Title = "药房", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "pharmacy:export")]
        public IActionResult Export([FromQuery] PharmacyQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _PharmacyService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "药房", "药房");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空药房
        /// </summary>
        /// <returns></returns>
        [Log(Title = "药房", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "pharmacy:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_PharmacyService.TruncatePharmacy());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "药房导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "pharmacy:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<PharmacyDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<PharmacyDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_PharmacyService.ImportPharmacy(list.Adapt<List<Pharmacy>>()));
        }

        /// <summary>
        /// 药房导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "药房模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<PharmacyDto>() { }, "Pharmacy");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}