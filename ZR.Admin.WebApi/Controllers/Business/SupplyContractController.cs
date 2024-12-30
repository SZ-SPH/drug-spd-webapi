using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using JinianNet.JNTemplate;

//创建时间：2024-12-05
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 合同
    /// </summary>
    [Verify]
    [Route("business/SupplyContract")]
    public class SupplyContractController : BaseController
    {
        /// <summary>
        /// 合同接口
        /// </summary>
        private readonly ISupplyContractService _SupplyContractService;
        private readonly ISupplyContractDrugService _SupplyContractDrugService;
        private readonly ISysUserService _SysUserService;


        public SupplyContractController(ISupplyContractService SupplyContractService,ISupplyContractDrugService SupplyContractDrugService,ISysUserService sysUserService)
        {
            _SupplyContractService = SupplyContractService;
            _SupplyContractDrugService = SupplyContractDrugService;       
            _SysUserService = sysUserService;
        }

        /// <summary>
        /// 查询合同列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "supplycontract:list")]
        public IActionResult QuerySupplyContract([FromQuery] SupplyContractQueryDto parm)
        {
            var response = _SupplyContractService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询合同详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "supplycontract:query")]
        public IActionResult GetSupplyContract(int Id)
        {
            var response = _SupplyContractService.GetInfo(Id);
            
            var info = response.Adapt<SupplyContractDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "supplycontract:add")]
        [Log(Title = "合同", BusinessType = BusinessType.INSERT)]
        public IActionResult AddSupplyContract([FromBody] SupplyContractDto parm)
        {
            var modal = parm.Adapt<SupplyContract>().ToCreate(HttpContext);

            var response = _SupplyContractService.AddSupplyContract(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新合同
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "supplycontract:edit")]
        [Log(Title = "合同", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateSupplyContract([FromBody] SupplyContractDto parm)
        {
            var modal = parm.Adapt<SupplyContract>().ToUpdate(HttpContext);
            var response = _SupplyContractService.UpdateSupplyContract(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "supplycontract:delete")]
        [Log(Title = "合同", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteSupplyContract([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_SupplyContractService.Delete(idArr));
        }

        /// <summary>
        /// 导出合同
        /// </summary>
        /// <returns></returns>
        [Log(Title = "合同", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "supplycontract:export")]
        public IActionResult Export([FromQuery] SupplyContractQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _SupplyContractService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "合同", "合同");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空合同
        /// </summary>
        /// <returns></returns>
        [Log(Title = "合同", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "supplycontract:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_SupplyContractService.TruncateSupplyContract());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        ///// <returns></returns>
        //[HttpPost("importData")]
        //[Log(Title = "合同导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        //[ActionPermissionFilter(Permission = "supplycontract:import")]
        //public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        //{
        //    List<SupplyContractDto> list = new();
        //    using (var stream = formFile.OpenReadStream())
        //    {
        //        list = stream.Query<SupplyContractDto>(startCell: "A1").ToList();
        //    }

        //    return SUCCESS(_SupplyContractService.ImportSupplyContract(list.Adapt<List<SupplyContract>>()));
        //}

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "合同导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "supplycontract:import")]
        public IActionResult importData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<SupladdDto> list = new();
            List<SupplyContractDto> listCon = new();
            List<SupplyContractDrugDto> listDrug = new();

            var userName = HttpContext.GetUId();
            var user=_SysUserService.SelectUserById(userName);
            
            //LoginUser info = Framework.JwtUtil.GetLoginUser(context.HttpContext);
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<SupladdDto>(startCell: "A1").ToList();
            }
        
            //读写出数据 将数据进行分割 第一条先查询是存在当前合同供应商 不存在则进行增加
            foreach (var supladd in list)
            {
                var trimmedSupplierName = supladd.SupplierName.Trim();
                var existingContract = listCon.FirstOrDefault(con => con.SupplierName.Equals(trimmedSupplierName, StringComparison.OrdinalIgnoreCase));
                if (existingContract != null)
                {
                    SupplyContractDrugDto supplyContractDrug = new SupplyContractDrugDto();
                    supplyContractDrug.DrugCode = supladd.DrugCode;
                    supplyContractDrug.States = "启用";
                    supplyContractDrug.ContractCode = existingContract.ContractCode;
                    listDrug.Add(supplyContractDrug);
                }
                else
                {
                    SupplyContractDto supladdDto = new SupplyContractDto();
                    supladdDto.ContractCode = GenerateContractCode();
                    supladdDto.ContractName = supladdDto.ContractCode;
                    supladdDto.SupplierName = supladd.SupplierName;
                    supladdDto.ContractType ="导入合同";
                    supladdDto.States = "启用";
                    supladdDto.CreatedAt = DateTime.Now;
                    supladdDto.ModifiedAt = DateTime.Now;
                    supladdDto.CreatedBy = user.NickName;
                    supladdDto.ModifiedBy = user.NickName;
                    supladdDto.StartDate = new DateTime(1900, 1, 1);
                    supladdDto.EndDate = new DateTime(2099, 1, 1);
                    listCon.Add(supladdDto);
                    SupplyContractDrugDto supplyContractDrug = new SupplyContractDrugDto();
                    supplyContractDrug.DrugCode = supladd.DrugCode;
                    supplyContractDrug.States = "启用";
                    supplyContractDrug.ContractCode = supladdDto.ContractCode;
                    listDrug.Add(supplyContractDrug);
                }
            }
            _SupplyContractService.ImportSupplyContract(listCon.Adapt<List<SupplyContract>>());
            _SupplyContractDrugService.ImportSupplyContractDrug(listDrug.Adapt<List<SupplyContractDrug>>());

            return SUCCESS("TT");
        }

        public static string GenerateContractCode()
        {
            // 获取当前日期和时间
            DateTime now = DateTime.Now;

            // 生成合同代码
            string contractCode = $"HT-{now:yyyyMMddHHmmss}-{Guid.NewGuid().ToString().Substring(0, 4)}";

            return contractCode;
        }

        /// <summary>
        /// 合同导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "合同模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<SupplyContractDto>() { }, "SupplyContract");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}