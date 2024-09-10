using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgQueryListpartsRequest : AbstractTopApiRequest
{

    /*
        企业唯一标识
            */
    private string? refEntId;


    /*
        企业名称
            */
    private string? entName;


    /*
        企业自定义编号
            */
    private string? refPartnerId;


    /*
        开始时间
            */
    private string? beginDate;


    /*
        结束时间
            */
    private string? endDate;


    /*
        页大小
            */
    private long? pageSize;


    /*
        页码
            */
    private long? page;


    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("ent_name")]
    public string? EntName
    {
        get => entName;
        set => this.entName = value;
    }

    [JsonPropertyName("ref_partner_id")]
    public string? RefPartnerId
    {
        get => refPartnerId;
        set => this.refPartnerId = value;
    }

    [JsonPropertyName("begin_date")]
    public string? BeginDate
    {
        get => beginDate;
        set => this.beginDate = value;
    }

    [JsonPropertyName("end_date")]
    public string? EndDate
    {
        get => endDate;
        set => this.endDate = value;
    }

    [JsonPropertyName("page_size")]
    public long? PageSize
    {
        get => pageSize;
        set => this.pageSize = value;
    }

    [JsonPropertyName("page")]
    public long? Page
    {
        get => page;
        set => this.page = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.refEntId != null)
        {
            requestParam.Add("ref_ent_id",TopUtils.ConvertBasicType(this.refEntId));
        }
        if(this.entName != null)
        {
            requestParam.Add("ent_name",TopUtils.ConvertBasicType(this.entName));
        }
        if(this.refPartnerId != null)
        {
            requestParam.Add("ref_partner_id",TopUtils.ConvertBasicType(this.refPartnerId));
        }
        if(this.beginDate != null)
        {
            requestParam.Add("begin_date",TopUtils.ConvertBasicType(this.beginDate));
        }
        if(this.endDate != null)
        {
            requestParam.Add("end_date",TopUtils.ConvertBasicType(this.endDate));
        }
        if(this.pageSize != null)
        {
            requestParam.Add("page_size",TopUtils.ConvertBasicType(this.pageSize));
        }
        if(this.page != null)
        {
            requestParam.Add("page",TopUtils.ConvertBasicType(this.page));
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
        return "alibaba.alihealth.drugtrace.top.yljg.query.listparts";
    }

}

