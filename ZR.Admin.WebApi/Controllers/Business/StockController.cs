using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using Org.BouncyCastle.Crypto;
using Aliyun.OSS;

//创建时间：2024-09-26
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 库存
    /// </summary>
    [Verify]
    [Route("business/Stock")]
    public class StockController : BaseController
    {
        /// <summary>
        /// 库存接口
        /// </summary>
        private readonly IStockService _StockService;

        public StockController(IStockService StockService)
        {
            _StockService = StockService;
        }

        /// <summary>
        /// 查询库存列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "stock:list")]
        public IActionResult QueryStock([FromQuery] StockQueryDto parm)
        {
            var response = _StockService.GetList(parm);
            return SUCCESS(response);
        }

        /// <summary>
        /// 查询库存列表
        /// </summary>
        /// <param name="idlist"></param>
        /// <returns></returns>
        [HttpPost("AllGetlist")]
        [ActionPermissionFilter(Permission = "stock:list")]
        public IActionResult ALLplanQueryStock([FromBody] List<int> idlist)
        {
            var response = _StockService.AllGetInfo(idlist);
            return SUCCESS(response);

        }



        /// <summary>
        /// 查询库存详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "stock:query")]
        public IActionResult GetStock(int Id)
        {
            var response = _StockService.GetInfo(Id);
            
            var info = response.Adapt<StockDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加库存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "stock:add")]
        [Log(Title = "库存", BusinessType = BusinessType.INSERT)]
        public IActionResult AddStock([FromBody] StockDto parm)
        {
            var modal = parm.Adapt<Stock>().ToCreate(HttpContext);

            var response = _StockService.AddStock(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "stock:edit")]
        [Log(Title = "库存", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateStock([FromBody] StockDto parm)
        {
            var modal = parm.Adapt<Stock>().ToUpdate(HttpContext);
            var response = _StockService.UpdateStock(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除库存
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "stock:delete")]
        [Log(Title = "库存", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteStock([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_StockService.Delete(idArr, "删除库存"));
        }

        /// <summary>
        /// 导出库存
        /// </summary>
        /// <returns></returns>
        [Log(Title = "库存", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "stock:export")]
        public IActionResult Export([FromQuery] StockQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _StockService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "库存", "库存");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空库存
        /// </summary>
        /// <returns></returns>
        [Log(Title = "库存", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "stock:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_StockService.TruncateStock());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "库存导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "stock:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<StockDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<StockDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_StockService.ImportStock(list.Adapt<List<Stock>>()));
        }

        /// <summary>
        /// 库存导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "库存模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<StockDto>() { }, "Stock");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}