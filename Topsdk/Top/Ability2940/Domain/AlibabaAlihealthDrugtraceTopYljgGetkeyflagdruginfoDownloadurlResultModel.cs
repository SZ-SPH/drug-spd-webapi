using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlResultModel
{

    /*
        true：接口调用成功
    */
    private bool? success;


    /*
        返回值
    */
    private AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlJSONObject? model;


    /*
        接口调用失败具体信息
    */
    private string? msgInfo;


    /*
        接口调用失败具体code
    */
    private string? msgCode;



    [JsonPropertyName("success")]
    public bool? Success
    {
        get => success;
        set => this.success = value;
    }

    [JsonPropertyName("model")]
    public AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlJSONObject? Model
    {
        get => model;
        set => this.model = value;
    }

    [JsonPropertyName("msg_info")]
    public string? MsgInfo
    {
        get => msgInfo;
        set => this.msgInfo = value;
    }

    [JsonPropertyName("msg_code")]
    public string? MsgCode
    {
        get => msgCode;
        set => this.msgCode = value;
    }

}

