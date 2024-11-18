using Microsoft.AspNetCore.Mvc;
using ZR.Model.His.Dto;
using ZR.Model.His;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.His;
using ZR.Service.His.IHisService;
using ZR.Service.Business.IBusinessService;
using ZR.Model.Business;

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
        private readonly IWarehouseService _WarehouseService;


        public HisWarehouseController(IHisWarehouseService HisWarehouseService,IWarehouseService warehouseService)
        {
            _HisWarehouseService = HisWarehouseService;
            _WarehouseService = warehouseService;
        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "ware:list")]
        public IActionResult Queryware([FromQuery] HisWarehouseQueryDto parm)
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
        [ActionPermissionFilter(Permission = "ware:query")]
        public IActionResult Getware(string code)
        {
            var response = _HisWarehouseService.GetInfo(code);

            var info = response.Adapt<HisWarehouseDto>();
            return SUCCESS(info);
        }

        //同步
        [HttpGet("Tongbu")]
        public IActionResult TongBu()
        {
            var hisware = _HisWarehouseService.GetAll();
            var ware = _WarehouseService.GetAll();

            if (hisware == null)
            {
                return BadRequest("历史仓库数据未找到。");
            }

            if (ware == null)
            {
                ware = new List<Warehouse>();
            }

            foreach (var hiswareItem in hisware)
            {
                var matchingware = ware.FirstOrDefault(t => t.Code == hiswareItem.WAREHOUSE_CODE);

                if (matchingware != null)
                {
                    matchingware.Name = hiswareItem.WAREHOUSE_CNAME;
                    _WarehouseService.UpdateWarehouse(matchingware);
                }
                else
                {
                    var newWarehouse = new Warehouse
                    {
                        // 确保不设置 Id 属性
                        Code = hiswareItem.WAREHOUSE_CODE,
                        Name = hiswareItem.WAREHOUSE_CNAME
                    };
                    _WarehouseService.AddWarehouse(newWarehouse); // 这里不应该设置 Id
                }
            }

            return SUCCESS("");
        }
    }
}