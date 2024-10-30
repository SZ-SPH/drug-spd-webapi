using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-08-06
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 码信息
    /// </summary>
    [Verify]
    [Route("business/CodeDetails")]
    public class CodeDetailsController : BaseController
    {
        /// <summary>
        /// 码信息接口
        /// </summary>
        private readonly ICodeDetailsService _CodeDetailsService;
        private readonly IWarehouseReceiptService _WarehouseReceiptService;

        public CodeDetailsController(ICodeDetailsService CodeDetailsService, IWarehouseReceiptService WarehouseReceiptService)
        {
            _CodeDetailsService = CodeDetailsService;
            _WarehouseReceiptService = WarehouseReceiptService;

        }

        /// <summary>
        /// 查询码信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "codedetails:list")]
        public IActionResult QueryCodeDetails([FromQuery] CodeDetailsQueryDto parm)
        {
            var response = _CodeDetailsService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询医嘱已经绑定的药品信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("AdviceBindlist")]
        [ActionPermissionFilter(Permission = "codedetails:list")]
        public IActionResult QueryPdaAdviceBindCodeList([FromQuery] CodeDetailsQueryDto parm)
        {
            var response = _CodeDetailsService.QueryPdaAdviceBindCodeList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// PDA 绑定医嘱添加追溯码信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpPost("AddAdviceItem")]
        [ActionPermissionFilter(Permission = "codedetails:add")]
        [Log(Title = "码信息", BusinessType = BusinessType.INSERT)]
        public IActionResult PdaAdviceAddItem([FromBody] CodeDetailsQueryDto parm)
        {
            var response = _CodeDetailsService.PdaAdviceAddItem(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// PDA 删除跟追溯码的绑定关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAdviceItem/{id}")]
        [ActionPermissionFilter(Permission = "codedetails:delete")]
        [Log(Title = "码信息", BusinessType = BusinessType.DELETE)]
        public IActionResult PdaAdviceDeleteItem([FromRoute] string id)
        {
            var response = _CodeDetailsService.PdaAdviceDeleteItem(id);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询码信息详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "codedetails:query")]
        public IActionResult GetCodeDetails(int Id)
        {
            var response = _CodeDetailsService.GetInfo(Id);
            
            var info = response.Adapt<CodeDetailsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加码信息
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[ActionPermissionFilter(Permission = "codedetails:add")]
        //[Log(Title = "码信息", BusinessType = BusinessType.INSERT)]
        //public IActionResult AddCodeDetails([FromBody] CodeDetailsDto parm)
        //{
        //    var modal = parm.Adapt<CodeDetails>().ToCreate(HttpContext);

        //    var response = _CodeDetailsService.AddCodeDetails(modal);

        //    return SUCCESS(response);
        //}
        /// <summary>
        /// 添加码信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "codedetails:add")]
        [Log(Title = "码信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddCodeDetails([FromBody]List<CodeDetailsDto> parm,string ids)
        {
            foreach (var item in parm)
            {
                var modal = item.Adapt<CodeDetails>().ToCreate(HttpContext);
                modal.InvoiceCode = _WarehouseReceiptService.GetInfo(int.Parse(ids)).InvoiceNumber;
                //var info = response.Adapt<WarehouseReceiptDto>();

                var response = _CodeDetailsService.AddCodeDetails(modal);
            }
            //var modal = parm.Adapt<CodeDetails>().ToCreate(HttpContext);

            //var response = _CodeDetailsService.AddCodeDetails(modal);

            return SUCCESS("true");
        }


        /// <summary>
        /// 更新码信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "codedetails:edit")]
        [Log(Title = "码信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateCodeDetails([FromBody] CodeDetailsDto parm)
        {
            var modal = parm.Adapt<CodeDetails>().ToUpdate(HttpContext);
            var response = _CodeDetailsService.UpdateCodeDetails(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除码信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "codedetails:delete")]
        [Log(Title = "码信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteCodeDetails([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_CodeDetailsService.Delete(idArr));
        }

        /// <summary>
        /// 导出码信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "码信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "codedetails:export")]
        public IActionResult Export([FromQuery] CodeDetailsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _CodeDetailsService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "码信息", "码信息");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空码信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "码信息", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "codedetails:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_CodeDetailsService.TruncateCodeDetails());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "码信息导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "codedetails:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<CodeDetailsDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<CodeDetailsDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_CodeDetailsService.ImportCodeDetails(list.Adapt<List<CodeDetails>>()));
        }

        /// <summary>
        /// 码信息导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "码信息模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<CodeDetailsDto>() { }, "CodeDetails");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}