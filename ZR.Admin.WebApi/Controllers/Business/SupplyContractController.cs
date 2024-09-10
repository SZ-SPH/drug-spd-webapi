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
    /// 合同管理
    /// </summary>
    [Verify]
    [Route("business/SupplyContract")]
    public class SupplyContractController : BaseController
    {
        /// <summary>
        /// 合同管理接口
        /// </summary>
        private readonly ISupplyContractService _SupplyContractService;

        public SupplyContractController(ISupplyContractService SupplyContractService)
        {
            _SupplyContractService = SupplyContractService;
        }

        /// <summary>
        /// 查询合同管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "supplycontract:list")]
        public IActionResult QuerySupplyContract([FromQuery] SupplyContractQueryDto parm)
        {
            var response = _SupplyContractService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询合同管理详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "supplycontract:query")]
        public IActionResult GetSupplyContract(int Id)
        {
            var response = _SupplyContractService.GetInfo(Id);
            
            var info = response.Adapt<SupplyContractDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加合同管理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "supplycontract:add")]
        [Log(Title = "合同管理", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSupplyContract([FromBody] SupplyContractDto parm)
        {
            var modal = parm.Adapt<SupplyContract>().ToCreate(HttpContext);

            var response = _SupplyContractService.AddSupplyContract(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新合同管理
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "supplycontract:edit")]
        [Log(Title = "合同管理", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSupplyContract([FromBody] SupplyContractDto parm)
        {
            var modal = parm.Adapt<SupplyContract>().ToUpdate(HttpContext);
            var response = _SupplyContractService.UpdateSupplyContract(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除合同管理
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "supplycontract:delete")]
        [Log(Title = "合同管理", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSupplyContract([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_SupplyContractService.Delete(idArr));
        }

        /// <summary>
        /// 导出合同管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "合同管理", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "supplycontract:export")]
        public IActionResult Export([FromQuery] SupplyContractQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SupplyContractService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "合同管理", "合同管理");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空合同管理
        /// </summary>
        /// <returns></returns>
        [Log(Title = "合同管理", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "supplycontract:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_SupplyContractService.TruncateSupplyContract());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "合同管理导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "supplycontract:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SupplyContractDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SupplyContractDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_SupplyContractService.ImportSupplyContract(list.Adapt<List<SupplyContract>>()));
        }

        /// <summary>
        /// 合同管理导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "合同管理模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SupplyContractDto>() { }, "SupplyContract");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}