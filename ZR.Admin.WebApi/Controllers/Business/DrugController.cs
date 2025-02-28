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
    /// 药品基础资料管理
    /// </summary>
    [Verify]
    [Route("business/Drug")]
    public class DrugController : BaseController
    {
        /// <summary>
        /// 药品基础资料管理接口
        /// </summary>
        private readonly IDrugService _DrugService;

        public DrugController(IDrugService DrugService)
        {
            _DrugService = DrugService;
        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "drug:list")]
        public IActionResult QueryDrug([FromQuery] DrugQueryDto parm)
        {
          
            var response = _DrugService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 供应商查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("GYSlist")]
        [ActionPermissionFilter(Permission = "drug:list")]
        public IActionResult GYSQueryDrug([FromQuery] DrugQueryDto parm)
        {
            var response = _DrugService.GYSGetList(parm);
            return SUCCESS(response);
        }
        /// <summary>
        /// 查询药品基础资料管理详情
        /// </summary>
        /// <param name="DrugId"></param>
        /// <returns></returns>
        [HttpGet("{DrugId}")]
        [ActionPermissionFilter(Permission = "drug:query")]
        public IActionResult GetDrug(int DrugId)
        {
            var response = _DrugService.GetInfo(DrugId);

            var info = response.Adapt<DrugDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加药品基础资料管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "drug:add")]
        [Log(Title = "药品基础资料管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddDrug([FromBody] DrugDto parm)
        {
            var modal = parm.Adapt<Drug>().ToCreate(HttpContext);

            var response = _DrugService.AddDrug(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新药品基础资料管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "drug:edit")]
        [Log(Title = "药品基础资料管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateDrug([FromBody] DrugDto parm)
        {
            var modal = parm.Adapt<Drug>().ToUpdate(HttpContext);
            var response = _DrugService.UpdateDrug(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除药品基础资料管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "drug:delete")]
        [Log(Title = "药品基础资料管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteDrug([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_DrugService.Delete(idArr));
        }

        /// <summary>
        /// 导出药品基础资料管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "药品基础资料管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "drug:export")]
        public IActionResult Export([FromQuery] DrugQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _DrugService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "药品基础资料管理", "药品基础资料管理");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空药品基础资料管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "药品基础资料管理", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "drug:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_DrugService.TruncateDrug());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "药品基础资料管理导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "drug:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<DrugDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<DrugDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_DrugService.ImportDrug(list.Adapt<List<Drug>>()));
        }

        /// <summary>
        /// 药品基础资料管理导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "药品基础资料管理模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<DrugDto>() { }, "Drug");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}