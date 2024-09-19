using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-09-14
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 医嘱
    /// </summary>
    [Verify]
    [Route("business/MedicalAdvice")]
    public class MedicalAdviceController : BaseController
    {
        /// <summary>
        /// 医嘱接口
        /// </summary>
        private readonly IMedicalAdviceService _MedicalAdviceService;

        public MedicalAdviceController(IMedicalAdviceService MedicalAdviceService)
        {
            _MedicalAdviceService = MedicalAdviceService;
        }

        /// <summary>
        /// 查询医嘱列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "medicaladvice:list")]
        public IActionResult QueryMedicalAdvice([FromQuery] MedicalAdviceQueryDto parm)
        {
            var response = _MedicalAdviceService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// PDA根据HIS医嘱查询医嘱列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("PDAList")]
        [ActionPermissionFilter(Permission = "medicaladvice:list")]
        public IActionResult PdaQueryMedicalAdviceByHisId([FromQuery] MedicalAdviceQueryDto parm)
        {
            var response = _MedicalAdviceService.PdaQueryMedicalAdviceByHisId(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询医嘱详情
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        [HttpGet("{OrderId}")]
        [ActionPermissionFilter(Permission = "medicaladvice:query")]
        public IActionResult GetMedicalAdvice(int OrderId)
        {
            var response = _MedicalAdviceService.GetInfo(OrderId);

            var info = response.Adapt<MedicalAdviceDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加医嘱
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "medicaladvice:add")]
        [Log(Title = "医嘱", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMedicalAdvice([FromBody] MedicalAdviceDto parm)
        {
            var modal = parm.Adapt<MedicalAdvice>().ToCreate(HttpContext);

            var response = _MedicalAdviceService.AddMedicalAdvice(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新医嘱
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "medicaladvice:edit")]
        [Log(Title = "医嘱", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMedicalAdvice([FromBody] MedicalAdviceDto parm)
        {
            var modal = parm.Adapt<MedicalAdvice>().ToUpdate(HttpContext);
            var response = _MedicalAdviceService.UpdateMedicalAdvice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除医嘱
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "medicaladvice:delete")]
        [Log(Title = "医嘱", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMedicalAdvice([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_MedicalAdviceService.Delete(idArr, "删除医嘱"));
        }

        /// <summary>
        /// 导出医嘱
        /// </summary>
        /// <returns></returns>
        [Log(Title = "医嘱", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "medicaladvice:export")]
        public IActionResult Export([FromQuery] MedicalAdviceQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MedicalAdviceService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "医嘱", "医嘱");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空医嘱
        /// </summary>
        /// <returns></returns>
        [Log(Title = "医嘱", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "medicaladvice:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_MedicalAdviceService.TruncateMedicalAdvice());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "医嘱导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "medicaladvice:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MedicalAdviceDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MedicalAdviceDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MedicalAdviceService.ImportMedicalAdvice(list.Adapt<List<MedicalAdvice>>()));
        }

        /// <summary>
        /// 医嘱导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "医嘱模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MedicalAdviceDto>() { }, "MedicalAdvice");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}