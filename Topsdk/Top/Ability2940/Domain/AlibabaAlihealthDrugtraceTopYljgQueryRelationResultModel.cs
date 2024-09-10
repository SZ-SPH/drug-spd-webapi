using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationResultModel
{

    /*
        model
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeRelationDto>? modelList;


    /*
        msgCode
    */
    private string? msgCode;


    /*
        msgInfo
    */
    private string? msgInfo;


    /*
        是否成功
    */
    private bool? responseSuccess;



    [JsonPropertyName("model_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeRelationDto>? ModelList
    {
        get => modelList;
        set => this.modelList = value;
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

