using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgServiceGetenddateRequest : AbstractTopApiRequest
{

    /*
        调用接口的企业ID
            */
    private string? refEntId;


    /*
        药 行业线：传 1 
            */
    private long? business;


    /*
        基础版：传 11
            */
    private long? service;


    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("business")]
    public long? Business
    {
        get => business;
        set => this.business = value;
    }

    [JsonPropertyName("service")]
    public long? Service
    {
        get => service;
        set => this.service = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.refEntId != null)
        {
            requestParam.Add("ref_ent_id",TopUtils.ConvertBasicType(this.refEntId));
        }
        if(this.business != null)
        {
            requestParam.Add("business",TopUtils.ConvertBasicType(this.business));
        }
        if(this.service != null)
        {
            requestParam.Add("service",TopUtils.ConvertBasicType(this.service));
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
        return "alibaba.alihealth.drugtrace.top.yljg.service.getenddate";
    }

}

