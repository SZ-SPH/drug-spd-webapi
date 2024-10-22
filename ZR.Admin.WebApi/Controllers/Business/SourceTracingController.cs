using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;

//创建时间：2024-09-04
namespace ZR.Admin.WebApi.Controllers.Business
{
    [Route("business/SourceTracing")]
    public class SourceTracingController : BaseController
    {
     
        private readonly ISourceTracingService _SourceTracingService;

        public SourceTracingController(ISourceTracingService SourceTracingService)
        {
            _SourceTracingService = SourceTracingService;
        }


  
        [HttpGet("{Id}")]
        public IActionResult GetSourceTracing(int Id)
        {
            var response = _SourceTracingService.GetInfo(Id);
                        var info = response.Adapt<SourceTracing>();
            return SUCCESS(info);
        }

        [HttpGet("ALL")]
        public IActionResult GetSourcesList()
        {
            var response = _SourceTracingService.GetSources();
            var info = response.Adapt<SourceTracing>();
            return SUCCESS(info);
        }

        [HttpPost]
        public IActionResult AddSourceTracing([FromBody] SourceTracing parm)
        {
            var modal = parm.Adapt<SourceTracing>().ToCreate(HttpContext);

            var response = _SourceTracingService.AddSourceTracing(modal);

            return SUCCESS(response);
        }

       
    }
}