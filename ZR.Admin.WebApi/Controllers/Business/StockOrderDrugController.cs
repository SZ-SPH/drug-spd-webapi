using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.Business;

//创建时间：2024-08-27
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 备货单药品
    /// </summary>
    [Verify]
    [Route("business/StockOrderDrug")]
    public class StockOrderDrugController : BaseController
    {
        /// <summary>
        /// 备货单药品接口
        /// </summary>
        private readonly IStockOrderDrugService _StockOrderDrugService;

        public StockOrderDrugController(IStockOrderDrugService StockOrderDrugService)
        {
            _StockOrderDrugService = StockOrderDrugService;
        }

        /// <summary>
        /// 查询备货单药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "stockorderdrug:list")]
        public IActionResult QueryStockOrderDrug([FromQuery] StockOrderDrugQueryDto parm)
        {
            var response = _StockOrderDrugService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询备货单药品详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "stockorderdrug:query")]
        public IActionResult GetStockOrderDrug(int Id)
        {
            var response = _StockOrderDrugService.GetInfo(Id);
            
            var info = response.Adapt<StockOrderDrugDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加备货单药品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "stockorderdrug:add")]
        [Log(Title = "备货单药品", BusinessType = BusinessType.INSERT)]
        public IActionResult AddStockOrderDrug([FromBody]List<StockOrderDrugDto> parmList)
        {
            foreach (var parm in parmList)
            {
                var modal = parm.Adapt<StockOrderDrug>().ToCreate(HttpContext);

                var response = _StockOrderDrugService.AddStockOrderDrug(modal);

            }
            return SUCCESS("All items processed successfully.");
      

          
        }

        /// <summary>
        /// 更新备货单药品
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "stockorderdrug:edit")]
        [Log(Title = "备货单药品", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateStockOrderDrug([FromBody] StockOrderDrugDto parm)
        {
            var modal = parm.Adapt<StockOrderDrug>().ToUpdate(HttpContext);
            var response = _StockOrderDrugService.UpdateStockOrderDrug(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除备货单药品
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "stockorderdrug:delete")]
        [Log(Title = "备货单药品", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteStockOrderDrug([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_StockOrderDrugService.Delete(idArr));
        }

        /// <summary>
        /// 导出备货单药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "备货单药品", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "stockorderdrug:export")]
        public IActionResult Export([FromQuery] StockOrderDrugQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _StockOrderDrugService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "备货单药品", "备货单药品");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空备货单药品
        /// </summary>
        /// <returns></returns>
        [Log(Title = "备货单药品", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "stockorderdrug:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_StockOrderDrugService.TruncateStockOrderDrug());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "备货单药品导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "stockorderdrug:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<StockOrderDrugDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<StockOrderDrugDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_StockOrderDrugService.ImportStockOrderDrug(list.Adapt<List<StockOrderDrug>>()));
        }

        /// <summary>
        /// 备货单药品导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "备货单药品模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<StockOrderDrugDto>() { }, "StockOrderDrug");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}