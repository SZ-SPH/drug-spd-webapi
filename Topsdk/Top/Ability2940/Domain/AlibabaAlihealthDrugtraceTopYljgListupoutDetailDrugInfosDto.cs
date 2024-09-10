using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgListupoutDetailDrugInfosDto
{

    /*
        生产日期
    */
    private string? produceDate;


    /*
        生产企业名称
    */
    private string? productEntName;


    /*
        产品包装规格
    */
    private string? packageSpec;


    /*
        药品商品名
    */
    private string? prodName;


    /*
        药品通用名
    */
    private string? physicName;


    /*
        制剂规格
    */
    private string? prepnSpec;


    /*
        制剂单位编码
    */
    private string? prepnUnit;


    /*
        批次号
    */
    private string? produceBatchNo;


    /*
        药品标识
    */
    private string? prodSeqNo;


    /*
        药品标识
    */
    private string? drugEntBaseInfoId;


    /*
        有效期至
    */
    private string? validEndDate;


    /*
        按最小包装单位统计数量
    */
    private string? leastPkgAmount;


    /*
        按最小制剂单位统计数量
    */
    private string? leastPrepnAmount;


    /*
        批准文号
    */
    private string? approvalNo;


    /*
        药品类型
    */
    private string? physicType;


    /*
        药品类型描述
    */
    private string? physicTypeName;


    /*
        制剂单位
    */
    private string? preparationsUnit;


    /*
        制剂规格描述
    */
    private string? prepnTypeDesc;


    /*
        码信息
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgListupoutDetailCodeInfoListDto>? codeInfoListDtoList;



    [JsonPropertyName("produce_date")]
    public string? ProduceDate
    {
        get => produceDate;
        set => this.produceDate = value;
    }

    [JsonPropertyName("product_ent_name")]
    public string? ProductEntName
    {
        get => productEntName;
        set => this.productEntName = value;
    }

    [JsonPropertyName("package_spec")]
    public string? PackageSpec
    {
        get => packageSpec;
        set => this.packageSpec = value;
    }

    [JsonPropertyName("prod_name")]
    public string? ProdName
    {
        get => prodName;
        set => this.prodName = value;
    }

    [JsonPropertyName("physic_name")]
    public string? PhysicName
    {
        get => physicName;
        set => this.physicName = value;
    }

    [JsonPropertyName("prepn_spec")]
    public string? PrepnSpec
    {
        get => prepnSpec;
        set => this.prepnSpec = value;
    }

    [JsonPropertyName("prepn_unit")]
    public string? PrepnUnit
    {
        get => prepnUnit;
        set => this.prepnUnit = value;
    }

    [JsonPropertyName("produce_batch_no")]
    public string? ProduceBatchNo
    {
        get => produceBatchNo;
        set => this.produceBatchNo = value;
    }

    [JsonPropertyName("prod_seq_no")]
    public string? ProdSeqNo
    {
        get => prodSeqNo;
        set => this.prodSeqNo = value;
    }

    [JsonPropertyName("drug_ent_base_info_id")]
    public string? DrugEntBaseInfoId
    {
        get => drugEntBaseInfoId;
        set => this.drugEntBaseInfoId = value;
    }

    [JsonPropertyName("valid_end_date")]
    public string? ValidEndDate
    {
        get => validEndDate;
        set => this.validEndDate = value;
    }

    [JsonPropertyName("least_pkg_amount")]
    public string? LeastPkgAmount
    {
        get => leastPkgAmount;
        set => this.leastPkgAmount = value;
    }

    [JsonPropertyName("least_prepn_amount")]
    public string? LeastPrepnAmount
    {
        get => leastPrepnAmount;
        set => this.leastPrepnAmount = value;
    }

    [JsonPropertyName("approval_no")]
    public string? ApprovalNo
    {
        get => approvalNo;
        set => this.approvalNo = value;
    }

    [JsonPropertyName("physic_type")]
    public string? PhysicType
    {
        get => physicType;
        set => this.physicType = value;
    }

    [JsonPropertyName("physic_type_name")]
    public string? PhysicTypeName
    {
        get => physicTypeName;
        set => this.physicTypeName = value;
    }

    [JsonPropertyName("preparations_unit")]
    public string? PreparationsUnit
    {
        get => preparationsUnit;
        set => this.preparationsUnit = value;
    }

    [JsonPropertyName("prepn_type_desc")]
    public string? PrepnTypeDesc
    {
        get => prepnTypeDesc;
        set => this.prepnTypeDesc = value;
    }

    [JsonPropertyName("code_info_list_dto_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgListupoutDetailCodeInfoListDto>? CodeInfoListDtoList
    {
        get => codeInfoListDtoList;
        set => this.codeInfoListDtoList = value;
    }

}

