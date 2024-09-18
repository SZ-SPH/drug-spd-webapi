using System.Net;
using Topsdk.Util;

namespace Topsdk.Top;

public abstract class AbstractTopApiClient:ITopApiClient
{
    protected string appkey = "";

    protected string appSecret = "";

    protected string serverUrl = "";

    protected string format = "json";

    protected string signMethod = "hmac-sha256";

    protected long connectTimeOut = 15000L;

    protected long totalTimeout = 30000L;

    protected string version = "2.0";

    protected bool simplify = true;

    protected bool enableLogger = true;
    
    protected bool ignoreSsl = true;

    protected IWebProxy? proxy;
    
    
    /// <summary>
    /// 初始化sdk
    /// </summary>
    public abstract void Init();
    
    /// <summary>
    /// 请求api，包含sessionKey
    /// </summary>
    /// <param name="apiCode"></param>
    /// <param name="requestMap"></param>
    /// <param name="fileMap"></param>
    /// <param name="session"></param>
    /// <returns></returns>
    public abstract string Execute(string apiCode,IDictionary<string,string> requestMap, IDictionary<string,TopFileItem> fileMap, string session);
    
    /// <summary>
    /// 请求api
    /// </summary>
    /// <param name="apiCode"></param>
    /// <param name="requestMap"></param>
    /// <param name="fileMap"></param>
    /// <returns></returns>
    public abstract string Execute(string apiCode,IDictionary<string,string> requestMap, IDictionary<string,TopFileItem> fileMap);


    public IDictionary<string, string> GetSystemParam()
    {
        IDictionary<string, string> systemParam = new Dictionary<string, string>();
        systemParam.Add(Constants.APP_KEY,this.appkey);
        systemParam.Add(Constants.TIMESTAMP,DateTime.Now.ToString(Constants.DATE_TIME_FORMAT));
        systemParam.Add(Constants.VERSION,this.version);
        systemParam.Add(Constants.SIGN_METHOD,this.signMethod);
        systemParam.Add(Constants.FORMAT,this.format);
        systemParam.Add(Constants.SIMPLIFY,simplify.ToString().ToLower());
        systemParam.Add(Constants.PARTNER_ID,Constants.SDK_VERSION);
        return systemParam;
    }
    
    public IDictionary<string, string> GetHeaderParam()
    {
        IDictionary<string, string> headerParam = new Dictionary<string, string>();
        return headerParam;
    }

    public string Appkey
    {
        get => appkey;
        set => appkey = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string AppSecret
    {
        get => appSecret;
        set => appSecret = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string ServerUrl
    {
        get => serverUrl;
        set => serverUrl = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Format
    {
        get => format;
        set => format = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string SignMethod
    {
        get => signMethod;
        set => signMethod = value ?? throw new ArgumentNullException(nameof(value));
    }

    public long ConnectTimeOut
    {
        get => connectTimeOut;
        set => connectTimeOut = value;
    }

    public long TotalTimeout
    {
        get => totalTimeout;
        set => totalTimeout = value;
    }

    public string Version
    {
        get => version;
        set => version = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool Simplify
    {
        get => simplify;
        set => simplify = value;
    }

    public bool EnableLogger
    {
        get => enableLogger;
        set => enableLogger = value;
    }

    public IWebProxy Proxy
    {
        get => proxy;
        set => proxy = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool IgnoreSsl
    {
        get => ignoreSsl;
        set => ignoreSsl = value;
    }
}