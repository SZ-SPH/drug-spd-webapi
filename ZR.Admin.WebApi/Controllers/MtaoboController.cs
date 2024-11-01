using Microsoft.AspNetCore.Mvc;
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
            var f = MChange(response, resultList);
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
            var resultList = new List<Vcodes>();
            var f = MChange(response, resultList);
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
                    //中码或者大码
                    if (item.PackageLevel.Equals("2") || item.PackageLevel.Equals("3"))
                    {
                        
                    }
                    //小码
                    else
                    {
                        itemDict.Add("parent_code", item.Code);
                        itemDict.Add("pkg_amount", item.CodeProduceInfoDTO.ProduceInfoList[0].PkgAmount);
                        itemDict.Add("batch_no", item.CodeProduceInfoDTO.ProduceInfoList[0].BatchNo);
                    }
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
                                //if (res.Result.ModelList[j].CodeRelationList[k].Code== ModelState[0].Code)
                                //{
                                //    return resultList;
                                //}
                                //if (res.Result.ModelList[j].CodeRelationList[k].CodePackLevel == "2")
                                //{
                                //    //list.Add(res.Result.ModelList[j].CodeRelationList[k].Code);
                                //    var request = new AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest();
                                //    request.RefEntId = Ref_id;
                                //    request.Codes = new List<string> { res.Result.ModelList[j].CodeRelationList[k].Code };
                                //    return MChange(apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryCodedetail(request), resultList);
                                //}
                                //else if (res.Result.ModelList[j].CodeRelationList[k].CodePackLevel == "1")
                                //{
                                    Vcodes vcodes = new Vcodes();
                                    vcodes.Code = res.Result.ModelList[j].CodeRelationList[k].Code;
                                    vcodes.PackageLevel = res.Result.ModelList[j].CodeRelationList[k].CodePackLevel;
                                    vcodes.ParentCode= res.Result.ModelList[j].CodeRelationList[k].ParentCode;
                                    vcodes.CodeLevel = res.Result.ModelList[j].CodeRelationList[k].CodePackLevel + 1;

                                resultList.Add(vcodes);
                                //}
                            }
                        }
                    }
                    else if (res.Result.ModelList == null)
                    {
                        string msg = AddOutBill(ModelState[i].Code);
                        if (msg == "调用成功")
                        {
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

        //public object MChange(AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResponse response)
        //{
        //    var modelState = response.Result.Models;

        //    foreach (var model in modelState)
        //    {
        //        if (model.PackageLevel == "3" || model.PackageLevel == "2")
        //        {
        //            var relationResponse = relation(model.Code);
        //            if (relationResponse.Result.ModelList != null)
        //            {
        //                foreach (var item in relationResponse.Result.ModelList)
        //                {
        //                    var code = GetCodeFromRelations((List<AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo>)item.CodeRelationList);
        //                    if (code != null)
        //                    {
        //                        var request = CreateRequest(code);
        //                        return MChange(apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryCodedetail(request));
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                string msg = AddOutBill(model.Code);
        //                if (msg == "调用成功")
        //                {
        //                    return MChange(response);
        //                }
        //            }
        //        }
        //        else if (model.PackageLevel == "1")
        //        {
        //            return ""; // 如果需要处理PackageLevel为1的逻辑
        //        }
        //    }
        //    return ""; // 返回空字符串，表示没有匹配的情况
        //}

        //private string GetCodeFromRelations(List<AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo> relations)
        //{
        //    foreach (var relation in relations)
        //    {
        //        if (relation.CodePackLevel == "2")
        //        {
        //            return relation.Code;
        //        }
        //    }
        //    return null; // 如果没有找到符合条件的代码，返回null
        //}

        //private AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest CreateRequest(string code)
        //{
        //    return new AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest
        //    {
        //        RefEntId = Ref_id,
        //        Codes = new List<string> { code }
        //    };
        //}

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
            var r =_SourceTracingService.GetSources().Count();
            string uniqueBillCode = $"BC{DateTime.Now:yyyyMMddHHmmss}_{(r+1):D5}";
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