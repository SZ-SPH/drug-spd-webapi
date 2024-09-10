using Topsdk.Util;

namespace Topsdk.Top;

public interface ITopApiClient
{
    /// <summary>
    /// 初始化sdk
    /// </summary>
    public void Init();
    
    /// <summary>
    /// 请求api，包含sessionKey
    /// </summary>
    /// <param name="apiCode"></param>
    /// <param name="requestMap"></param>
    /// <param name="fileMap"></param>
    /// <param name="session"></param>
    /// <returns></returns>
    public string Execute(string apiCode,IDictionary<string,string> requestMap, IDictionary<string,TopFileItem> fileMap, string session);
    
    /// <summary>
    /// 请求api
    /// </summary>
    /// <param name="apiCode"></param>
    /// <param name="requestMap"></param>
    /// <param name="fileMap"></param>
    /// <returns></returns>
    public string Execute(string apiCode,IDictionary<string,string> requestMap, IDictionary<string,TopFileItem> fileMap);

}