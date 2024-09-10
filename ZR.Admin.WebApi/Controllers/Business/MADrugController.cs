using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-08-28
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 医嘱药品
    /// </summary>
    [Verify]
    [Route("business/MADrug")]
    public class MADrugController : BaseController
    {
        /// <summary>
        /// 医嘱药品接口
        /// </summary>
        private readonly IMADrugService _MADrugService;

        public MADrugController(IMADrugService MADrugService)
        {
            _MADrugService = MADrugService;
        }

        /// <summary>
        /// 查询医嘱药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "madrug:list")]
        public IActionResult QueryMADrug([FromQuery] MADrugQueryDto parm)
        {
            var response = _MADrugService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询医嘱药品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "madrug:query")]
        public IActionResult GetMADrug(int Id)
        {
            var response = _MADrugService.GetInfo(Id);
            
            var info = response.Adapt<MADrugDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加医嘱药品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "madrug:add")]
        [Log(Title = "医嘱药品", BusinessType = BusinessType.INSERT)]
        public IActionResult AddMADrug([FromBody] MADrugDto parm)
        {
            var modal = parm.Adapt<MADrug>().ToCreate(HttpContext);

            var response = _MADrugService.AddMADrug(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新医嘱药品
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "madrug:edit")]
        [Log(Title = "医嘱药品", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateMADrug([FromBody] MADrugDto parm)
        {
            var modal = parm.Adapt<MADrug>().ToUpdate(HttpContext);
            var response = _MADrugService.UpdateMADrug(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除医嘱药品
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "madrug:delete")]
        [Log(Title = "医嘱药品", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteMADrug([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_MADrugService.Delete(idArr));
        }

        /// <summary>
        /// 导出医嘱药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "医嘱药品", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "madrug:export")]
        public IActionResult Export([FromQuery] MADrugQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _MADrugService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "医嘱药品", "医嘱药品");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空医嘱药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "医嘱药品", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "madrug:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_MADrugService.TruncateMADrug());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "医嘱药品导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "madrug:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<MADrugDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<MADrugDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_MADrugService.ImportMADrug(list.Adapt<List<MADrug>>()));
        }

        /// <summary>
        /// 医嘱药品导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "医嘱药品模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<MADrugDto>() { }, "MADrug");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}