using Microsoft.AspNetCore.Mvc;
using ZR.Model.His.Dto;
using ZR.Model.His;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.His;
using ZR.Service.His.IHisService;
using ZR.Service.Business.IBusinessService;
using SqlSugar;
using ZR.Model.Business;
using ZR.Service.Business;

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
        private readonly ISupplierService _SupplierService;


        public HisSupplierController(IHisSupplierService HisSupplierService,ISupplierService supplierService)
        {
            _HisSupplierService = HisSupplierService;
            _SupplierService = supplierService;
        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "Sup:list")]
        public IActionResult QuerySup([FromQuery] HisSupplierQueryDto parm)
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
        [ActionPermissionFilter(Permission = "Sup:query")]
        public IActionResult GetSup(string code)
        {
            var response = _HisSupplierService.GetInfo(code);

            var info = response.Adapt<HisSupplierDto>();
            return SUCCESS(info);
        }

        //同步
        [HttpGet("Tongbu")]
        public IActionResult TongBu()
        {
            var hisSup = _HisSupplierService.GetAll();
            var Sup = _SupplierService.GetAll();

            if (hisSup == null)
            {
                return BadRequest("历史仓库数据未找到。");
            }

            if (Sup == null)
            {
                Sup = new List<Supplier>();
            }

            foreach (var hisSupItem in hisSup)
            {
                var matchingSup = Sup.FirstOrDefault(t => t.SupplierName == hisSupItem.SUPPLIER_NAME);
                if (matchingSup != null)
                {
                    matchingSup.SupplierHisId = hisSupItem.ID;
                    matchingSup.SupplierName = hisSupItem.SUPPLIER_NAME;
                    matchingSup.EnterprisePhone = hisSupItem.PHONE;
                    matchingSup.EnterpriseAddress = hisSupItem.ADDRESS;
                    matchingSup.SocialCreditCode = hisSupItem.SOCIAL_CREDIT_CODE;
                    _SupplierService.UpdateSupplier(matchingSup);
                }
                else
                {
                    var newWarehouse = new Supplier
                    {                                       
                    SupplierHisId = hisSupItem.ID,
                    SupplierName = hisSupItem.SUPPLIER_NAME,
                    EnterprisePhone = hisSupItem.PHONE,
                    EnterpriseAddress = hisSupItem.ADDRESS,
                    SocialCreditCode = hisSupItem.SOCIAL_CREDIT_CODE
                };
                    _SupplierService.AddSupplier(newWarehouse);
                    // 这里不应该设置 Id
                }
            }

            return SUCCESS("");
        }

    }


}