using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentidRequest : AbstractTopApiRequest
{

    /*
        接口调用企业的唯一标识（接口调用者）
            */
    private string? refEntId;


    /*
        准备要查询的企业唯一标识（返回该唯一标识企业的详细信息）
            */
    private string? destRefEntId;


    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("dest_ref_ent_id")]
    public string? DestRefEntId
    {
        get => destRefEntId;
        set => this.destRefEntId = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.refEntId != null)
        {
            requestParam.Add("ref_ent_id",TopUtils.ConvertBasicType(this.refEntId));
        }
        if(this.destRefEntId != null)
        {
            requestParam.Add("dest_ref_ent_id",TopUtils.ConvertBasicType(this.destRefEntId));
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
        return "alibaba.alihealth.drugtrace.top.yljg.query.getbyrefentid";
    }

}

