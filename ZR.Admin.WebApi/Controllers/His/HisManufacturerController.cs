using Microsoft.AspNetCore.Mvc;
using ZR.Model.His.Dto;
using ZR.Model.His;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.His;
using ZR.Service.His.IHisService;
using ZR.Service.Business.IBusinessService;
using ZR.Model.Business;
using ZR.Service.Business;

namespace ZR.Admin.WebApi.Controllers.His
{
    /// <summary>
    /// 药品基础资料管理
    /// </summary>
    [AllowAnonymous]

    [Route("His/HisManufacturer")]
    public class HisManufacturerController : BaseController
    {
        /// <summary>
        /// 药品基础资料管理接口
        /// </summary>
        private readonly IHisManufacturerService _HisManufacturerService;
        private readonly IManufacturerService _ManufacturerService;

        public HisManufacturerController(IHisManufacturerService HisManufacturerService,IManufacturerService manufacturerService)
        {
            _HisManufacturerService = HisManufacturerService;
            _ManufacturerService = manufacturerService;
        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "Manufacturer:list")]
        public IActionResult QueryManufacturer([FromQuery] HisManufacturerQueryDto parm)
        {
            var response = _HisManufacturerService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询药品基础资料管理详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ActionPermissionFilter(Permission = "Manufacturer:query")]
        public IActionResult GetManufacturer(string code)
        {
            var response = _HisManufacturerService.GetInfo(code);

            var info = response.Adapt<HisManufacturerDto>();
            return SUCCESS(info);
        }
      

        [HttpGet("Tongbu")]
        public IActionResult TongBu()
        {
            var hisManufacturer = _HisManufacturerService.GetAll();
            var Manufacturer = _ManufacturerService.GetAll();

            if (hisManufacturer == null)
            {
                return BadRequest("历史仓库数据未找到。");
            }

            if (Manufacturer == null)
            {
                Manufacturer = new List<Manufacturer>();
            }


            foreach (var hisManufacturerItem in hisManufacturer)
            {
                // 查找 Medical 中是否存在对应的 Medicals_code
                var matchingManufacturer = Manufacturer.FirstOrDefault(t => t.Code == hisManufacturerItem.MANUFACTURER_CODE);
                if (matchingManufacturer != null)
                {
                    matchingManufacturer.HisId = hisManufacturerItem.ID;
                    matchingManufacturer.Code = hisManufacturerItem.MANUFACTURER_CODE;
                    matchingManufacturer.Name = hisManufacturerItem.MANUFACTURER_NAME;

                    _ManufacturerService.UpdateManufacturer(matchingManufacturer);
                }
                else
                {
                    var newWarehouse = new Manufacturer
                    {
                       HisId = hisManufacturerItem.ID,
                   Code = hisManufacturerItem.MANUFACTURER_CODE,
                    Name = hisManufacturerItem.MANUFACTURER_NAME
                };
                    _ManufacturerService.AddManufacturer(newWarehouse);
                    // 这里不应该设置 Id
                }
            }

            return SUCCESS("");
        }
    }
}