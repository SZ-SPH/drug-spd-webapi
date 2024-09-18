using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationRequest : AbstractTopApiRequest
{

    /*
        接口调用企业的唯一标识（接口调用者）
            */
    private string? refEntId;


    /*
        追溯码
            */
    private string? code;


    /*
        目标企业唯一标识（为哪个企业查询，一般与入参ref_ent_id一样）
            */
    private string? desRefEntId;


    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("code")]
    public string? Code
    {
        get => code;
        set => this.code = value;
    }

    [JsonPropertyName("des_ref_ent_id")]
    public string? DesRefEntId
    {
        get => desRefEntId;
        set => this.desRefEntId = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.refEntId != null)
        {
            requestParam.Add("ref_ent_id",TopUtils.ConvertBasicType(this.refEntId));
        }
        if(this.code != null)
        {
            requestParam.Add("code",TopUtils.ConvertBasicType(this.code));
        }
        if(this.desRefEntId != null)
        {
            requestParam.Add("des_ref_ent_id",TopUtils.ConvertBasicType(this.desRefEntId));
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
        return "alibaba.alihealth.drugtrace.top.yljg.query.relation";
    }

}

