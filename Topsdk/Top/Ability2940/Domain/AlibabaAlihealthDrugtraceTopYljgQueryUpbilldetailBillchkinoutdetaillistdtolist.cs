using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailBillchkinoutdetaillistdtolist
{

    /*
        有效期至
    */
    private string? expiredDate;


    /*
        生产企业名称
    */
    private string? produceEntName;


    /*
        子类编码
    */
    private string? prodCode;


    /*
        子类编码前7位
    */
    private string? productCode;


    /*
        生产日期
    */
    private string? produceDate;


    /*
        批次号
    */
    private string? productBatchNo;


    /*
        药品id
    */
    private string? drugEntBaseInfoId;


    /*
        药品名称
    */
    private string? physicName;


    /*
        制剂单位
    */
    private string? preparationsUnit;


    /*
        包装规格
    */
    private string? tempPkgSpec;


    /*
        最小制剂数量
    */
    private string? minPreparationsCount;


    /*
        最小包装数量
    */
    private string? minPkgCount;


    /*
        药品类型名称
    */
    private string? physicTypeName;


    /*
        药品类型编码
    */
    private string? physicType;


    /*
        码列表（预留属性，暂无返回）
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailCodeandparentlist>? codeAndParentList;


    /*
        国药准字
    */
    private string? approveNo;



    [JsonPropertyName("expired_date")]
    public string? ExpiredDate
    {
        get => expiredDate;
        set => this.expiredDate = value;
    }

    [JsonPropertyName("produce_ent_name")]
    public string? ProduceEntName
    {
        get => produceEntName;
        set => this.produceEntName = value;
    }

    [JsonPropertyName("prod_code")]
    public string? ProdCode
    {
        get => prodCode;
        set => this.prodCode = value;
    }

    [JsonPropertyName("product_code")]
    public string? ProductCode
    {
        get => productCode;
        set => this.productCode = value;
    }

    [JsonPropertyName("produce_date")]
    public string? ProduceDate
    {
        get => produceDate;
        set => this.produceDate = value;
    }

    [JsonPropertyName("product_batch_no")]
    public string? ProductBatchNo
    {
        get => productBatchNo;
        set => this.productBatchNo = value;
    }

    [JsonPropertyName("drug_ent_base_info_id")]
    public string? DrugEntBaseInfoId
    {
        get => drugEntBaseInfoId;
        set => this.drugEntBaseInfoId = value;
    }

    [JsonPropertyName("physic_name")]
    public string? PhysicName
    {
        get => physicName;
        set => this.physicName = value;
    }

    [JsonPropertyName("preparations_unit")]
    public string? PreparationsUnit
    {
        get => preparationsUnit;
        set => this.preparationsUnit = value;
    }

    [JsonPropertyName("temp_pkg_spec")]
    public string? TempPkgSpec
    {
        get => tempPkgSpec;
        set => this.tempPkgSpec = value;
    }

    [JsonPropertyName("min_preparations_count")]
    public string? MinPreparationsCount
    {
        get => minPreparationsCount;
        set => this.minPreparationsCount = value;
    }

    [JsonPropertyName("min_pkg_count")]
    public string? MinPkgCount
    {
        get => minPkgCount;
        set => this.minPkgCount = value;
    }

    [JsonPropertyName("physic_type_name")]
    public string? PhysicTypeName
    {
        get => physicTypeName;
        set => this.physicTypeName = value;
    }

    [JsonPropertyName("physic_type")]
    public string? PhysicType
    {
        get => physicType;
        set => this.physicType = value;
    }

    [JsonPropertyName("code_and_parent_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailCodeandparentlist>? CodeAndParentList
    {
        get => codeAndParentList;
        set => this.codeAndParentList = value;
    }

    [JsonPropertyName("approve_no")]
    public string? ApproveNo
    {
        get => approveNo;
        set => this.approveNo = value;
    }

}

