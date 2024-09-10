using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgDrugtableDrugTableDto
{

    /*
        制剂类型描述
    */
    private string? prepnTypeDesc;


    /*
        药品类型描述
    */
    private string? physicTypeDesc;


    /*
        药品类型(详见码表) 1：特殊药品原料药，2：特殊药品制剂，3：普通药品，9：未分类
    */
    private long? physicType;


    /*
        药品名称
    */
    private string? physicName;


    /*
        药品自类编码
    */
    private string? prodCode;


    /*
        药品详细类型
    */
    private long? physicDetailType;


    /*
        企业主键
    */
    private string? refEntId;


    /*
        商品名称
    */
    private string? prodName;


    /*
        修改日期
    */
    private string? modDate;


    /*
        企业名称
    */
    private string? entName;


    /*
        包装单位描述
    */
    private string? pkgUnitDesc;


    /*
        药品类型详情描述
    */
    private string? physicDetailTypeDesc;


    /*
        制剂单位描述
    */
    private string? prepnUnitDesc;


    /*
        子列表
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgDrugtableSubTypeList>? subTypeList;



    [JsonPropertyName("prepn_type_desc")]
    public string? PrepnTypeDesc
    {
        get => prepnTypeDesc;
        set => this.prepnTypeDesc = value;
    }

    [JsonPropertyName("physic_type_desc")]
    public string? PhysicTypeDesc
    {
        get => physicTypeDesc;
        set => this.physicTypeDesc = value;
    }

    [JsonPropertyName("physic_type")]
    public long? PhysicType
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
    public long? PhysicDetailType
    {
        get => physicDetailType;
        set => this.physicDetailType = value;
    }

    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
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

    [JsonPropertyName("ent_name")]
    public string? EntName
    {
        get => entName;
        set => this.entName = value;
    }

    [JsonPropertyName("pkg_unit_desc")]
    public string? PkgUnitDesc
    {
        get => pkgUnitDesc;
        set => this.pkgUnitDesc = value;
    }

    [JsonPropertyName("physic_detail_type_desc")]
    public string? PhysicDetailTypeDesc
    {
        get => physicDetailTypeDesc;
        set => this.physicDetailTypeDesc = value;
    }

    [JsonPropertyName("prepn_unit_desc")]
    public string? PrepnUnitDesc
    {
        get => prepnUnitDesc;
        set => this.prepnUnitDesc = value;
    }

    [JsonPropertyName("sub_type_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgDrugtableSubTypeList>? SubTypeList
    {
        get => subTypeList;
        set => this.subTypeList = value;
    }

}

