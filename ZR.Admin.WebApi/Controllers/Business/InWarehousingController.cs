using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using Aliyun.OSS;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using Microsoft.Extensions.Logging;
using ZR.Service.Business;
using Org.BouncyCastle.Bcpg;
using Infrastructure;
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

        private readonly ILifeProcessService _LifeProcessService;

        private readonly IStockService _StockService;

        public InWarehousingController(
            IInWarehousingService InWarehousingService,
            IWarehouseReceiptService WarehouseReceiptService,
            ICodeDetailsService CodeDetailsService,
            IDrugService DrugService,
            ILifeProcessService LifeProcessService,
            IStockService StockService
            )
        {
            _InWarehousingService = InWarehousingService;
            _WarehouseReceiptService = WarehouseReceiptService;
            _CodeDetailsService = CodeDetailsService;
            _DrugService = DrugService;
            _LifeProcessService = LifeProcessService;
            _StockService = StockService;
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
                //// 添加完成后 加入库存表 先判断是否存在（药品id批号 等等） 若存在 则添加数量 不存在则新增 
                //var stock = _StockService.InGetInfo((int)response.DrugId, response.BatchNumber);
                //if (stock != null && stock.Id > 0)
                //{
                //    stock.InventoryQuantity += response.InventoryQuantity;
                //    //修改
                //    _StockService.UpdateStock(stock);
                //}
                //else if (stock == null)
                //{
                //    //新增
                //    Stock item = new Stock
                //    {
                //        DrugId = parm.DrugId,
                //        Drugqty = 0,
                //        PurchasePrice = (decimal)(parm.Price == null ? 0 : parm.Price),
                //        RetailPrice = 0,
                //        InventoryQuantity = parm.InventoryQuantity,
                //        DeQuantity = 0,
                //        ActualStock = parm.InventoryQuantity,
                //        SUnit = parm.Minunit,
                //        Packqty = (int?)parm.InventoryQuantity,
                //        PackUnit = parm.DrugSpecifications,
                //        BatchON = parm.BatchNumber,
                //        BatchNum = 0,
                //    };
                //    _StockService.AddStock(item);
                //}
                //Task.Run(async () =>
                //{
                //    Stock stock = new Stock
                //    {
                //        DrugId = parm.DrugId,
                //        Drugqty = 0,
                //        PurchasePrice = (decimal)parm.Price,
                //        RetailPrice = 0,
                //        InventoryQuantity = parm.InventoryQuantity,
                //        DeQuantity = "",
                //        ActualStock = "",
                //        SUnit = parm.Minunit,
                //        Packqty = int.Parse(parm.InventoryQuantity),
                //        PackUnit = parm.DrugSpecifications,
                //        BatchON = parm.BatchNumber,
                //        BatchNum = 0,
                //    };
                //    await _StockService.AddStockAsync(stock);
                //});

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
                PackageLevel = parmList.DrugClassification,
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

            var userName = HttpContext.GetName();
            //TODO
            Task.Run(async () =>
            {
                //在这添加生命周期 TODO
                await _LifeProcessService.AddLifeProcessAsync(new LifeProcess
                {
                    Receiptid = modal.ReceiptId,
                    DRUGId = modal.DrugId.ToString(),
                    //CodeId TODO
                    CodeId = WarehousingResponse.Id.ToString(),
                    Operator = userName,
                    Times = DateTime.Now.ToString("yyyy-MM-dd HH:mm:SS"),
                    Details = string.Format(@"{0}已入库，溯源码：{1}", modal.DrugName, parmList.TracingSourceCode)
                });
            });

            return SUCCESS("处理成功");
        }


        [HttpPost("AllAddPda")]
        [ActionPermissionFilter(Permission = "inwarehousing:add")]
        [Log(Title = "入库信息PDA", BusinessType = BusinessType.INSERT)]
        public IActionResult AddAllInWarehousingWithPda([FromBody] InWarehousingPdaDto parmList)
        {
            var inWarehousing = parmList.Adapt<InWarehousing>().ToCreate(HttpContext);
            var modal = parmList.Adapt<InWarehousingPdaDto>().ToCreate(HttpContext);
            Drug drug = _DrugService.GetListWithCondition(parmList);
            if(drug == null)
            {
                return ToResponse(ResultCode.FAIL, "药品未绑定，请前往PC端绑定！");
            }
            List<Dictionary<string, object>> list = Tools.CodeInOneWay(parmList.TracingSourceCode);
            inWarehousing.DrugId = drug.DrugId;
            inWarehousing.DrugCode = drug.DrugCode;
            inWarehousing.DrugSpecifications = drug.DrugSpecifications;
            inWarehousing.InventoryQuantity = 1;
            inWarehousing.BatchNumber = list[0]["batch_no"].ToString();
            var WarehousingResponse = _InWarehousingService.AddInWarehousingWithCondition(inWarehousing);
            var pdaCodeDetials = new CodeDetailsDto()
            {
                Code = parmList.TracingSourceCode,
                InWarehouseId = WarehousingResponse.Id,
                Receiptid = int.Parse(modal.ReceiptId),
            };
            _CodeDetailsService.PdaAddCodeDetails(pdaCodeDetials);
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
            InWarehousing uf = _InWarehousingService.GetId(parm.Id);
     
            var x= parm.InventoryQuantity-uf.InventoryQuantity;
            var modal = parm.Adapt<InWarehousing>().ToUpdate(HttpContext);
            var response = _InWarehousingService.UpdateInWarehousing(modal);
            if (response > 0)
            {
                var stock = _StockService.InGetInfo((int)modal.DrugId, modal.BatchNumber);
                if (stock != null && stock.Id > 0)
                {
                    stock.InventoryQuantity += x;
                    //修改
                    _StockService.UpdateStock(stock);
                }
                else if (stock == null)
                {
                    //新增
                    Stock item = new Stock
                    {
                        DrugId = parm.DrugId,
                        Drugqty = 0,
                        PurchasePrice = parm.Price == null ? 0 : (decimal)parm.Price,
                        RetailPrice = 0,
                        InventoryQuantity = parm.InventoryQuantity,
                        DeQuantity = 0,
                        ActualStock = 0,
                        SUnit = parm.Minunit,
                        Packqty = (int?)parm.InventoryQuantity,
                        PackUnit = parm.DrugSpecifications,
                        BatchON = parm.BatchNumber,
                        BatchNum = 0,
                    };
                    _StockService.AddStock(item);
                }

            }
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