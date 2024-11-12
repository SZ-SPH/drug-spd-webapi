using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using SqlSugar.DistributedSystem.Snowflake;
using SqlSugar;

//创建时间：2024-10-30
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 盘点单
    /// </summary>
    [Verify]
    [Route("business/Stocktaking")]
    public class StocktakingController : BaseController
    {
        /// <summary>
        /// 盘点单接口
        /// </summary>
        private readonly IStocktakingService _StocktakingService;

        public StocktakingController(IStocktakingService StocktakingService)
        {
            _StocktakingService = StocktakingService;
        }

        /// <summary>
        /// 查询盘点单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "stocktaking:list")]
        public IActionResult QueryStocktaking([FromQuery] StocktakingQueryDto parm)
        {
            var response = _StocktakingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询盘点单详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "stocktaking:query")]
        public IActionResult GetStocktaking(int Id)
        {
            var response = _StocktakingService.GetInfo(Id);
            
            var info = response.Adapt<StocktakingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加盘点单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "stocktaking:add")]
        [Log(Title = "盘点单", BusinessType = BusinessType.INSERT)]
        public IActionResult AddStocktaking()
        {
            TokenModel user = JwtUtil.GetLoginUser(App.HttpContext);
            _StocktakingService.AddStocktakingNo(user);
            return SUCCESS("创建成功");
        }

        /// <summary>
        /// 更新盘点单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "stocktaking:edit")]
        [Log(Title = "盘点单", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateStocktaking([FromBody] StocktakingDto parm)
        {
            var modal = parm.Adapt<Stocktaking>().ToUpdate(HttpContext);
            var response = _StocktakingService.UpdateStocktaking(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除盘点单
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "stocktaking:delete")]
        [Log(Title = "盘点单", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteStocktaking([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_StocktakingService.Delete(idArr));
        }

        /// <summary>
        /// 导出盘点单
        /// </summary>
        /// <returns></returns>
        [Log(Title = "盘点单", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "stocktaking:export")]
        public IActionResult Export([FromQuery] StocktakingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _StocktakingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "盘点单", "盘点单");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}