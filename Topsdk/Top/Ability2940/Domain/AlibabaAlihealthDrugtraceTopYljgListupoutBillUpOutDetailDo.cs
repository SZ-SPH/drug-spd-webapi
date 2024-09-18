using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgListupoutBillUpOutDetailDo
{

    /*
        发货单位
    */
    private string? fromEntName;


    /*
        最小码量
    */
    private long? codeCount;


    /*
        失效日期
    */
    private string? exprieDate;


    /*
        厂商
    */
    private string? produceEntName;


    /*
        生产日期
    */
    private string? produceDate;


    /*
        生产批号
    */
    private string? produceBatchNo;


    /*
        包装规格
    */
    private string? pkgSpec;


    /*
        药品信息
    */
    private string? physicInfo;


    /*
        药品名称
    */
    private string? physicName;


    /*
        制剂数量
    */
    private long? prepnCount;


    /*
        发货单位REF_ENT_ID
    */
    private string? fromRefUserId;


    /*
        收货单位REF_ENT_ID
    */
    private string? toRefUserId;


    /*
        单据时间
    */
    private string? billTime;


    /*
        单据码
    */
    private string? billCode;


    /*
        单据类型
    */
    private string? billType;


    /*
        发货企业
    */
    private string? toUserName;


    /*
        收货企业
    */
    private string? fromUserName;


    /*
        失效日期格式化
    */
    private string? exprieDateFormat;


    /*
        单据时间格式化
    */
    private string? billTimeFormat;


    /*
        单据ID
    */
    private long? billOutId;


    /*
        制剂单位
    */
    private long? prepnUnit;


    /*
        制剂规格
    */
    private string? prepnSpec;


    /*
        药品ID
    */
    private string? drugEntBaseInfoId;


    /*
        生产日期格式化
    */
    private string? produceDateFormat;


    /*
        确认状态1未确认2已确认
    */
    private string? status;


    /*
        收货企业ent_id
    */
    private string? toUserId;


    /*
        发货企业ent_id
    */
    private string? fromUserId;



    [JsonPropertyName("from_ent_name")]
    public string? FromEntName
    {
        get => fromEntName;
        set => this.fromEntName = value;
    }

    [JsonPropertyName("code_count")]
    public long? CodeCount
    {
        get => codeCount;
        set => this.codeCount = value;
    }

    [JsonPropertyName("exprie_date")]
    public string? ExprieDate
    {
        get => exprieDate;
        set => this.exprieDate = value;
    }

    [JsonPropertyName("produce_ent_name")]
    public string? ProduceEntName
    {
        get => produceEntName;
        set => this.produceEntName = value;
    }

    [JsonPropertyName("produce_date")]
    public string? ProduceDate
    {
        get => produceDate;
        set => this.produceDate = value;
    }

    [JsonPropertyName("produce_batch_no")]
    public string? ProduceBatchNo
    {
        get => produceBatchNo;
        set => this.produceBatchNo = value;
    }

    [JsonPropertyName("pkg_spec")]
    public string? PkgSpec
    {
        get => pkgSpec;
        set => this.pkgSpec = value;
    }

    [JsonPropertyName("physic_info")]
    public string? PhysicInfo
    {
        get => physicInfo;
        set => this.physicInfo = value;
    }

    [JsonPropertyName("physic_name")]
    public string? PhysicName
    {
        get => physicName;
        set => this.physicName = value;
    }

    [JsonPropertyName("prepn_count")]
    public long? PrepnCount
    {
        get => prepnCount;
        set => this.prepnCount = value;
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

    [JsonPropertyName("bill_time")]
    public string? BillTime
    {
        get => billTime;
        set => this.billTime = value;
    }

    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
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

    [JsonPropertyName("from_user_name")]
    public string? FromUserName
    {
        get => fromUserName;
        set => this.fromUserName = value;
    }

    [JsonPropertyName("exprie_date_format")]
    public string? ExprieDateFormat
    {
        get => exprieDateFormat;
        set => this.exprieDateFormat = value;
    }

    [JsonPropertyName("bill_time_format")]
    public string? BillTimeFormat
    {
        get => billTimeFormat;
        set => this.billTimeFormat = value;
    }

    [JsonPropertyName("bill_out_id")]
    public long? BillOutId
    {
        get => billOutId;
        set => this.billOutId = value;
    }

    [JsonPropertyName("prepn_unit")]
    public long? PrepnUnit
    {
        get => prepnUnit;
        set => this.prepnUnit = value;
    }

    [JsonPropertyName("prepn_spec")]
    public string? PrepnSpec
    {
        get => prepnSpec;
        set => this.prepnSpec = value;
    }

    [JsonPropertyName("drug_ent_base_info_id")]
    public string? DrugEntBaseInfoId
    {
        get => drugEntBaseInfoId;
        set => this.drugEntBaseInfoId = value;
    }

    [JsonPropertyName("produce_date_format")]
    public string? ProduceDateFormat
    {
        get => produceDateFormat;
        set => this.produceDateFormat = value;
    }

    [JsonPropertyName("status")]
    public string? Status
    {
        get => status;
        set => this.status = value;
    }

    [JsonPropertyName("to_user_id")]
    public string? ToUserId
    {
        get => toUserId;
        set => this.toUserId = value;
    }

    [JsonPropertyName("from_user_id")]
    public string? FromUserId
    {
        get => fromUserId;
        set => this.fromUserId = value;
    }

}

