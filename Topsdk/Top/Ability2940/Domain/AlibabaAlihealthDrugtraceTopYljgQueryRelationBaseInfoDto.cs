using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationBaseInfoDto
{

    /*
        药品信息
    */
    private string? physicInfo;


    /*
        企业id
    */
    private string? refEntId;


    /*
        药品包装规格
    */
    private string? pkgSpec;


    /*
        药品制剂规格
    */
    private string? prepnSpec;


    /*
        药品制剂类型
    */
    private string? prepnType;


    /*
        药品通用名称
    */
    private string? physicName;


    /*
        药品包装比例
    */
    private string? pkgRatio;


    /*
        药品有效期至
    */
    private string? exprieDate;


    /*
        药品生产批次号
    */
    private string? produceBatchNo;


    /*
        药品生产日期
    */
    private string? produceDate;


    /*
        药品自类编码
    */
    private string? subTypeNo;


    /*
        药品编号
    */
    private string? productCode;


    /*
        药品ID
    */
    private string? prodId;


    /*
        批准文号
    */
    private string? approveNo;


    /*
        药品类型
    */
    private string? physicType;



    [JsonPropertyName("physic_info")]
    public string? PhysicInfo
    {
        get => physicInfo;
        set => this.physicInfo = value;
    }

    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("pkg_spec")]
    public string? PkgSpec
    {
        get => pkgSpec;
        set => this.pkgSpec = value;
    }

    [JsonPropertyName("prepn_spec")]
    public string? PrepnSpec
    {
        get => prepnSpec;
        set => this.prepnSpec = value;
    }

    [JsonPropertyName("prepn_type")]
    public string? PrepnType
    {
        get => prepnType;
        set => this.prepnType = value;
    }

    [JsonPropertyName("physic_name")]
    public string? PhysicName
    {
        get => physicName;
        set => this.physicName = value;
    }

    [JsonPropertyName("pkg_ratio")]
    public string? PkgRatio
    {
        get => pkgRatio;
        set => this.pkgRatio = value;
    }

    [JsonPropertyName("exprie_date")]
    public string? ExprieDate
    {
        get => exprieDate;
        set => this.exprieDate = value;
    }

    [JsonPropertyName("produce_batch_no")]
    public string? ProduceBatchNo
    {
        get => produceBatchNo;
        set => this.produceBatchNo = value;
    }

    [JsonPropertyName("produce_date")]
    public string? ProduceDate
    {
        get => produceDate;
        set => this.produceDate = value;
    }

    [JsonPropertyName("sub_type_no")]
    public string? SubTypeNo
    {
        get => subTypeNo;
        set => this.subTypeNo = value;
    }

    [JsonPropertyName("product_code")]
    public string? ProductCode
    {
        get => productCode;
        set => this.productCode = value;
    }

    [JsonPropertyName("prod_id")]
    public string? ProdId
    {
        get => prodId;
        set => this.prodId = value;
    }

    [JsonPropertyName("approve_no")]
    public string? ApproveNo
    {
        get => approveNo;
        set => this.approveNo = value;
    }

    [JsonPropertyName("physic_type")]
    public string? PhysicType
    {
        get => physicType;
        set => this.physicType = value;
    }

}

