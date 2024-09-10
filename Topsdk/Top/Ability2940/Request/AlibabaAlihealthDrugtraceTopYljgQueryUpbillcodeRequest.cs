using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeRequest : AbstractTopApiRequest
{

    /*
        追溯码
            */
    private string? code;


    /*
        企业ID （一般为要查询单据的收货企业）
            */
    private string? refEntId;


    [JsonPropertyName("code")]
    public string? Code
    {
        get => code;
        set => this.code = value;
    }

    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.code != null)
        {
            requestParam.Add("code",TopUtils.ConvertBasicType(this.code));
        }
        if(this.refEntId != null)
        {
            requestParam.Add("ref_ent_id",TopUtils.ConvertBasicType(this.refEntId));
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
        return "alibaba.alihealth.drugtrace.top.yljg.query.upbillcode";
    }

}

