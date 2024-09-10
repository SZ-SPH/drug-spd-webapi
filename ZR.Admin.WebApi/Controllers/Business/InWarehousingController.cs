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
    [Route("business/InWarehousing")]
    public class InWarehousingController : BaseController
    {
        /// <summary>
        /// 入库信息接口
        /// </summary>
        private readonly IInWarehousingService _InWarehousingService;

        public InWarehousingController(IInWarehousingService InWarehousingService)
        {
            _InWarehousingService = InWarehousingService;
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
            //var modal = parm.Adapt<InWarehousing>().ToCreate(HttpContext);

            //var response = _InWarehousingService.AddInWarehousing(modal);

            //return SUCCESS(response);
            // Loop through each item in the list
            foreach (var parm in parmList)
            {
                var modal = parm.Adapt<InWarehousing>().ToCreate(HttpContext);

                var response = _InWarehousingService.AddInWarehousing(modal);

                // You might want to handle the response for each item here
                // For example, you can aggregate the responses, return the last one, etc.
            }

            // Return a success response; you can customize this based on how you handle multiple items
            return SUCCESS("All items processed successfully.");
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