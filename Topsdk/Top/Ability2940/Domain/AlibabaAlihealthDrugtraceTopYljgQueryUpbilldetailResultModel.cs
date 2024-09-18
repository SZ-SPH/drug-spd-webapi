using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailResultModel
{

    /*
        对象模型信息
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailBillInOutDetailDto? model;


    /*
        消息码
    */
    private string? msgCode;


    /*
        消息
    */
    private string? msgInfo;


    /*
        成功失败
    */
    private bool? responseSuccess;



    [JsonPropertyName("model")]
    public AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailBillInOutDetailDto? Model
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

