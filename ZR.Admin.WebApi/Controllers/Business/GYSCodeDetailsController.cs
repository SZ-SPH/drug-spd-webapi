using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-12-03
namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 送货单追溯码
    /// </summary>
    [Verify]
    [Route("business/GYSCodeDetails")]
    public class GYSCodeDetailsController : BaseController
    {
        /// <summary>
        /// 送货单追溯码接口
        /// </summary>
        private readonly IGYSCodeDetailsService _GYSCodeDetailsService;

        public GYSCodeDetailsController(IGYSCodeDetailsService GYSCodeDetailsService)
        {
            _GYSCodeDetailsService = GYSCodeDetailsService;
        }

        /// <summary>
        /// 查询送货单追溯码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "gyscodedetails:list")]
        public IActionResult QueryGYSCodeDetails([FromQuery] GYSCodeDetailsQueryDto parm)
        {
            var response = _GYSCodeDetailsService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询送货单追溯码详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        [ActionPermissionFilter(Permission = "gyscodedetails:query")]
        public IActionResult GetGYSCodeDetails(int Id)
        {
            var response = _GYSCodeDetailsService.GetInfo(Id);
            
            var info = response.Adapt<GYSCodeDetailsDto>();
            return SUCCESS(info);
        }

        /// <summary>
        /// 添加送货单追溯码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionPermissionFilter(Permission = "gyscodedetails:add")]
        [Log(Title = "送货单追溯码", BusinessType = BusinessType.INSERT)]
        public IActionResult AddGYSCodeDetails([FromBody]List<GYSCodeDetailsDto> parm)
        {
            foreach (var item in parm) { 
                var modal = item.Adapt<GYSCodeDetails>().ToCreate(HttpContext);

            var response = _GYSCodeDetailsService.AddGYSCodeDetails(modal);
            }
        

            return SUCCESS("true");
        }

        /// <summary>
        /// 更新送货单追溯码
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ActionPermissionFilter(Permission = "gyscodedetails:edit")]
        [Log(Title = "送货单追溯码", BusinessType = BusinessType.UPDATE)]
        public IActionResult UpdateGYSCodeDetails([FromBody] GYSCodeDetailsDto parm)
        {
            var modal = parm.Adapt<GYSCodeDetails>().ToUpdate(HttpContext);
            var response = _GYSCodeDetailsService.UpdateGYSCodeDetails(modal);

            return ToResponse(response);
        }

        /// <summary>
        /// 删除送货单追溯码
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete/{ids}")]
        [ActionPermissionFilter(Permission = "gyscodedetails:delete")]
        [Log(Title = "送货单追溯码", BusinessType = BusinessType.DELETE)]
        public IActionResult DeleteGYSCodeDetails([FromRoute]string ids)
        {
            var idArr = Tools.SplitAndConvert<int>(ids);

            return ToResponse(_GYSCodeDetailsService.Delete(idArr));
        }

        /// <summary>
        /// 导出送货单追溯码
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单追溯码", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [HttpGet("export")]
        [ActionPermissionFilter(Permission = "gyscodedetails:export")]
        public IActionResult Export([FromQuery] GYSCodeDetailsQueryDto parm)
        {
            parm.PageNum = 1;
            parm.PageSize = 100000;
            var list = _GYSCodeDetailsService.ExportList(parm).Result;
            if (list == null || list.Count <= 0)
            {
                return ToResponse(ResultCode.FAIL, "没有要导出的数据");
            }
            var result = ExportExcelMini(list, "送货单追溯码", "送货单追溯码");
            return ExportExcel(result.Item2, result.Item1);
        }

        /// <summary>
        /// 清空送货单追溯码
        /// </summary>
        /// <returns></returns>
        [Log(Title = "送货单追溯码", BusinessType = BusinessType.CLEAN)]
        [ActionPermissionFilter(Permission = "gyscodedetails:delete")]
        [HttpDelete("clean")]
        public IActionResult Clear()
        {
            if (!HttpContextExtension.IsAdmin(HttpContext))
            {
                return ToResponse(ResultCode.FAIL, "操作失败");
            }
            return SUCCESS(_GYSCodeDetailsService.TruncateGYSCodeDetails());
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost("importData")]
        [Log(Title = "送货单追溯码导入", BusinessType = BusinessType.IMPORT, IsSaveRequestData = false)]
        [ActionPermissionFilter(Permission = "gyscodedetails:import")]
        public IActionResult ImportData([FromForm(Name = "file")] IFormFile formFile)
        {
            List<demoExport> list = new();
            List<GYSCodeDetails> GYSlist = new();

            using (var stream = formFile.OpenReadStream())
            {
                list = stream.Query<demoExport>(startCell: "A1").ToList();
            }
            foreach (var item in list)
            {
                GYSCodeDetails gYS=new GYSCodeDetails();
                gYS.Deliveryid = item.DeliveyId;
                gYS.InDeliveryId = item.DeliveyDrugId;
                gYS.DrugId = item.DrugId;
                gYS.Code = item.GYSCode;
                gYS.PackageLevel = item.GYSCodeLever;
                GYSlist.Add(gYS);
            }


            return SUCCESS(_GYSCodeDetailsService.ImportGYSCodeDetails(GYSlist.Adapt<List<GYSCodeDetails>>()));
        }

        /// <summary>
        /// 送货单追溯码导入模板下载
        /// </summary>
        /// <returns></returns>
        [HttpGet("importTemplate")]
        [Log(Title = "送货单追溯码模板", BusinessType = BusinessType.EXPORT, IsSaveResponseData = false)]
        [AllowAnonymous]
        public IActionResult ImportTemplateExcel()
        {
            var result = DownloadImportTemplate(new List<GYSCodeDetailsDto>() { }, "GYSCodeDetails");
            return ExportExcel(result.Item2, result.Item1);
        }

    }
}