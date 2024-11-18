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

    [Route("His/HisSupplier")]
    public class HisSupplierController : BaseController
    {
        /// <summary>
        /// 药品基础资料管理接口
        /// </summary>
        private readonly IHisSupplierService _HisSupplierService;

        public HisSupplierController(IHisSupplierService HisSupplierService)
        {
            _HisSupplierService = HisSupplierService;
        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "drug:list")]
        public IActionResult QueryDrug([FromQuery] HisSupplierQueryDto parm)
        {
            var response = _HisSupplierService.GetList(parm);
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
            var response = _HisSupplierService.GetInfo(code);

            var info = response.Adapt<HisSupplierDto>();
            return SUCCESS(info);
        }


    }
}