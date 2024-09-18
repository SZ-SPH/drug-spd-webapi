using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.Business;

//创建时间：2024-08-27
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 备货单
    /// </summary>
    [Verify]
    [Route("business/StockOrder")]
    public class StockOrderController : BaseController
    {
        /// <summary>
        /// 备货单接口
        /// </summary>
        private readonly IStockOrderService _StockOrderService;

        public StockOrderController(IStockOrderService StockOrderService)
        {
            _StockOrderService = StockOrderService;
        }

        /// <summary>
        /// 查询备货单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "stockorder:list")]
        public IActionResult QueryStockOrder([FromQuery] StockOrderQueryDto parm)
        {
            var response = _StockOrderService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询备货单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "stockorder:query")]
        public IActionResult GetStockOrder(int Id)
        {
            var response = _StockOrderService.GetInfo(Id);

            var info = response.Adapt<StockOrderDto>();
            return SUCCESS(info);
        }

        ///// <summary>
        ///// 添加备货单
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[ActionPermissionFilter(Permission = "stockorder:add")]
        //[Log(Title = "备货单", BusinessType = BusinessType.INSERT)]
        //public IActionResult AddStockOrder([FromBody]List<StockOrderDto> parmList)
        //{

        //    foreach (var parm in parmList)
        //    {
        //        var modal = parm.Adapt<StockOrder>().ToCreate(HttpContext);

        //        var response = _StockOrderService.AddStockOrder(modal);

        //        // You might want to handle the response for each item here
        //        // For example, you can aggregate the responses, return the last one, etc.
        //    }
        //    return SUCCESS("All items processed successfully.");
        //    //var modal = parm.Adapt<StockOrder>().ToCreate(HttpContext);

        //    //var response = _StockOrderService.AddStockOrder(modal);
        //    //return SUCCESS(response);
        //}

        [HttpPost]
        [ActionPermissionFilter(Permission = "stockorder:add")]
        [Log(Title = "备货单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddStockOrder([FromBody] StockOrderDto parm)
        {

                var modal = parm.Adapt<StockOrder>().ToCreate(HttpContext);

                var response = _StockOrderService.AddStockOrder(modal);         

                return SUCCESS(response);
        }

        /// <summary>
        /// 更新备货单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "stockorder:edit")]
        [Log(Title = "备货单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateStockOrder([FromBody] List<StockOrderDto> parmList)
        {
            foreach (var parm in parmList)
            {
                var modal = parm.Adapt<StockOrder>().ToUpdate(HttpContext);
                var response = _StockOrderService.UpdateStockOrder(modal);

                // You might want to handle the response for each item here
                // For example, you can aggregate the responses, return the last one, etc.
            }
            return SUCCESS("All items processed successfully.");
            //var modal = parm.Adapt<StockOrder>().ToUpdate(HttpContext);
            //var response = _StockOrderService.UpdateStockOrder(modal);

            //return ToResponse(response);
        }

        /// <summary>
        /// 删除备货单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "stockorder:delete")]
        [Log(Title = "备货单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteStockOrder([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_StockOrderService.Delete(idArr));
        }

        /// <summary>
        /// 导出备货单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "备货单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "stockorder:export")]
        public IActionResult Export([FromQuery] StockOrderQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _StockOrderService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "备货单", "备货单");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空备货单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "备货单", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "stockorder:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_StockOrderService.TruncateStockOrder());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "备货单导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "stockorder:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<StockOrderDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<StockOrderDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_StockOrderService.ImportStockOrder(list.Adapt<List<StockOrder>>()));
        }

        /// <summary>
        /// 备货单导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "备货单模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<StockOrderDto>() { }, "StockOrder");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}