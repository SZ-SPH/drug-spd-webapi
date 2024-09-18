using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgListupoutDetailRequest : AbstractTopApiRequest
{

    /*
        企业id
            */
    private string? refEntId;


    /*
        单据编码
            */
    private string? billCode;


    /*
        发货企业renEntId
            */
    private string? fromRefUserId;


    /*
        收货企业refEntId
            */
    private string? toRefUserId;


    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
    }

    [JsonPropertyName("from_ref_user_id")]
    public string? FromRefUserId
    {
        get => fromRefUserId;
        set => this.fromRefUserId = value;
    }

    [JsonPropertyName("to_ref_user_id")]
    public string? ToRefUserId
    {
        get => toRefUserId;
        set => this.toRefUserId = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.refEntId != null)
        {
            requestParam.Add("ref_ent_id",TopUtils.ConvertBasicType(this.refEntId));
        }
        if(this.billCode != null)
        {
            requestParam.Add("bill_code",TopUtils.ConvertBasicType(this.billCode));
        }
        if(this.fromRefUserId != null)
        {
            requestParam.Add("from_ref_user_id",TopUtils.ConvertBasicType(this.fromRefUserId));
        }
        if(this.toRefUserId != null)
        {
            requestParam.Add("to_ref_user_id",TopUtils.ConvertBasicType(this.toRefUserId));
        }
        return requestParam;
    }

    public override IDictionary<string, TopFileItem> ToFileParam()
    {
        IDictionary<string, TopFileItem> fileParam = new Dictionary<string, TopFileItem>();
        return fileParam;
    }

    public override string GetApiCode()
    {
        return "alibaba.alihealth.drugtrace.top.yljg.listupout.detail";
    }

}

