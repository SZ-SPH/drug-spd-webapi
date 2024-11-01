using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;

//创建时间：2024-10-30
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 盘点明细
    /// </summary>
    [Verify]
    [Route("business/StocktakingItem")]
    public class StocktakingItemController : BaseController
    {
        /// <summary>
        /// 盘点明细接口
        /// </summary>
        private readonly IStocktakingItemService _StocktakingItemService;

        public StocktakingItemController(IStocktakingItemService StocktakingItemService)
        {
            _StocktakingItemService = StocktakingItemService;
        }

        /// <summary>
        /// 查询盘点明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "stocktakingitem:list")]
        public IActionResult QueryStocktakingItem([FromQuery] StocktakingItemQueryDto parm)
        {
            var response = _StocktakingItemService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询盘点明细详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "stocktakingitem:query")]
        public IActionResult GetStocktakingItem(int Id)
        {
            var response = _StocktakingItemService.GetInfo(Id);
            
            var info = response.Adapt<StocktakingItemDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加盘点明细
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "stocktakingitem:add")]
        [Log(Title = "盘点明细", BusinessType = BusinessType.INSERT)]
        public IActionResult AddStocktakingItem([FromBody] StocktakingItemDto parm)
        {
            var modal = parm.Adapt<StocktakingItem>().ToCreate(HttpContext);

            var response = _StocktakingItemService.AddStocktakingItem(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新盘点明细
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "stocktakingitem:edit")]
        [Log(Title = "盘点明细", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateStocktakingItem([FromBody] StocktakingItemDto parm)
        {
            var modal = parm.Adapt<StocktakingItem>().ToUpdate(HttpContext);
            var response = _StocktakingItemService.UpdateStocktakingItem(modal);

            return ToResponse(response);
        }


        /// <summary>
        /// PDA更新盘点明细
        /// </summary>
        /// <returns></returns>
        [HttpPut("PDA")]
        [ActionPermissionFilter(Permission = "stocktakingitem:edit")]
        [Log(Title = "PDA更新盘点数量", BusinessType = BusinessType.UPDATE)]
        public IActionResult PdaUpdateStocktakingItem([FromBody] StocktakingItemDto parm)
        {
            parm.TracingCodePrefix = parm.TracingCode.Substring(0, 7);
            var modal = parm.Adapt<StocktakingItem>().ToUpdate(HttpContext);
            var response = _StocktakingItemService.PdaUpdateStocktakingItem(modal);
            return SUCCESS(response != 0 ? "更新成功" : "更新失败");
        }

        [HttpPut("manual")]
        [ActionPermissionFilter(Permission = "stocktakingitem:edit")]
        [Log(Title = "手动更新盘点数量", BusinessType = BusinessType.UPDATE)]
        public IActionResult ManualUpdateStocktakingItem([FromBody] StocktakingItemDto parm)
        {
            var modal = parm.Adapt<StocktakingItem>().ToUpdate(HttpContext);
            var response = _StocktakingItemService.UpdateStocktakingItem(modal);
            return SUCCESS(response != 0 ? "更新成功" : "更新失败");
        }

        /// <summary>
        /// 删除盘点明细
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "stocktakingitem:delete")]
        [Log(Title = "盘点明细", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteStocktakingItem([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_StocktakingItemService.Delete(idArr));
        }

    }
}