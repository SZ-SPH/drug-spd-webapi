using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgDrugtableResultModel
{

    /*
        返回模型
    */
    private AlibabaAlihealthDrugtraceTopYljgDrugtablePage? model;


    /*
        状态码
    */
    private string? msgCode;


    /*
        状态值
    */
    private string? msgInfo;


    /*
        是否响应成功
    */
    private bool? responseSuccess;



    [JsonPropertyName("model")]
    public AlibabaAlihealthDrugtraceTopYljgDrugtablePage? Model
    {
        get => model;
        set => this.model = value;
    }

    [JsonPropertyName("msg_code")]
    public string? MsgCode
    {
        get => msgCode;
        set => this.msgCode = value;
    }

    [JsonPropertyName("msg_info")]
    public string? MsgInfo
    {
        get => msgInfo;
        set => this.msgInfo = value;
    }

    [JsonPropertyName("response_success")]
    public bool? ResponseSuccess
    {
        get => responseSuccess;
        set => this.responseSuccess = value;
    }

}

