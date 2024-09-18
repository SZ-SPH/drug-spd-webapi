using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailDrugEntBaseDto
{

    /*
        药品类型描述
    */
    private string? physicTypeDesc;


    /*
        药品名称
    */
    private string? physicName;


    /*
        有效期
    */
    private string? exprie;


    /*
        药品id
    */
    private string? drugEntBaseInfoId;


    /*
        批准文号
    */
    private string? approvalLicenceNo;


    /*
        包装规格
    */
    private string? pkgSpecCrit;


    /*
        制剂规格
    */
    private string? prepnSpec;


    /*
        剂型描述
    */
    private string? prepnTypeDesc;



    [JsonPropertyName("physic_type_desc")]
    public string? PhysicTypeDesc
    {
        get => physicTypeDesc;
        set => this.physicTypeDesc = value;
    }

    [JsonPropertyName("physic_name")]
    public string? PhysicName
    {
        get => physicName;
        set => this.physicName = value;
    }

    [JsonPropertyName("exprie")]
    public string? Exprie
    {
        get => exprie;
        set => this.exprie = value;
    }

    [JsonPropertyName("drug_ent_base_info_id")]
    public string? DrugEntBaseInfoId
    {
        get => drugEntBaseInfoId;
        set => this.drugEntBaseInfoId = value;
    }

    [JsonPropertyName("approval_licence_no")]
    public string? ApprovalLicenceNo
    {
        get => approvalLicenceNo;
        set => this.approvalLicenceNo = value;
    }

    [JsonPropertyName("pkg_spec_crit")]
    public string? PkgSpecCrit
    {
        get => pkgSpecCrit;
        set => this.pkgSpecCrit = value;
    }

    [JsonPropertyName("prepn_spec")]
    public string? PrepnSpec
    {
        get => prepnSpec;
        set => this.prepnSpec = value;
    }

    [JsonPropertyName("prepn_type_desc")]
    public string? PrepnTypeDesc
    {
        get => prepnTypeDesc;
        set => this.prepnTypeDesc = value;
    }

}

