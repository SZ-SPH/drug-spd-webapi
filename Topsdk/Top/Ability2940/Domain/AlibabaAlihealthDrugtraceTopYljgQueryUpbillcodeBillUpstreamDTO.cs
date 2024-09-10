using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeBillUpstreamDTO
{

    /*
        发货企业名称
    */
    private string? fromUserName;


    /*
        单据时间
    */
    private DateTime? billTime;


    /*
        货主
    */
    private string? refUserId;


    /*
        发货企业ID
    */
    private string? fromUserId;


    /*
        单据类型
    */
    private string? billType;


    /*
        收货企业名称
    */
    private string? toUserName;


    /*
        单据号
    */
    private string? billCode;


    /*
        收货企业ID
    */
    private string? toUserId;


    /*
        收货企业REF_ENT_ID
    */
    private string? toRefUserId;


    /*
        发货企业REF_ENT_ID
    */
    private string? fromRefUserId;



    [JsonPropertyName("from_user_name")]
    public string? FromUserName
    {
        get => fromUserName;
        set => this.fromUserName = value;
    }

    [JsonPropertyName("bill_time")]
    public DateTime? BillTime
    {
        get => billTime;
        set => this.billTime = value;
    }

    [JsonPropertyName("ref_user_id")]
    public string? RefUserId
    {
        get => refUserId;
        set => this.refUserId = value;
    }

    [JsonPropertyName("from_user_id")]
    public string? FromUserId
    {
        get => fromUserId;
        set => this.fromUserId = value;
    }

    [JsonPropertyName("bill_type")]
    public string? BillType
    {
        get => billType;
        set => this.billType = value;
    }

    [JsonPropertyName("to_user_name")]
    public string? ToUserName
    {
        get => toUserName;
        set => this.toUserName = value;
    }

    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
    }

    [JsonPropertyName("to_user_id")]
    public string? ToUserId
    {
        get => toUserId;
        set => this.toUserId = value;
    }

    [JsonPropertyName("to_ref_user_id")]
    public string? ToRefUserId
    {
        get => toRefUserId;
        set => this.toRefUserId = value;
    }

    [JsonPropertyName("from_ref_user_id")]
    public string? FromRefUserId
    {
        get => fromRefUserId;
        set => this.fromRefUserId = value;
    }

}

