using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgGetdruglistDrugDetailInfoDto
{

    /*
        药品类型(详见码表) 1：特殊药品原料药，2：特殊药品制剂，3：普通药品，9：未分类
    */
    private string? physicType;


    /*
        药品通用名称
    */
    private string? physicName;


    /*
        药品子类编码
    */
    private string? prodCode;


    /*
        药品详细类型
    */
    private string? physicDetailType;


    /*
        企业id
    */
    private string? produceRefEntId;


    /*
        商品名称
    */
    private string? prodName;


    /*
        修改日期
    */
    private string? modDate;


    /*
        生产厂企业名称
    */
    private string? produceEntName;


    /*
        制剂单位类型(详见码表)  赋码最小包装内使用单元单位
    */
    private string? prepnUnit;


    /*
        制剂规格
    */
    private string? prepnSpec;


    /*
        批准文号
    */
    private string? approveNo;


    /*
        包装单位
    */
    private string? pkgUnit;


    /*
        药品id
    */
    private string? drugEntBaseInfoId;


    /*
        制剂单位描述
    */
    private string? prepnUnitDesc;


    /*
        包装规格
    */
    private string? pkgSpec;


    /*
        包装单位描述
    */
    private string? pkgUnitDesc;


    /*
        药品信息
    */
    private string? physicInfo;



    [JsonPropertyName("physic_type")]
    public string? PhysicType
    {
        get => physicType;
        set => this.physicType = value;
    }

    [JsonPropertyName("physic_name")]
    public string? PhysicName
    {
        get => physicName;
        set => this.physicName = value;
    }

    [JsonPropertyName("prod_code")]
    public string? ProdCode
    {
        get => prodCode;
        set => this.prodCode = value;
    }

    [JsonPropertyName("physic_detail_type")]
    public string? PhysicDetailType
    {
        get => physicDetailType;
        set => this.physicDetailType = value;
    }

    [JsonPropertyName("produce_ref_ent_id")]
    public string? ProduceRefEntId
    {
        get => produceRefEntId;
        set => this.produceRefEntId = value;
    }

    [JsonPropertyName("prod_name")]
    public string? ProdName
    {
        get => prodName;
        set => this.prodName = value;
    }

    [JsonPropertyName("mod_date")]
    public string? ModDate
    {
        get => modDate;
        set => this.modDate = value;
    }

    [JsonPropertyName("produce_ent_name")]
    public string? ProduceEntName
    {
        get => produceEntName;
        set => this.produceEntName = value;
    }

    [JsonPropertyName("prepn_unit")]
    public string? PrepnUnit
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

    [JsonPropertyName("approve_no")]
    public string? ApproveNo
    {
        get => approveNo;
        set => this.approveNo = value;
    }

    [JsonPropertyName("pkg_unit")]
    public string? PkgUnit
    {
        get => pkgUnit;
        set => this.pkgUnit = value;
    }

    [JsonPropertyName("drug_ent_base_info_id")]
    public string? DrugEntBaseInfoId
    {
        get => drugEntBaseInfoId;
        set => this.drugEntBaseInfoId = value;
    }

    [JsonPropertyName("prepn_unit_desc")]
    public string? PrepnUnitDesc
    {
        get => prepnUnitDesc;
        set => this.prepnUnitDesc = value;
    }

    [JsonPropertyName("pkg_spec")]
    public string? PkgSpec
    {
        get => pkgSpec;
        set => this.pkgSpec = value;
    }

    [JsonPropertyName("pkg_unit_desc")]
    public string? PkgUnitDesc
    {
        get => pkgUnitDesc;
        set => this.pkgUnitDesc = value;
    }

    [JsonPropertyName("physic_info")]
    public string? PhysicInfo
    {
        get => physicInfo;
        set => this.physicInfo = value;
    }

}

