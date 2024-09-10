using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgListupoutRequest : AbstractTopApiRequest
{

    /*
        企业ID
            */
    private string? refEntId;


    /*
        开始日期（不写时分秒）
            */
    private string? beginDate;


    /*
        结束日期（不写时分秒）
            */
    private string? endDate;


    /*
        发货单位
            */
    private string? fromUserId;


    /*
        生产批号
            */
    private string? produceBatchNo;


    /*
        药品ID
            */
    private string? drugEntBaseInfoId;


    /*
        单据类型
            */
    private string? billType;


    /*
        药品类型
            */
    private string? physicType;


    /*
        状态
            */
    private string? status;


    /*
        单据号
            */
    private string? billCode;


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

    [JsonPropertyName("from_user_id")]
    public string? FromUserId
    {
        get => fromUserId;
        set => this.fromUserId = value;
    }

    [JsonPropertyName("produce_batch_no")]
    public string? ProduceBatchNo
    {
        get => produceBatchNo;
        set => this.produceBatchNo = value;
    }

    [JsonPropertyName("drug_ent_base_info_id")]
    public string? DrugEntBaseInfoId
    {
        get => drugEntBaseInfoId;
        set => this.drugEntBaseInfoId = value;
    }

    [JsonPropertyName("bill_type")]
    public string? BillType
    {
        get => billType;
        set => this.billType = value;
    }

    [JsonPropertyName("physic_type")]
    public string? PhysicType
    {
        get => physicType;
        set => this.physicType = value;
    }

    [JsonPropertyName("status")]
    public string? Status
    {
        get => status;
        set => this.status = value;
    }

    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
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
        if(this.fromUserId != null)
        {
            requestParam.Add("from_user_id",TopUtils.ConvertBasicType(this.fromUserId));
        }
        if(this.produceBatchNo != null)
        {
            requestParam.Add("produce_batch_no",TopUtils.ConvertBasicType(this.produceBatchNo));
        }
        if(this.drugEntBaseInfoId != null)
        {
            requestParam.Add("drug_ent_base_info_id",TopUtils.ConvertBasicType(this.drugEntBaseInfoId));
        }
        if(this.billType != null)
        {
            requestParam.Add("bill_type",TopUtils.ConvertBasicType(this.billType));
        }
        if(this.physicType != null)
        {
            requestParam.Add("physic_type",TopUtils.ConvertBasicType(this.physicType));
        }
        if(this.status != null)
        {
            requestParam.Add("status",TopUtils.ConvertBasicType(this.status));
        }
        if(this.billCode != null)
        {
            requestParam.Add("bill_code",TopUtils.ConvertBasicType(this.billCode));
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
        return "alibaba.alihealth.drugtrace.top.yljg.listupout";
    }

}

