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

    [Route("His/HisMedical")]
    public class HisMedicalController : BaseController
    {
        /// <summary>
        /// 药品基础资料管理接口
        /// </summary>
        private readonly IHisMedicalService _HisMedicalService;
        private readonly IMedicalAdviceService _MedicalAdviceService;


        public HisMedicalController(IHisMedicalService HisMedicalService,IMedicalAdviceService medicalAdviceService)
        {
            _HisMedicalService = HisMedicalService;
            _MedicalAdviceService = medicalAdviceService;   
        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "Medical:list")]
        public IActionResult QueryMedical([FromQuery] HisMedicalQueryDto parm)
        {
            var response = _HisMedicalService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询药品基础资料管理详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ActionPermissionFilter(Permission = "Medical:query")]
        public IActionResult GetMedical(string code)
        {
            var response = _HisMedicalService.GetInfo(code);

            var info = response.Adapt<HisMedicalDto>();
            return SUCCESS(info);
        }
     
        //同步
        [HttpGet("Tongbu")]
        public IActionResult TongBu()
        {
            var hisMedical = _HisMedicalService.GetAll();
            var Medical = _MedicalAdviceService.GetAll();

            if (hisMedical == null)
            {
                return BadRequest("历史仓库数据未找到。");
            }

            if (Medical == null)
            {
                Medical = new List<MedicalAdvice>();
            }


            foreach (var hisMedicalItem in hisMedical)
            {
                // 查找 Medical 中是否存在对应的 Medicals_code
                var matchingMedical = Medical.FirstOrDefault(t => t.BillNum == hisMedicalItem.PH);
                if (matchingMedical != null)
                {
                    matchingMedical.PatientNumber = hisMedicalItem.BR_ID;
                    matchingMedical.IpiRegistrationId = hisMedicalItem.BR_HM;
                    matchingMedical.DrugId = hisMedicalItem.DRUG_ID;
                    matchingMedical.TotalQty = hisMedicalItem.Total_qty;
                    matchingMedical.OrderedDeptId = hisMedicalItem.ORDERED_DEPT_ID;
                    matchingMedical.EmployeeName = hisMedicalItem.EMPLOYEE_NAME;
                    matchingMedical.DepartmentChineseName = hisMedicalItem.DEPARTMENT_CHINESE_NAME;
                    matchingMedical.OrderedDoctorId = hisMedicalItem.ORDERED_DOCTOR_ID;
                    matchingMedical.FymxId = hisMedicalItem.FYMX_ID;
                    matchingMedical.TypeCode = hisMedicalItem.TYPE_CODE;
                    matchingMedical.BillNum = hisMedicalItem.PH;

                    _MedicalAdviceService.UpdateMedicalAdvice(matchingMedical);
                }
                else
                {
                    var newWarehouse = new MedicalAdvice
                    {
                     PatientNumber = hisMedicalItem.BR_ID,
                     IpiRegistrationId = hisMedicalItem.BR_HM,
                     DrugId = hisMedicalItem.DRUG_ID,
                     TotalQty = hisMedicalItem.Total_qty,
                     OrderedDeptId = hisMedicalItem.ORDERED_DEPT_ID,
                     EmployeeName = hisMedicalItem.EMPLOYEE_NAME,
                     DepartmentChineseName = hisMedicalItem.DEPARTMENT_CHINESE_NAME,
                     OrderedDoctorId = hisMedicalItem.ORDERED_DOCTOR_ID,
                     FymxId = hisMedicalItem.FYMX_ID,
                     TypeCode = hisMedicalItem.TYPE_CODE,
                     BillNum = hisMedicalItem.PH
                };
                    _MedicalAdviceService.AddMedicalAdvice(newWarehouse);
                    // 这里不应该设置 Id
                }
            }

            return SUCCESS("");
        }
    }
}