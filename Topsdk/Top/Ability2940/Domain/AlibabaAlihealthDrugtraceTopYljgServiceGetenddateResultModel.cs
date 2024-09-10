using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgServiceGetenddateResultModel
{

    /*
        true：接口调用成功
    */
    private bool? success;


    /*
        服务截止时间
    */
    private string? endDate;


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

    [JsonPropertyName("end_date")]
    public string? EndDate
    {
        get => endDate;
        set => this.endDate = value;
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

