using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-09-04
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 仓库
    /// </summary>
    [Verify]
    [Route("business/Warehouse")]
    public class WarehouseController : BaseController
    {
        /// <summary>
        /// 仓库接口
        /// </summary>
        private readonly IWarehouseService _WarehouseService;

        public WarehouseController(IWarehouseService WarehouseService)
        {
            _WarehouseService = WarehouseService;
        }

        /// <summary>
        /// 查询仓库列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "warehouse:list")]
        public IActionResult QueryWarehouse([FromQuery] WarehouseQueryDto parm)
        {
            var response = _WarehouseService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询仓库详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "warehouse:query")]
        public IActionResult GetWarehouse(int Id)
        {
            var response = _WarehouseService.GetInfo(Id);

            var info = response.Adapt<WarehouseDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "warehouse:add")]
        [Log(Title = "仓库", BusinessType = BusinessType.INSERT)]
        public IActionResult AddWarehouse([FromBody] WarehouseDto parm)
        {
            var modal = parm.Adapt<Warehouse>().ToCreate(HttpContext);

            var response = _WarehouseService.AddWarehouse(modal);

            return SUCCESS(response);
        }

        /// <summary>
        /// 更新仓库
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "warehouse:edit")]
        [Log(Title = "仓库", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateWarehouse([FromBody] WarehouseDto parm)
        {
            var modal = parm.Adapt<Warehouse>().ToUpdate(HttpContext);
            var response = _WarehouseService.UpdateWarehouse(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "warehouse:delete")]
        [Log(Title = "仓库", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteWarehouse([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_WarehouseService.Delete(idArr));
        }

        /// <summary>
        /// 导出仓库
        /// </summary>
        /// <returns></returns>
        [Log(Title = "仓库", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "warehouse:export")]
        public IActionResult Export([FromQuery] WarehouseQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _WarehouseService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "仓库", "仓库");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空仓库
        /// </summary>
        /// <returns></returns>
        [Log(Title = "仓库", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "warehouse:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_WarehouseService.TruncateWarehouse());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "仓库导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "warehouse:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<WarehouseDto> list = new();
            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<WarehouseDto>(startCell: "A1").ToList();
            }

            return SUCCESS(_WarehouseService.ImportWarehouse(list.Adapt<List<Warehouse>>()));
        }

        /// <summary>
        /// 仓库导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "仓库模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<WarehouseDto>() { }, "Warehouse");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}