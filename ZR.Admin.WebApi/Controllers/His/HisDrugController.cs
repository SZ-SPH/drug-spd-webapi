using Microsoft.AspNetCore.Mvc;
using ZR.Model.His.Dto;
using ZR.Model.His;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.His;
using ZR.Service.His.IHisService;
using ZR.Service.Business.IBusinessService;
using SqlSugar;
using ZR.Service.Business;
using ZR.Model.Business;

namespace ZR.Admin.WebApi.Controllers.His
{
    /// <summary>
    /// 药品基础资料管理
    /// </summary>
    [AllowAnonymous]

    [Route("His/HisDrug")]
    public class HisDrugController : BaseController
    {
        /// <summary>
        /// 药品基础资料管理接口
        /// </summary>
        private readonly IHisDrugService _HisDrugService;
        private readonly IDrugService _DrugService;


        public HisDrugController(IHisDrugService HisDrugService,IDrugService drugService)
        {
            _HisDrugService = HisDrugService;
            _DrugService = drugService;

        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "drug:list")]
        public IActionResult QueryDrug([FromQuery] HisDrugQueryDto parm)
        {
            var response = _HisDrugService.GetAll();
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
            var response = _HisDrugService.GetInfo(code);

            var info = response.Adapt<HisDrugDto>();
            return SUCCESS(info);
        }

        [HttpGet("Tongbu")]
        public IActionResult TongBu()
        {
            var hisdrug = _HisDrugService.GetAll();
            var drug = _DrugService.GetAll();

            if (hisdrug == null)
            {
                return BadRequest("历史数据未找到。");
            }
            if (drug == null)
            {
                drug = new List<Drug>();
            }
            foreach (var hisDrugItem in hisdrug)
            {
                // 查找 drug 中是否存在对应的 drugs_code
                var matchingDrug = drug.FirstOrDefault(t => t.DrugCode == hisDrugItem.drugs_code);
                if (matchingDrug != null)
                {
                    matchingDrug.HisID = hisDrugItem.iD;
                    matchingDrug.DrugCode = hisDrugItem.drugs_code;
                    matchingDrug.DrugName = hisDrugItem.drugs_name;
                    matchingDrug.DrugMnemonicCode = hisDrugItem.short_name;
                    matchingDrug.DrugSpecifications = hisDrugItem.drugs_specs;
                    matchingDrug.Minunit = hisDrugItem.unit;
                    matchingDrug.PackageUnit = hisDrugItem.package_unit;
                    matchingDrug.PackageRatio = hisDrugItem.package_ratio;
                    matchingDrug.DrugCategory = hisDrugItem.drugs_type;
                    matchingDrug.DrugClassification = hisDrugItem.drugs_flag;
                    matchingDrug.ProduceName = hisDrugItem.produce_name;
                    matchingDrug.HisPrice = hisDrugItem.PURCH_PRICE != null ? decimal.Parse(hisDrugItem.PURCH_PRICE) : 0;
                    matchingDrug.KfEnable = hisDrugItem.KFYX;
                    matchingDrug.YfEnable = hisDrugItem.YFYX;
                    matchingDrug.ZCZH = hisDrugItem.ZCZH;
                    
                    _DrugService.UpdateDrug(matchingDrug);
                }
                else
                {
                    var newWarehouse = new Drug
                    {
                    HisID = hisDrugItem.iD,
                    DrugCode = hisDrugItem.drugs_code,
                    DrugName = hisDrugItem.drugs_name,
                    DrugMnemonicCode = hisDrugItem.short_name,
                    DrugSpecifications = hisDrugItem.drugs_specs,
                    Minunit = hisDrugItem.unit,
                    PackageUnit = hisDrugItem.package_unit,
                    PackageRatio = hisDrugItem.package_ratio,
                    DrugCategory = hisDrugItem.drugs_type,
                    DrugClassification = hisDrugItem.drugs_flag,
                    ProduceName = hisDrugItem.produce_name,
                    HisPrice = hisDrugItem.PURCH_PRICE != null ? decimal.Parse(hisDrugItem.PURCH_PRICE) : 0,
                    KfEnable = hisDrugItem.KFYX,
                    YfEnable = hisDrugItem.YFYX,
                        ZCZH = hisDrugItem.ZCZH
                    };
                _DrugService.AddDrug(newWarehouse);
              
                }
            }

            return SUCCESS("true");
        }
    }
}