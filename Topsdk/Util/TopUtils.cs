using System.Security.Cryptography;
using System.Text;

using System.Text.Json;
using System.Text.Json.Nodes;


namespace Topsdk.Util
{
    /// <summary>
    /// TOP系统工具类。
    /// </summary>
    public abstract class TopUtils
    {
        private static JsonSerializerOptions options =  new JsonSerializerOptions()
        {
            WriteIndented = true,
            Converters = { new DateTimeJsonConverter("yyyy-MM-dd HH:mm:ss") }
        };

        /// <summary>
        /// 给TOP请求签名。
        /// </summary>
        /// <param name="parameters">所有字符型的TOP请求参数</param>
        /// <param name="secret">签名密钥</param>
        /// <param name="signMethod">签名方法，可选值：md5, hmac</param>
        /// <returns>签名</returns>
        public static string SignTopRequest(IDictionary<string, string> parameters, string secret, string signMethod)
        {
            return SignTopRequestWithBody(parameters, null, secret, signMethod);
        }
        
        /// <summary>
        /// 给TOP请求签名。
        /// </summary>
        /// <param name="publicParam"></param>
        /// <param name="requestParam"></param>
        /// <param name="secret"></param>
        /// <param name="signMethod"></param>
        /// <returns></returns>
        public static string SignTopRequest(IDictionary<string, string> publicParam,IDictionary<string,string> requestParam, string secret, string signMethod)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>(publicParam);
            foreach (KeyValuePair<string,string> item in requestParam)
            {
                parameters.Add(item);
            }
            return SignTopRequest(parameters, secret, signMethod);
        }

        /// <summary>
        /// 给TOP请求签名。
        /// </summary>
        /// <param name="parameters">所有字符型的TOP请求参数</param>
        /// <param name="body">请求主体内容</param>
        /// <param name="secret">签名密钥</param>
        /// <param name="signMethod">签名方法，可选值：md5, hmac</param>
        /// <returns>签名</returns>
        public static string SignTopRequestWithBody(IDictionary<string, string> parameters, string body, string secret, string signMethod)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder();
            if(Constants.SIGN_METHOD_MD5.Equals(signMethod))
            {
                query.Append(secret);
            }
            foreach (KeyValuePair<string, string> kv in sortedParams)
            {
                if (!string.IsNullOrEmpty(kv.Key) && !string.IsNullOrEmpty(kv.Value))
                {
                    query.Append(kv.Key).Append(kv.Value);
                }
            }

            // 第三步：把请求主体拼接在参数后面
            if (!string.IsNullOrEmpty(body))
            {
                query.Append(body);
            }

            // 第四步：使用MD5/HMAC加密
            byte[] bytes;
            if (Constants.SIGN_METHOD_HMAC.Equals(signMethod))
            {
                HMACMD5 hmac = new HMACMD5(Encoding.UTF8.GetBytes(secret));
                bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            }
            else if (Constants.SIGN_METHOD_HMAC_SHA256.Equals(signMethod))
            {
                HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
                bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            }
            else
            {
                query.Append(secret);
                MD5 md5 = MD5.Create();
                bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            }

            // 第五步：把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }

            return result.ToString();
        }

        /// <summary>
        /// 清除字典中值为空的项。
        /// </summary>
        /// <param name="dict">待清除的字典</param>
        /// <returns>清除后的字典</returns>
        public static IDictionary<string, T> CleanupDictionary<T>(IDictionary<string, T> dict)
        {
            IDictionary<string, T> newDict = new Dictionary<string, T>(dict.Count);

            foreach (KeyValuePair<string, T> kv in dict)
            {
                if (kv.Value != null)
                {
                    newDict.Add(kv.Key, kv.Value);
                }
            }

            return newDict;
        }


        /// <summary>
        /// 获取从1970年1月1日到现在的毫秒总数。
        /// </summary>
        /// <returns>毫秒数</returns>
        public static long GetCurrentTimeMillis()
        {
            return (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        /// <summary>
        /// 复杂对象列表转json
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ConvertStructList(object? list)
        {
            if (list == null)
            {
                return "[]";
            }

            if (list is string)
            {
                return (string)list;
            }

            return JsonSerializer.Serialize(list,options);

        }
        
        public static string ConvertStruct(object? obj)
        {
            if (obj == null)
            {
                return "{}";
            }

            if (obj is string)
            {
                return (string)obj;
            }

            return JsonSerializer.Serialize(obj);
        }

        public static string ConvertBasicList<T>(IList<T> list)
        {
            if (list == null)
            {
                return "";
            }
            return string.Join(",",list);
        }

        public static string ConvertBasicType(object? obj)
        {
            if (obj == null)
            {
                return "";
            }
            if (obj is DateTime)
            {
                return ((DateTime)obj).ToString(Constants.DATE_TIME_FORMAT);
            }

            if (obj is bool)
            {
                return ((bool)obj).ToString().ToLower();
            }

            return obj.ToString();
        }

        public static T parseResultJson<T>(string jsonStr)
        {
            try
            {
                var jsonNode = JsonObject.Parse(jsonStr);
                if (jsonNode[Constants.ERROR_RESPONSE] != null)
                {
                    return jsonNode[Constants.ERROR_RESPONSE].Deserialize<T>(options);
                }
                return jsonNode.Deserialize<T>(options);
            }
            catch (Exception e)
            {
                throw new TopException("ApiResult is not json");
            }
        }


    }
}
