using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgListupoutDetailResultModel
{

    /*
        最外层对象
    */
    private AlibabaAlihealthDrugtraceTopYljgListupoutDetailBillUpOutDetailDto? model;


    /*
        提示信息编码
    */
    private string? msgCode;


    /*
        提示信息内容
    */
    private string? msgInfo;


    /*
        成功失败标记
    */
    private bool? success;



    [JsonPropertyName("model")]
    public AlibabaAlihealthDrugtraceTopYljgListupoutDetailBillUpOutDetailDto? Model
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

    [JsonPropertyName("success")]
    public bool? Success
    {
        get => success;
        set => this.success = value;
    }

}

