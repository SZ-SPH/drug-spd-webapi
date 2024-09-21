using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using Aliyun.OSS;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using Microsoft.Extensions.Logging;
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 入库信息
    /// </summary>
    [Verify]
    [Route("business/InWarehousing")]
    public class InWarehousingController : BaseController
    {
        /// <summary>
        /// 入库信息接口
        /// </summary>
        private readonly IInWarehousingService _InWarehousingService;

        private readonly IWarehouseReceiptService _WarehouseReceiptService;

        private readonly ICodeDetailsService _CodeDetailsService;

        private readonly IDrugService _DrugService;

        public InWarehousingController(
            IInWarehousingService InWarehousingService,
            IWarehouseReceiptService WarehouseReceiptService,
            ICodeDetailsService CodeDetailsService,
            IDrugService DrugService
            )
        {
            _InWarehousingService = InWarehousingService;
            _WarehouseReceiptService = WarehouseReceiptService;
            _CodeDetailsService = CodeDetailsService;
            _DrugService = DrugService;
        }

        /// <summary>
        /// 查询入库信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "inwarehousing:list")]
        public IActionResult QueryInWarehousing([FromQuery] InWarehousingQueryDto parm)
        {
            var response = _InWarehousingService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询入库信息详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "inwarehousing:query")]
        public IActionResult GetInWarehousing(int Id)
        {
            var response = _InWarehousingService.GetInfo(Id);

            var info = response.Adapt<InWarehousingDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加入库信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "inwarehousing:add")]
        [Log(Title = "入库信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInWarehousing([FromBody] List<InWarehousingDto> parmList)
        {
    
            foreach (var parm in parmList)
            {
                var modal = parm.Adapt<InWarehousing>().ToCreate(HttpContext);

                var response = _InWarehousingService.AddInWarehousing(modal);

            }

     
            return SUCCESS("All items processed successfully.");
        }


        /// <summary>
        /// PDA 添加入库信息
        /// </summary>
        /// <param name="parmList"></param>
        /// <returns></returns>
        [HttpPost("PDA")]
        [ActionPermissionFilter(Permission = "inwarehousing:add")]
        [Log(Title = "入库信息PDA", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInWarehousingWithPda([FromBody] InWarehousingPdaDto parmList)
        {
            var inWarehousing = parmList.Adapt<InWarehousing>().ToCreate(HttpContext);
            var modal = parmList.Adapt<InWarehousingPdaDto>().ToCreate(HttpContext);
            Drug drug = _DrugService.GetListWithCondition(parmList);
            //先通过名字模糊查询出单个药品，回填id和code，从而达到添加明细入库
            inWarehousing.DrugId = drug.DrugId;
            inWarehousing.DrugCode = drug.DrugCode;
            inWarehousing.DrugSpecifications = drug.DrugSpecifications;
            inWarehousing.InventoryQuantity = 1;
            var WarehousingResponse = _InWarehousingService.AddInWarehousingWithCondition(inWarehousing);
            //明细入库之后需要添加溯源码这些属性，在这拿到返回的drugid,id,ReceiptId组装参数
            CodeDetails codeDetails = new CodeDetails()
            {
                Receiptid = int.Parse(modal.ReceiptId),
                DrugId = WarehousingResponse.DrugId,
                InWarehouseId = WarehousingResponse.Id,
                Code = parmList.TracingSourceCode,
                PhysicTypeDesc = parmList.DrugCategory,
                RefEntId = parmList.ProduceId,
                EntName = parmList.ProduceName,
                PackageLevel = parmList.DrugClassification == "1" ? "小码" : parmList.DrugClassification == "2" ? "中码" : parmList.DrugClassification == "3" ? "大码" : parmList.DrugClassification,
                PhysicName = parmList.DrugName,
                Exprie = parmList.Expire,
                ExpireDate = parmList.ExpireDate,
                DrugEntBaseInfoId = inWarehousing.DrugId.ToString(),
                ApprovalLicenceNo = parmList.ApprovalLicenceNo,
                PkgSpecCrit = parmList.PackageUnit,
                PrepnSpec = parmList.PrepnSpec,
                PrepnTypeDesc = parmList.PrepnTypeDesc,
                ProduceDateStr = parmList.ProduceDateStr,
                PkgAmount = parmList.PkgAmount,
                BatchNo = parmList.DrugBatchNumber
            };
            var response = _CodeDetailsService.AddCodeDetails(codeDetails);

            return SUCCESS("处理成功");
        }


        /// <summary>
        /// 更新入库信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inwarehousing:edit")]
        [Log(Title = "入库信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInWarehousing([FromBody] InWarehousingDto parm)
        {
            var modal = parm.Adapt<InWarehousing>().ToUpdate(HttpContext);
            var response = _InWarehousingService.UpdateInWarehousing(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除入库信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inwarehousing:delete")]
        [Log(Title = "入库信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInWarehousing([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_InWarehousingService.Delete(idArr));
        }

        /// <summary>
        /// 导出入库信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "入库信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inwarehousing:export")]
        public IActionResult Export([FromQuery] InWarehousingQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InWarehousingService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "入库信息", "入库信息");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}