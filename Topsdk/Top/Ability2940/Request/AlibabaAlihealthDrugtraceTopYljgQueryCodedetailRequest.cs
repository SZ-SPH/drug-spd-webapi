using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest : AbstractTopApiRequest
{

    /*
        企业唯一标识
            */
    private string? refEntId;


    /*
        码列表【多个码用逗号拼接的字符串。要求数量在1000个码以下，但一般不要传这么多，如果网络不好很容易传输一半报错】
            */
    private IList<string>? codes;


    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("codes")]
    public IList<string>? Codes
    {
        get => codes;
        set => this.codes = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.refEntId != null)
        {
            requestParam.Add("ref_ent_id",TopUtils.ConvertBasicType(this.refEntId));
        }
        if(this.codes != null)
        {
            requestParam.Add("codes",TopUtils.ConvertBasicList(this.codes));
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
        return "alibaba.alihealth.drugtrace.top.yljg.query.codedetail";
    }

}

