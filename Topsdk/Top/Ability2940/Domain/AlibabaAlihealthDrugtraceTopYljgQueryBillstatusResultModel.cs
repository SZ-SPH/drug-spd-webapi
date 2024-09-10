using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryBillstatusResultModel
{

    /*
        返回对象
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryBillstatusPageInfoDto? model;


    /*
        状态码
    */
    private string? msgCode;


    /*
        状态值
    */
    private string? msgInfo;


    /*
        响应结果
    */
    private bool? responseSuccess;



    [JsonPropertyName("model")]
    public AlibabaAlihealthDrugtraceTopYljgQueryBillstatusPageInfoDto? Model
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

