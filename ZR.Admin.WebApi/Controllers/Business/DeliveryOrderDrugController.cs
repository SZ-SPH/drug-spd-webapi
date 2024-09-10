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
    /// 送货单药品
    /// </summary>
    [Verify]
    [Route("business/DeliveryOrderDrug")]
    public class DeliveryOrderDrugController : BaseController
    {
        /// <summary>
        /// 送货单药品接口
        /// </summary>
        private readonly IDeliveryOrderDrugService _DeliveryOrderDrugService;

        public DeliveryOrderDrugController(IDeliveryOrderDrugService DeliveryOrderDrugService)
        {
            _DeliveryOrderDrugService = DeliveryOrderDrugService;
        }

        /// <summary>
        /// 查询送货单药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "deliveryorderdrug:list")]
        public IActionResult QueryDeliveryOrderDrug([FromQuery] DeliveryOrderDrugQueryDto parm)
        {
            var response = _DeliveryOrderDrugService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询送货单药品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "deliveryorderdrug:query")]
        public IActionResult GetDeliveryOrderDrug(int Id)
        {
            var response = _DeliveryOrderDrugService.GetInfo(Id);
            
            var info = response.Adapt<DeliveryOrderDrugDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加送货单药品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "deliveryorderdrug:add")]
        [Log(Title = "送货单药品", BusinessType = BusinessType.INSERT)]
        public IActionResult AddDeliveryOrderDrug([FromBody] DeliveryOrderDrugDto parm)
        {
            var modal = parm.Adapt<DeliveryOrderDrug>().ToCreate(HttpContext);

            var response = _DeliveryOrderDrugService.AddDeliveryOrderDrug(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新送货单药品
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "deliveryorderdrug:edit")]
        [Log(Title = "送货单药品", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateDeliveryOrderDrug([FromBody] DeliveryOrderDrugDto parm)
        {
            var modal = parm.Adapt<DeliveryOrderDrug>().ToUpdate(HttpContext);
            var response = _DeliveryOrderDrugService.UpdateDeliveryOrderDrug(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除送货单药品
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "deliveryorderdrug:delete")]
        [Log(Title = "送货单药品", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteDeliveryOrderDrug([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_DeliveryOrderDrugService.Delete(idArr));
        }

        /// <summary>
        /// 导出送货单药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单药品", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "deliveryorderdrug:export")]
        public IActionResult Export([FromQuery] DeliveryOrderDrugQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _DeliveryOrderDrugService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "送货单药品", "送货单药品");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空送货单药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单药品", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "deliveryorderdrug:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_DeliveryOrderDrugService.TruncateDeliveryOrderDrug());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "送货单药品导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "deliveryorderdrug:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<DeliveryOrderDrugDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<DeliveryOrderDrugDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_DeliveryOrderDrugService.ImportDeliveryOrderDrug(list.Adapt<List<DeliveryOrderDrug>>()));
        }

        /// <summary>
        /// 送货单药品导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "送货单药品模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<DeliveryOrderDrugDto>() { }, "DeliveryOrderDrug");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}