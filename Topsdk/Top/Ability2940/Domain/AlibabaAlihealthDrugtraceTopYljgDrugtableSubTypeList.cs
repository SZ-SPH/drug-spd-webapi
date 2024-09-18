using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgDrugtableSubTypeList
{

    /*
        制剂单位
    */
    private string? prepnUnit;


    /*
        包装规格
    */
    private string? packageSpec;


    /*
        码列表
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgDrugtableCodeResList>? codeResList;


    /*
        制剂规格
    */
    private string? prepnSpec;


    /*
        企业药品ID
    */
    private string? prodSeqNo;


    /*
        批准文号
    */
    private string? approveNo;


    /*
        药品详情类型
    */
    private string? physicDetailType;


    /*
        包装单位
    */
    private string? packUnit;


    /*
        药品ID
    */
    private string? drugEntBaseInfoId;


    /*
        包装单位
    */
    private string? packUnitName;


    /*
        制剂描述
    */
    private string? prepnDesc;


    /*
        制剂单位描述
    */
    private string? prepnUnitName;


    /*
        子类型
    */
    private string? subTypeNo;



    [JsonPropertyName("prepn_unit")]
    public string? PrepnUnit
    {
        get => prepnUnit;
        set => this.prepnUnit = value;
    }

    [JsonPropertyName("package_spec")]
    public string? PackageSpec
    {
        get => packageSpec;
        set => this.packageSpec = value;
    }

    [JsonPropertyName("code_res_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgDrugtableCodeResList>? CodeResList
    {
        get => codeResList;
        set => this.codeResList = value;
    }

    [JsonPropertyName("prepn_spec")]
    public string? PrepnSpec
    {
        get => prepnSpec;
        set => this.prepnSpec = value;
    }

    [JsonPropertyName("prod_seq_no")]
    public string? ProdSeqNo
    {
        get => prodSeqNo;
        set => this.prodSeqNo = value;
    }

    [JsonPropertyName("approve_no")]
    public string? ApproveNo
    {
        get => approveNo;
        set => this.approveNo = value;
    }

    [JsonPropertyName("physic_detail_type")]
    public string? PhysicDetailType
    {
        get => physicDetailType;
        set => this.physicDetailType = value;
    }

    [JsonPropertyName("pack_unit")]
    public string? PackUnit
    {
        get => packUnit;
        set => this.packUnit = value;
    }

    [JsonPropertyName("drug_ent_base_info_id")]
    public string? DrugEntBaseInfoId
    {
        get => drugEntBaseInfoId;
        set => this.drugEntBaseInfoId = value;
    }

    [JsonPropertyName("pack_unit_name")]
    public string? PackUnitName
    {
        get => packUnitName;
        set => this.packUnitName = value;
    }

    [JsonPropertyName("prepn_desc")]
    public string? PrepnDesc
    {
        get => prepnDesc;
        set => this.prepnDesc = value;
    }

    [JsonPropertyName("prepn_unit_name")]
    public string? PrepnUnitName
    {
        get => prepnUnitName;
        set => this.prepnUnitName = value;
    }

    [JsonPropertyName("sub_type_no")]
    public string? SubTypeNo
    {
        get => subTypeNo;
        set => this.subTypeNo = value;
    }

}

