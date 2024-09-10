using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentidPUserEntInfoDto
{

    /*
        企业id
    */
    private string? entId;


    /*
        企业唯一标识
    */
    private string? refEntId;


    /*
        是否入网
    */
    private string? isNetwork;


    /*
        企业名称
    */
    private string? entName;


    /*
        所属管理机构
    */
    private string? directManage;


    /*
        是否法人
    */
    private string? legalOrgFlag;


    /*
        机构代码
    */
    private string? orgCode;


    /*
        注册地编码
    */
    private string? regRegionCode;


    /*
        注册地明细
    */
    private string? regRegionDetail;


    /*
        所在地编码
    */
    private string? dictRegionCode;


    /*
        所在地明细
    */
    private string? dictRegionDetail;


    /*
        状态1.使用中0.已废除
    */
    private string? status;


    /*
        企业类型[1,生产企业 2批发企业 3医疗机构 4药店 5物流]
    */
    private string? userRoleTypeStr;


    /*
        企业类型编码
    */
    private string? userRoleType;


    /*
        企业机构详细类别
    */
    private string? entOrgType;


    /*
        省
    */
    private string? provName;


    /*
        市
    */
    private string? areaName;


    /*
        县
    */
    private string? cityName;



    [JsonPropertyName("ent_id")]
    public string? EntId
    {
        get => entId;
        set => this.entId = value;
    }

    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("is_network")]
    public string? IsNetwork
    {
        get => isNetwork;
        set => this.isNetwork = value;
    }

    [JsonPropertyName("ent_name")]
    public string? EntName
    {
        get => entName;
        set => this.entName = value;
    }

    [JsonPropertyName("direct_manage")]
    public string? DirectManage
    {
        get => directManage;
        set => this.directManage = value;
    }

    [JsonPropertyName("legal_org_flag")]
    public string? LegalOrgFlag
    {
        get => legalOrgFlag;
        set => this.legalOrgFlag = value;
    }

    [JsonPropertyName("org_code")]
    public string? OrgCode
    {
        get => orgCode;
        set => this.orgCode = value;
    }

    [JsonPropertyName("reg_region_code")]
    public string? RegRegionCode
    {
        get => regRegionCode;
        set => this.regRegionCode = value;
    }

    [JsonPropertyName("reg_region_detail")]
    public string? RegRegionDetail
    {
        get => regRegionDetail;
        set => this.regRegionDetail = value;
    }

    [JsonPropertyName("dict_region_code")]
    public string? DictRegionCode
    {
        get => dictRegionCode;
        set => this.dictRegionCode = value;
    }

    [JsonPropertyName("dict_region_detail")]
    public string? DictRegionDetail
    {
        get => dictRegionDetail;
        set => this.dictRegionDetail = value;
    }

    [JsonPropertyName("status")]
    public string? Status
    {
        get => status;
        set => this.status = value;
    }

    [JsonPropertyName("user_role_type_str")]
    public string? UserRoleTypeStr
    {
        get => userRoleTypeStr;
        set => this.userRoleTypeStr = value;
    }

    [JsonPropertyName("user_role_type")]
    public string? UserRoleType
    {
        get => userRoleType;
        set => this.userRoleType = value;
    }

    [JsonPropertyName("ent_org_type")]
    public string? EntOrgType
    {
        get => entOrgType;
        set => this.entOrgType = value;
    }

    [JsonPropertyName("prov_name")]
    public string? ProvName
    {
        get => provName;
        set => this.provName = value;
    }

    [JsonPropertyName("area_name")]
    public string? AreaName
    {
        get => areaName;
        set => this.areaName = value;
    }

    [JsonPropertyName("city_name")]
    public string? CityName
    {
        get => cityName;
        set => this.cityName = value;
    }

}

