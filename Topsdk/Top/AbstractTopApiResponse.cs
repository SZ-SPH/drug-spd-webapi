using System.Text.Json.Serialization;

namespace Topsdk.Top;

public abstract class AbstractTopApiResponse
{
   
    protected int? topCode;
    
    protected string? msg;
    
    protected string? subCode;

    
    protected string? subMsg;

   
    protected string? requestId;

    [JsonIgnore]
    protected string? body;

   
    public bool isSuccess()
    {
        return (this.topCode == null || this.topCode.Equals(0))
               && string.IsNullOrEmpty(this.subCode);
    }

    [JsonPropertyName("code")]
    public int? TopCode
    {
        get => topCode;
        set => topCode = value;
    }

    [JsonPropertyName("msg")]
    public string? Msg
    {
        get => msg;
        set => msg = value;
    }

    [JsonPropertyName("sub_code")]
    public string? SubCode
    {
        get => subCode;
        set => subCode = value;
    }

    [JsonPropertyName("sub_msg")]
    public string? SubMsg
    {
        get => subMsg;
        set => subMsg = value;
    }

    [JsonPropertyName("request_id")]
    public string? RequestId
    {
        get => requestId;
        set => requestId = value;
    }

    [JsonIgnore]
    public string? Body
    {
        get => body;
        set => body = value;
    }
}