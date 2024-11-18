using Microsoft.AspNetCore.Mvc;
using ZR.Model.His.Dto;
using ZR.Model.His;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.His;
using ZR.Service.His.IHisService;

namespace ZR.Admin.WebApi.Controllers.His
{
    /// <summary>
    /// 药品基础资料管理
    /// </summary>
    [AllowAnonymous]

    [Route("His/HisWarehouse")]
    public class HisWarehouseController : BaseController
    {
        /// <summary>
        /// 药品基础资料管理接口
        /// </summary>
        private readonly IHisWarehouseService _HisWarehouseService;

        public HisWarehouseController(IHisWarehouseService HisWarehouseService)
        {
            _HisWarehouseService = HisWarehouseService;
        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "drug:list")]
        public IActionResult QueryDrug([FromQuery] HisWarehouseQueryDto parm)
        {
            var response = _HisWarehouseService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询药品基础资料管理详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ActionPermissionFilter(Permission = "drug:query")]
        public IActionResult GetDrug(string code)
        {
            var response = _HisWarehouseService.GetInfo(code);

            var info = response.Adapt<HisWarehouseDto>();
            return SUCCESS(info);
        }


    }
}