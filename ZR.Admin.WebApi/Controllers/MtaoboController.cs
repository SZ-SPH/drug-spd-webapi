using Microsoft.AspNetCore.Mvc;
using Topsdk.Top.Ability2940.Request;
using Topsdk.Top.Ability2940;
using Topsdk.Top;
using System.Web;
using NLog.LayoutRenderers;
using Newtonsoft.Json.Linq;

namespace ZR.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    public class MtaoboController : BaseController
    {

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //获取企业标识
        [HttpGet]
        public object getentinfo(string rennanem = "")
        {
            string APPKEY = "34712610";
            string APPSECRECT = "d6e1a9eff5cb51c0a2c0044c6a3da96d";
            string URL = "http://gw.api.taobao.com/router/rest";

            // create Client
            ITopApiClient client = new DefaultTopApiClient(APPKEY, APPSECRECT, URL, 10000, 20000);
            Ability2940 apiPackage = new Ability2940(client);

            // create request
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
            string APPKEY = "34712610";
            string APPSECRECT = "d6e1a9eff5cb51c0a2c0044c6a3da96d";
            string URL = "http://gw.api.taobao.com/router/rest";

            // create Client
            ITopApiClient client = new DefaultTopApiClient(APPKEY, APPSECRECT, URL, 10000, 20000);
            Ability2940 apiPackage = new Ability2940(client);


            string[] numbers = codes.Split(',');             
            List<string> code = new List<string>();
            // 将分隔后的每个字符串添加到列表中
            foreach (string number in numbers)
            {
                code.Add(number);
            }
            //code.Add("81797370314342290453");         "ent_id": "00000000000017495183",

            // create request
            var request = new AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest();
            //--
            request.RefEntId = (string?)getentinfo("佛山市南海区第五人民医院(佛山市南海区大沥医院)");
            //81797370314342290453
            request.Codes = new List<string>();
            request.Codes = code;
            var response = apiPackage.AlibabaAlihealthDrugtraceTopYljgQueryCodedetail(request);
            if (response.isSuccess())
            {
                //&#29579;&#25991;&#20889;&#30340;&#22403;&#22334;&#20195;&#30721;
                return SUCCESS(response.Result);
            }
            else
            {
                return JObject.Parse(response.SubCode).ToString();
            }


        }


    }

}
