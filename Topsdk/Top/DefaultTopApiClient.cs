using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Web;
using Topsdk.Util;

namespace Topsdk.Top;

public class DefaultTopApiClient: AbstractTopApiClient
{
    protected HttpClient _client;
    

    public DefaultTopApiClient(string appkey, string appSecret, string serverUrl)
    {
        if (string.IsNullOrWhiteSpace(appkey))
        {
           throw new ArgumentNullException(nameof(appkey));
        }
        if (string.IsNullOrWhiteSpace(appSecret))
        {
            throw new ArgumentNullException(nameof(appSecret));
        }
        if (string.IsNullOrWhiteSpace(serverUrl))
        {
            throw new ArgumentNullException(nameof(serverUrl));
        }
        this.appkey = appkey;
        this.appSecret = appSecret;
        this.serverUrl = serverUrl;
        Init();
    }
    
    public DefaultTopApiClient(string appkey, string appSecret, string serverUrl, long connectTimeOut, long totalTimeout) 
                                : this(appkey, appSecret, serverUrl)
    {
        this.connectTimeOut = connectTimeOut;
        this.totalTimeout = totalTimeout;
        Init();
    }
    
    public DefaultTopApiClient(string appkey, string appSecret, string serverUrl, long connectTimeOut, long totalTimeout, bool ignoreSSLCheck) 
        : this(appkey, appSecret, serverUrl,connectTimeOut, totalTimeout)
    {
        this.ignoreSsl = ignoreSSLCheck;
        Init();
    }
    
    public DefaultTopApiClient(string appkey, string appSecret, string serverUrl, long connectTimeOut, long totalTimeout, bool ignoreSSLCheck,IWebProxy proxy) 
        : this(appkey, appSecret, serverUrl,connectTimeOut, totalTimeout,ignoreSSLCheck)
    {
        this.proxy = proxy;
        Init();
    }
    

    public override void Init()
    {
        var handler = new SocketsHttpHandler()
        {
            ConnectTimeout = TimeSpan.FromMilliseconds(this.ConnectTimeOut),
            PooledConnectionLifetime = TimeSpan.FromMinutes(5)
        };
        if (proxy != null)
        {
            handler.Proxy = this.Proxy;
            handler.UseProxy = true;
        }
        if (ignoreSsl)
        {
            handler.SslOptions = new SslClientAuthenticationOptions()
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true,
            };
        }

        _client = new HttpClient(handler)
        {
            Timeout = TimeSpan.FromMilliseconds(TotalTimeout)
        };
    }

    public override string Execute(string apiCode, IDictionary<string, string> requestParam, IDictionary<string, TopFileItem> fileParam, string session)
    {
        if (requestParam == null)
        {
            requestParam = new Dictionary<string, string>();
        }

        if (fileParam == null)
        {
            fileParam = new Dictionary<string, TopFileItem>();
        }
        IDictionary<string,string> systemParam = GetSystemParam();
        systemParam.Add(Constants.METHOD,apiCode);
        if (!string.IsNullOrEmpty(session))
        {
            systemParam.Add(Constants.SESSION,session);
        }
        string sign = TopUtils.SignTopRequest(systemParam,requestParam,appSecret,signMethod);
        systemParam.Add(Constants.SIGN,sign);
        try
        {
            if (fileParam == null || fileParam.Count <= 0)
            {
                return doPost(serverUrl, this.GetHeaderParam(), systemParam, requestParam);
            }

            return doPostWithFile(serverUrl, this.GetHeaderParam(), systemParam, requestParam, fileParam);
        }
        catch (ArgumentNullException e)
        {
            throw new TopException("The request is null.");
        }
        catch (HttpRequestException e)
        {
            throw new TopException(
                "The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.");
        }
        catch (TaskCanceledException e)
        {
            throw new TopException("The request failed due to timeout.");
        }
        catch (Exception e)
        {
            throw new TopException("The request failed :"+e.Message);
        }
        
    }

    public override string Execute(string apiCode, IDictionary<string, string> requestMap, IDictionary<string, TopFileItem> fileMap)
    {
        return Execute(apiCode, requestMap, fileMap, null);
    }

    protected Uri buildUri(string serverUrl, IDictionary<string, string> systemParam)
    {
        var uriBuilder = new UriBuilder(serverUrl);
        var param = HttpUtility.ParseQueryString(string.Empty);
        foreach (var item in systemParam)
        {
            param[item.Key] = item.Value;
        }
        uriBuilder.Query = param.ToString();
        return uriBuilder.Uri;
    }
    
    
    protected string doPost(string serverUrl,IDictionary<string, string> headerParam,  IDictionary<string, string> systemParam, IDictionary<string, string> requestParam)
    {
        var uri = buildUri(serverUrl,systemParam);
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = new FormUrlEncodedContent(requestParam)
        };
        var response = _client.SendAsync(httpRequestMessage);
        return response.Result.Content.ReadAsStringAsync().Result;
    }

    protected string doPostWithFile(string serverUrl, IDictionary<string, string> headerParam,
        IDictionary<string, string> systemParam,
        IDictionary<string, string> requestParam, IDictionary<string, TopFileItem> fileParam)
    {
        var uri = buildUri(serverUrl,systemParam);
        string boundary = DateTime.Now.Ticks.ToString("X"); // 随机分隔线
        byte[] itemBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
        byte[] endBoundaryBytes = Encoding.UTF8.GetBytes("\r\n--" + boundary + "--\r\n");
        var reqStream = new MemoryStream();
        if(requestParam != null)
        {
            // 组装文本请求参数
            string textTemplate = "Content-Disposition:form-data;name=\"{0}\"\r\nContent-Type:text/plain\r\n\r\n{1}";
            foreach (KeyValuePair<string, string> kv in requestParam)
            {
                string textEntry = string.Format(textTemplate, kv.Key, kv.Value);
                byte[] itemBytes = Encoding.UTF8.GetBytes(textEntry);
                reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
                reqStream.Write(itemBytes, 0, itemBytes.Length);
            }
        }
        // 组装文件请求参数
        string fileTemplate = "Content-Disposition:form-data;name=\"{0}\";filename=\"{1}\"\r\nContent-Type:{2}\r\n\r\n";
        foreach (KeyValuePair<string, TopFileItem> kv in fileParam)
        {
            string key = kv.Key;
            TopFileItem fileItem = kv.Value;
            if (!fileItem.IsValid())
            {
                throw new ArgumentException("FileItem is invalid");
            }
            string fileEntry = string.Format(fileTemplate, key, fileItem.GetFileName(), fileItem.GetMimeType());
            byte[] itemBytes = Encoding.UTF8.GetBytes(fileEntry);
            reqStream.Write(itemBoundaryBytes, 0, itemBoundaryBytes.Length);
            reqStream.Write(itemBytes, 0, itemBytes.Length);
            fileItem.Write(reqStream);
        }
        reqStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length);
    
        reqStream.Position = 0;
        var streamContent = new StreamContent(reqStream,Convert.ToInt32(reqStream.Length));
        streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data;charset=utf-8;boundary=" + boundary);
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = streamContent
        };
        var response = _client.SendAsync(httpRequestMessage);
        return response.Result.Content.ReadAsStringAsync().Result;
        
    }
}