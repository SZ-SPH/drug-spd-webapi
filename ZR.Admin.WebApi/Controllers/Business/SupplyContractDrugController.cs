using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-12-05
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 合同药品
    /// </summary>
    [Verify]
    [Route("business/SupplyContractDrug")]
    public class SupplyContractDrugController : BaseController
    {
        /// <summary>
        /// 合同药品接口
        /// </summary>
        private readonly ISupplyContractDrugService _SupplyContractDrugService;

        public SupplyContractDrugController(ISupplyContractDrugService SupplyContractDrugService)
        {
            _SupplyContractDrugService = SupplyContractDrugService;
        }

        /// <summary>
        /// 查询合同药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "supplycontractdrug:list")]
        public IActionResult QuerySupplyContractDrug([FromQuery] SupplyDrugQueryDto parm)
        {
            var response = _SupplyContractDrugService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询合同药品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "supplycontractdrug:query")]
        public IActionResult GetSupplyContractDrug(int Id)
        {
            var response = _SupplyContractDrugService.GetInfo(Id);
            
            var info = response.Adapt<SupplyContractDrugDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加合同药品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "supplycontractdrug:add")]
        [Log(Title = "合同药品", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSupplyContractDrug([FromBody] SupplyContractDrugDto parm)
        {
            var modal = parm.Adapt<SupplyContractDrug>().ToCreate(HttpContext);

            var response = _SupplyContractDrugService.AddSupplyContractDrug(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新合同药品
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "supplycontractdrug:edit")]
        [Log(Title = "合同药品", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSupplyContractDrug([FromBody] SupplyContractDrugDto parm)
        {
            var modal = parm.Adapt<SupplyContractDrug>().ToUpdate(HttpContext);
            var response = _SupplyContractDrugService.UpdateSupplyContractDrug(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除合同药品
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "supplycontractdrug:delete")]
        [Log(Title = "合同药品", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSupplyContractDrug([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_SupplyContractDrugService.Delete(idArr));
        }

        /// <summary>
        /// 导出合同药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "合同药品", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "supplycontractdrug:export")]
        public IActionResult Export([FromQuery] SupplyContractDrugQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SupplyContractDrugService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "合同药品", "合同药品");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空合同药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "合同药品", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "supplycontractdrug:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_SupplyContractDrugService.TruncateSupplyContractDrug());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "合同药品导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "supplycontractdrug:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SupplyContractDrugDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SupplyContractDrugDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SupplyContractDrugService.ImportSupplyContractDrug(list.Adapt<List<SupplyContractDrug>>()));
        }

        /// <summary>
        /// 合同药品导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "合同药品模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SupplyContractDrugDto>() { }, "SupplyContractDrug");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}