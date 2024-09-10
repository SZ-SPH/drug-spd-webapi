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
    /// 送货单
    /// </summary>
    [Verify]
    [Route("business/DeliveryOrder")]
    public class DeliveryOrderController : BaseController
    {
        /// <summary>
        /// 送货单接口
        /// </summary>
        private readonly IDeliveryOrderService _DeliveryOrderService;

        public DeliveryOrderController(IDeliveryOrderService DeliveryOrderService)
        {
            _DeliveryOrderService = DeliveryOrderService;
        }

        /// <summary>
        /// 查询送货单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "deliveryorder:list")]
        public IActionResult QueryDeliveryOrder([FromQuery] DeliveryOrderQueryDto parm)
        {
            var response = _DeliveryOrderService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询送货单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "deliveryorder:query")]
        public IActionResult GetDeliveryOrder(int Id)
        {
            var response = _DeliveryOrderService.GetInfo(Id);
            
            var info = response.Adapt<DeliveryOrderDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加送货单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "deliveryorder:add")]
        [Log(Title = "送货单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddDeliveryOrder([FromBody] DeliveryOrderDto parm)
        {
            var modal = parm.Adapt<DeliveryOrder>().ToCreate(HttpContext);

            var response = _DeliveryOrderService.AddDeliveryOrder(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新送货单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "deliveryorder:edit")]
        [Log(Title = "送货单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateDeliveryOrder([FromBody] DeliveryOrderDto parm)
        {
            var modal = parm.Adapt<DeliveryOrder>().ToUpdate(HttpContext);
            var response = _DeliveryOrderService.UpdateDeliveryOrder(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除送货单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "deliveryorder:delete")]
        [Log(Title = "送货单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteDeliveryOrder([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_DeliveryOrderService.Delete(idArr));
        }

        /// <summary>
        /// 导出送货单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "deliveryorder:export")]
        public IActionResult Export([FromQuery] DeliveryOrderQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _DeliveryOrderService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "送货单", "送货单");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空送货单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "deliveryorder:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_DeliveryOrderService.TruncateDeliveryOrder());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "送货单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "deliveryorder:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<DeliveryOrderDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<DeliveryOrderDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_DeliveryOrderService.ImportDeliveryOrder(list.Adapt<List<DeliveryOrder>>()));
        }

        /// <summary>
        /// 送货单导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "送货单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<DeliveryOrderDto>() { }, "DeliveryOrder");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}