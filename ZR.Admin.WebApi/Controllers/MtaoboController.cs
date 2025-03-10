﻿using Microsoft.AspNetCore.Mvc;
using Topsdk.Top.Ability2940.Request;
using Topsdk.Top.Ability2940;
using Topsdk.Top;
using System.Web;
using NLog.LayoutRenderers;
using Newtonsoft.Json.Linq;
using Topsdk.Top.Ability2940.Response;
using System.Security.Policy;
using Org.BouncyCastle.Ocsp;
using static System.Net.Mime.MediaTypeNames;
using ZR.Model.Business;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using Topsdk.Top.Ability2940.Domain;
using ZR.Service.Business.IBusinessService;
using Aliyun.OSS;
using Microsoft.AspNetCore.DataProtection;
using NETCore.Encrypt.Internal;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace ZR.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class MtaoboController : BaseController
    {

        public readonly static string APPKEY = "34712610";
        public readonly static string APPSECRECT = "d6e1a9eff5cb51c0a2c0044c6a3da96d";
        public readonly static string URL = "http://gw.api.taobao.com/router/rest";

        public static string Ref_id = "";
        public static ITopApiClient client = new DefaultTopApiClient(APPKEY, APPSECRECT, URL, 10000, 20000);
        public static Ability2940 apiPackage = new Ability2940(client);
        private readonly ISourceTracingService _SourceTracingService;

        public MtaoboController(ISourceTracingService SourceTracingService)
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

        /// <summary>
        /// 获取单据状态
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetBillStatu()
        {
            var response = Tools.GetBillStatus();
            return SUCCESS(response);
        }

        //获取企业标识
        [HttpGet]
        public object Getentinfo(string rennanem = "")
        {
            //ITopApiClient client = new DefaultTopApiClient(APPKEY, APPSECRECT, URL, 10000, 20000);
            //Ability2940 apiPackage = new Ability2940(client);
            var request = new AlibabaAlihealthDrugtraceTopYljgQueryGetentinfoRequest();
            //-- 佛山市南海区第五人民医院(佛山市南海区大沥医院)
            request.EntName = rennanem;
            var response = apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryGetentinfo(request);
            if (response.isSuccess())
            {
                return response.Result.Model.RefEntId;
            }
            else
            {
                return JObject.Parse(response.SubCode).ToString();

            }
        }
        /// <summary>
        /// 获取码信息
        /// </summary>
        /// <param name="codes">多个码用逗号拼接的字符串</param>
        /// <returns></returns>

        [HttpGet]
        public object codedetail(string codes = "")
        {
            //ITopApiClient client = new DefaultTopApiClient(APPKEY, APPSECRECT, URL, 10000, 20000);
            //Ability2940 apiPackage = new Ability2940(client);
            string[] numbers = codes.Split(',');
            List<string> code = new List<string>();
            // 将分隔后的每个字符串添加到列表中
            foreach (string number in numbers)
            {
                code.Add(number);
            }
            //"ent_id": "00000000000017495183",
            var request = new AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest();
            request.RefEntId = (string?)Getentinfo("佛山市南海区第五人民医院(佛山市南海区大沥医院)");
            Ref_id = request.RefEntId;
            //81797370314342290453
            request.Codes = new List<string>();
            request.Codes = code;
            var response = apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryCodedetail(request);

            if (response.isSuccess())
            {                
                //return f;
                return SUCCESS(response.Result);
            }
            else
            {
                return JObject.Parse(response.SubCode).ToString();
            }
        }
        [HttpGet]
        public IActionResult AllMIXcode(string codes)
        {
            string[] numbers = codes.Split(',');
            List<string> code = new List<string>();
            // 将分隔后的每个字符串添加到列表中
            foreach (string number in numbers)
            {
                code.Add(number);
            }
            //"ent_id": "00000000000017495183",
            var request = new AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest();
            request.RefEntId = (string?)Getentinfo("佛山市南海区第五人民医院(佛山市南海区大沥医院)");
            Ref_id = request.RefEntId;
            //81797370314342290453
            request.Codes = new List<string>();
            request.Codes = code;
            var response = apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryCodedetail(request);
            var resultList = new List<Vcodes>();
            //var f = MChange(response, resultList);
            var f = (List<Dictionary<string, object>>)GetSubCodesInfoByCode(response);
            return SUCCESS(f[0].GetValueOrDefault("sub_code"));
        }
        [HttpGet]
        public IActionResult AllMIXcodes(string codes)
        {
            string[] numbers = codes.Split(',');
            List<string> code = new List<string>();
            // 将分隔后的每个字符串添加到列表中
            foreach (string number in numbers)
            {
                code.Add(number);
            }
            //"ent_id": "00000000000017495183",
            var request = new AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest();
            request.RefEntId = (string?)Getentinfo("佛山市南海区第五人民医院(佛山市南海区大沥医院)");
            Ref_id = request.RefEntId;
            //81797370314342290453
            request.Codes = new List<string>();
            request.Codes = code;
            var response = apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryCodedetail(request);
            var resultList = new List<Vcodes>();
            //var f = MChange(response, resultList);
            var f = (List<Dictionary<string, object>>)GetSubCodesInfoByCodes(response);
            return SUCCESS(f);
        }
        [HttpGet]
        public IActionResult CodeInOneWay(string codes)
        {
            List<string> code = codes.Split(',').ToList();
            //"ent_id": "00000000000017495183",
            var request = new AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest();
            request.RefEntId = (string?)Getentinfo("佛山市南海区第五人民医院(佛山市南海区大沥医院)");
            request.Codes = code;
            var response = apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryCodedetail(request);
            var f = GetSubCodesInfoByCode(response);
            return SUCCESS(f);
        }



        //获取到码信息后 判断码是否是大码 获取到上游 -添加到入库单 -  通过大码查询小码 
        public class Vcodes
        {
            public string Code { get; set; }
            public string PackageLevel { get; set; }
            public string ParentCode { get; set; }
            public string CodeLevel { get; set; }
        }


        public object GetSubCodesInfoByCode(AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResponse response)
        {
            var isSuccess = response.Result.ResponseSuccess;
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (isSuccess.GetValueOrDefault())
            {
                var models = response.Result.Models;
                foreach (var item in models)
                {
                    Dictionary<string, object> itemDict = new Dictionary<string, object>();
                    var currentProductInfo = item.CodeProduceInfoDTO.ProduceInfoList[0];
                    //溯源码（父玛）
                    itemDict.Add("code", item.Code);
                    //数量
                    itemDict.Add("pkg_amount", currentProductInfo.PkgAmount);
                    //批号
                    itemDict.Add("batch_no", currentProductInfo.BatchNo);
                    //有效到期
                    itemDict.Add("exipre_date", DateTime.TryParse(currentProductInfo.ExpireDate, out DateTime expireDate) ? expireDate.ToString("yyyy-MM-dd") : "");
                    //生产日期
                    itemDict.Add("produce_date", DateTime.TryParse(currentProductInfo.ProduceDateStr, out DateTime produceDateStr) ? produceDateStr.ToString("yyyy-MM-dd") : "");
                    //有效到
                    itemDict.Add("expire", DateTime.TryParse(item.DrugEntBaseDTO.Exprie, out DateTime expire) ? expire.ToString("yyyy-MM-dd") : "");
                    //中码或者大码
                    if (item.PackageLevel.Equals("2") || item.PackageLevel.Equals("3"))
                    {
                        AlibabaAlihealthDrugtraceTopYljgQueryRelationResponse relationRes = relation(item.Code);
                        if(relationRes != null)
                        {
                            if (true == relationRes.Result.ResponseSuccess) 
                            {
                                var codeRelationList = relationRes.Result.ModelList[0].CodeRelationList;
                                var formatRelationList = codeRelationList.Where(x => x.CodePackLevel == "1").ToList();
                                itemDict.Add("sub_code", formatRelationList);
                            }
                            else if (relationRes.Result.ResponseSuccess == false)
                            {
                                string msg = AddOutBill(item.Code);
                                if (msg == "调用成功")
                                {
                                    return GetSubCodesInfoByCode(response);
                                }
                            }
                        }
                    }

                    list.Add(itemDict);
                }
            }
            return list;
        }


        public object GetSubCodesInfoByCodes(AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResponse response)
        {
            var isSuccess = response.Result.ResponseSuccess;
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            if (isSuccess.GetValueOrDefault())
            {
                var models = response.Result.Models;
                foreach (var item in models)
                {
                    Dictionary<string, object> itemDict = new Dictionary<string, object>();
                    var currentProductInfo = item.CodeProduceInfoDTO.ProduceInfoList[0];
                    //溯源码（父玛）
                    itemDict.Add("code", item.Code);
                    //数量
                    itemDict.Add("pkg_amount", currentProductInfo.PkgAmount);
                    //批号
                    itemDict.Add("batch_no", currentProductInfo.BatchNo);
                    //有效到期
                    itemDict.Add("exipre_date", DateTime.TryParse(currentProductInfo.ExpireDate, out DateTime expireDate) ? expireDate.ToString("yyyy-MM-dd") : "");
                    //生产日期
                    itemDict.Add("produce_date", DateTime.TryParse(currentProductInfo.ProduceDateStr, out DateTime produceDateStr) ? produceDateStr.ToString("yyyy-MM-dd") : "");
                    //有效到
                    itemDict.Add("expire", DateTime.TryParse(item.DrugEntBaseDTO.Exprie, out DateTime expire) ? expire.ToString("yyyy-MM-dd") : "");
                    itemDict.Add("packageLevel", item.PackageLevel);
                    
                    //中码或者大码

                    if (item.PackageLevel.Equals("2") || item.PackageLevel.Equals("3"))
                    {
                        AlibabaAlihealthDrugtraceTopYljgQueryRelationResponse relationRes = relation(item.Code);

                        if (relationRes != null)
                        {
                            if (true == relationRes.Result.ResponseSuccess)
                            {
                                var codeRelationList = relationRes.Result.ModelList[0].CodeRelationList;
                                //var formatRelationList = codeRelationList.Where(x => x.CodePackLevel == "1").ToList();
                                codeRelationList.ToList().ForEach(i => i.CodeLevel =i.CodePackLevel+ 1);

                                itemDict.Add("sub_code", codeRelationList);
                            }
                            else if (relationRes.Result.ResponseSuccess == false)
                            {
                                string msg = AddOutBill(item.Code);
                                if (msg == "调用成功")
                                {
                                    return GetSubCodesInfoByCodes(response);
                                }
                            }
                        }
                    }
                    //if(item.PackageLevel.Equals("1"))
                    //{
                    //    AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo ass=new AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo();
                    //    ass.Code=item.Code;
                    //    ass.CodeLevel = item.PackageLevel;
                    //    ass.CodePackLevel = item.PackageLevel ;
                    //    ass.ParentCode = "";
                    //    ass.Status = item.CodeStatusTypeDTO.CodeStatus;
                    //    itemDict.Add("sub_code", ass);
                    //}
                    list.Add(itemDict);

                }

            }
            return list;
        }

        public object MChange(AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResponse response, List<Vcodes> resultList)
        {
            var ModelState = response.Result.Models;
            //var resultList = new List<Vcodes>()
            if (resultList == null)
            {
                resultList = new List<Vcodes>(); // 初始化列表
            }
            //获取到的码 获取到等级后 是否存在有下属 若不存在先保存 -- 大码为3-需要查询获取 添加父码
            for (int i = 0; i < ModelState.Count; i++)
            {
                if (ModelState[i].PackageLevel == "3" || ModelState[i].PackageLevel == "2")
                {
                    AlibabaAlihealthDrugtraceTopYljgQueryRelationResponse res = relation(ModelState[i].Code);
                    if (res.Result.ModelList != null)
                    {
                        for (int j = 0; j < res.Result.ModelList.Count; j++)
                        {
                            for (int k = 0; k < res.Result.ModelList[j].CodeRelationList.Count; k++)
                            {

                                    Vcodes vcodes = new Vcodes();
                                    vcodes.Code = res.Result.ModelList[j].CodeRelationList[k].Code;
                                    vcodes.PackageLevel = res.Result.ModelList[j].CodeRelationList[k].CodePackLevel;
                                    vcodes.ParentCode= res.Result.ModelList[j].CodeRelationList[k].ParentCode;
                                    vcodes.CodeLevel = res.Result.ModelList[j].CodeRelationList[k].CodePackLevel + 1;
                                resultList.Add(vcodes);                             
                            }
                        }
                    }
                    else if (res.Result.ModelList == null)
                    {
                        string msg = AddOutBill(ModelState[i].Code);
                        
                        if (msg == "调用成功")
                        {
                            Task.Delay(5000);
                            return MChange(response, resultList);      
                        }
                    }
                }
                else if (ModelState[i].PackageLevel == "1")
                {
                    Vcodes vcodes = new Vcodes();
                    vcodes.Code = response.Result.Models[0].Code;
                    vcodes.PackageLevel = response.Result.Models[0].PackageLevel;
                    resultList.Add(vcodes);
                    return resultList;
                }
            }
            return resultList;
        }

        public string codelist(List<string> list)
        {
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str += list[0];
                str += ",";
            }
            return str;
        }

       

        [HttpGet]
        public AlibabaAlihealthDrugtraceTopYljgQueryRelationResponse relation(string code)
        {
            Ref_id = (string?)Getentinfo("佛山市南海区第五人民医院(佛山市南海区大沥医院)");
    
            var request = new AlibabaAlihealthDrugtraceTopYljgQueryRelationRequest();
            request.RefEntId = Ref_id;
            request.Code = code;
            request.DesRefEntId = Ref_id;

            var response = apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryRelation(request);

            if (response.isSuccess())
            {
                return response;
            }
            else
            {
                return response;
            }
        }

        [HttpGet]
        public string AddOutBill(string codes)
        {

            Ref_id = (string?)Getentinfo("佛山市南海区第五人民医院(佛山市南海区大沥医院)");

            SourceTracing sourceTracing = new SourceTracing();

            sourceTracing.Codes= codes;
            //sourceTracing.BillCode =;
            var request = new AlibabaAlihealthDrugtraceTopYljgUploadinoutbillRequest();
            //"CGRK"+
            long snowId = Tools.GenerateSnowCode();
            //var r =_SourceTracingService.GetSources().Count();
            string uniqueBillCode = $"BC{snowId}";
            //创建 
            SourceTracing parm =new SourceTracing();
            parm.Codes = codes;
            parm.BillCode= uniqueBillCode;
            var modal = parm.Adapt<SourceTracing>().ToCreate(HttpContext);
            var tr = _SourceTracingService.AddSourceTracing(modal);

            request.BillCode = uniqueBillCode;
            request.BillTime = DateTime.Now;
            request.BillType = 102;
            request.PhysicType = 3;
            request.RefUserId = Ref_id;

            //发货企业
            request.FromUserId = Ref_id;
            //收货企业
            request.ToUserId = Ref_id;

            var cd = new List<string>();
            request.TraceCodes = cd;
            cd.Add(codes);
            request.ClientType = "2";

            var response = apiPackage.AlibabaAlihealthDrugtraceTopYljgUploadinoutbill(request);
            if (response.isSuccess())
            {
                return response.MsgInfo;
            }
            else
            {
                return response.MsgInfo;

            }
        }
    }

}