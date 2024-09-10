using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResultModel
{

    /*
        内层大对象
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeFullInfoDto>? models;


    /*
        消息码
    */
    private string? msgCode;


    /*
        消息提示内容
    */
    private string? msgInfo;


    /*
        查询成功失败标记
    */
    private bool? responseSuccess;



    [JsonPropertyName("models")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeFullInfoDto>? Models
    {
        get => models;
        set => this.models = value;
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

