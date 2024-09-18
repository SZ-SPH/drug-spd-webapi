using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeResult
{

    /*
        是否成功
    */
    private bool? success;


    /*
        model
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeBillUpstreamDTO>? modelList;


    /*
        msgInfo
    */
    private string? msgInfo;


    /*
        msgCode
    */
    private string? msgCode;



    [JsonPropertyName("success")]
    public bool? Success
    {
        get => success;
        set => this.success = value;
    }

    [JsonPropertyName("model_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeBillUpstreamDTO>? ModelList
    {
        get => modelList;
        set => this.modelList = value;
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

