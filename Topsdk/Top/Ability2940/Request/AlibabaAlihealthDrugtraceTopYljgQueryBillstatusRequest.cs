using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgQueryBillstatusRequest : AbstractTopApiRequest
{

    /*
        企业ID
            */
    private string? refEntId;


    /*
        开始日期（没有时分秒，【单据创建时间】）
            */
    private string? beginDate;


    /*
        结束日期（没有时分秒，【单据创建时间】）
            */
    private string? endDate;


    /*
        单据类型 A：全部 AI：全部入库 AO：全部出库
            */
    private string? billType;


    /*
        单据号
            */
    private string? billCode;


    /*
        药品类型
            */
    private string? drugType;


    /*
        状态  0, 上传成功     3, 处理成功     4, 处理失败
            */
    private string? dealStatus;


    /*
        发货商
            */
    private string? fromUserId;


    /*
        收货商
            */
    private string? toUserId;


    /*
        代理商
            */
    private string? agentRefUserId;


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

    [JsonPropertyName("bill_type")]
    public string? BillType
    {
        get => billType;
        set => this.billType = value;
    }

    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
    }

    [JsonPropertyName("drug_type")]
    public string? DrugType
    {
        get => drugType;
        set => this.drugType = value;
    }

    [JsonPropertyName("deal_status")]
    public string? DealStatus
    {
        get => dealStatus;
        set => this.dealStatus = value;
    }

    [JsonPropertyName("from_user_id")]
    public string? FromUserId
    {
        get => fromUserId;
        set => this.fromUserId = value;
    }

    [JsonPropertyName("to_user_id")]
    public string? ToUserId
    {
        get => toUserId;
        set => this.toUserId = value;
    }

    [JsonPropertyName("agent_ref_user_id")]
    public string? AgentRefUserId
    {
        get => agentRefUserId;
        set => this.agentRefUserId = value;
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
        if(this.beginDate != null)
        {
            requestParam.Add("begin_date",TopUtils.ConvertBasicType(this.beginDate));
        }
        if(this.endDate != null)
        {
            requestParam.Add("end_date",TopUtils.ConvertBasicType(this.endDate));
        }
        if(this.billType != null)
        {
            requestParam.Add("bill_type",TopUtils.ConvertBasicType(this.billType));
        }
        if(this.billCode != null)
        {
            requestParam.Add("bill_code",TopUtils.ConvertBasicType(this.billCode));
        }
        if(this.drugType != null)
        {
            requestParam.Add("drug_type",TopUtils.ConvertBasicType(this.drugType));
        }
        if(this.dealStatus != null)
        {
            requestParam.Add("deal_status",TopUtils.ConvertBasicType(this.dealStatus));
        }
        if(this.fromUserId != null)
        {
            requestParam.Add("from_user_id",TopUtils.ConvertBasicType(this.fromUserId));
        }
        if(this.toUserId != null)
        {
            requestParam.Add("to_user_id",TopUtils.ConvertBasicType(this.toUserId));
        }
        if(this.agentRefUserId != null)
        {
            requestParam.Add("agent_ref_user_id",TopUtils.ConvertBasicType(this.agentRefUserId));
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
        return "alibaba.alihealth.drugtrace.top.yljg.query.billstatus";
    }

}

