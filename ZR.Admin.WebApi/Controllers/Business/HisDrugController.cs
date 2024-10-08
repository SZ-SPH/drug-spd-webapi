﻿using Microsoft.AspNetCore.Mvc;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;
using ZR.Admin.WebApi.Filters;
using MiniExcelLibs;
using ZR.Service.Business;

namespace ZR.Admin.WebApi.Controllers.Business
{
    /// <summary>
    /// 药品基础资料管理
    /// </summary>
    [AllowAnonymous]

    [Route("business/HisDrug")]
    public class HisDrugController : BaseController
    {
        /// <summary>
        /// 药品基础资料管理接口
        /// </summary>
        private readonly IHisDrugService _HisDrugService;

        public HisDrugController(IHisDrugService HisDrugService)
        {
            _HisDrugService = HisDrugService;
        }

        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        [HttpGet("list")]
        //[ActionPermissionFilter(Permission = "drug:list")]
        public IActionResult QueryDrug([FromQuery] HisDrugQueryDto parm)
        {
            var response = _HisDrugService.GetList(parm);
            return SUCCESS(response);
        }


        /// <summary>
        /// 查询药品基础资料管理详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        [ActionPermissionFilter(Permission = "drug:query")]
        public IActionResult GetDrug(string code)
        {
            var response = _HisDrugService.GetInfo(code);

            var info = response.Adapt<HisDrugDto>();
            return SUCCESS(info);
        }
  

    }
}