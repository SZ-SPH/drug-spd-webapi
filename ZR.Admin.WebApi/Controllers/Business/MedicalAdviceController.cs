using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;

//创建时间：2024-06-25
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 医嘱基础信息
    /// </summary>
    [Verify]
    [Route("business/MedicalAdvice")]
    public class MedicalAdviceController : BaseController
    {
        /// <summary>
        /// 医嘱基础信息接口
        /// </summary>
        private readonly IMedicalAdviceService _MedicalAdviceService;

        public MedicalAdviceController(IMedicalAdviceService MedicalAdviceService)
        {
            _MedicalAdviceService = MedicalAdviceService;
        }

        /// <summary>
        /// 查询医嘱基础信息列表
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
        /// 查询医嘱基础信息详情
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
        /// 添加医嘱基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "medicaladvice:add")]
        [Log(Title = "医嘱基础信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMedicalAdvice([FromBody] MedicalAdviceDto parm)
        {
            var modal = parm.Adapt<MedicalAdvice>().ToCreate(HttpContext);

            var response = _MedicalAdviceService.AddMedicalAdvice(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新医嘱基础信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "medicaladvice:edit")]
        [Log(Title = "医嘱基础信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMedicalAdvice([FromBody] MedicalAdviceDto parm)
        {
            var modal = parm.Adapt<MedicalAdvice>().ToUpdate(HttpContext);
            var response = _MedicalAdviceService.UpdateMedicalAdvice(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除医嘱基础信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "medicaladvice:delete")]
        [Log(Title = "医嘱基础信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMedicalAdvice([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_MedicalAdviceService.Delete(idArr));
        }

        /// <summary>
        /// 导出医嘱基础信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "医嘱基础信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
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
            var result = ExportExcelMini(list, "医嘱基础信息", "医嘱基础信息");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}