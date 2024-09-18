using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 入库信息
    /// </summary>
    [Verify]
    [Route("business/InWarehousingDrug")]
    public class InWarehousingDrugController : BaseController
    {
        /// <summary>
        /// 入库信息接口
        /// </summary>
        private readonly IInWarehousingDrugService _InWarehousingDrugService;

        public InWarehousingDrugController(IInWarehousingDrugService InWarehousingDrugService)
        {
            _InWarehousingDrugService = InWarehousingDrugService;
        }

        /// <summary>
        /// 查询入库信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "InWarehousing:list")]
        public IActionResult QueryInWarehousingDrug([FromQuery] InWarehousingDrugQueryDto parm)
        {
            var response = _InWarehousingDrugService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询入库信息详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "InWarehousing:query")]
        public IActionResult GetInWarehousingDrug(int Id)
        {
            var response = _InWarehousingDrugService.GetInfo(Id);

            var info = response.Adapt<InWarehousingDrugDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加入库信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "InWarehousing:add")]
        [Log(Title = "入库信息", BusinessType = BusinessType.INSERT)]
        public IActionResult AddInWarehousingDrug([FromBody] List<InWarehousingDrugDto> parmList)
        {
            //var modal = parm.Adapt<InWarehousingDrug>().ToCreate(HttpContext);

            //var response = _InWarehousingDrugService.AddInWarehousingDrug(modal);

            //return SUCCESS(response);

            foreach (var parm in parmList)
            {
                var modal = parm.Adapt<InWarehousingDrug>().ToCreate(HttpContext);

                var response = _InWarehousingDrugService.AddInWarehousingDrug(modal);

            }


            return SUCCESS("All items processed successfully.");
        }

        /// <summary>
        /// 更新入库信息
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "inWarehousingDrug:edit")]
        [Log(Title = "入库信息", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateInWarehousingDrug([FromBody] InWarehousingDrugDto parm)
        {
            var modal = parm.Adapt<InWarehousingDrug>().ToUpdate(HttpContext);
            var response = _InWarehousingDrugService.UpdateInWarehousingDrug(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除入库信息
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "inWarehousingDrug:delete")]
        [Log(Title = "入库信息", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteInWarehousingDrug([FromRoute] string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_InWarehousingDrugService.Delete(idArr));
        }

        /// <summary>
        /// 导出入库信息
        /// </summary>
        /// <returns></returns>
        [Log(Title = "入库信息", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "inWarehousingDrug:export")]
        public IActionResult Export([FromQuery] InWarehousingDrugQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _InWarehousingDrugService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "入库信息", "入库信息");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}