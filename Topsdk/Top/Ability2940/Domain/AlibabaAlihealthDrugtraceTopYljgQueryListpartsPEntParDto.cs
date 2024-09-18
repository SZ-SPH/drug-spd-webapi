using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryListpartsPEntParDto
{

    /*
        往来单位自定义编码
    */
    private string? partnerId;


    /*
        往来单位名称
    */
    private string? partnerName;


    /*
        企业id（查询企业自已的）
    */
    private string? entId;


    /*
        查询企业的唯一标识（查询企业自已的）
    */
    private string? refEntId;


    /*
        往来单位企业所在省编码
    */
    private string? entProvCode;


    /*
        所在省
    */
    private string? provName;


    /*
        所在市
    */
    private string? areaName;


    /*
        所在县
    */
    private string? cityName;


    /*
        是不是入网企业[1代表入网企业，其它为非入网]
    */
    private string? isNetwork;


    /*
        拼音缩写
    */
    private string? partnerCapitalName;


    /*
        类型
    */
    private string? partnerType;


    /*
        往来单位企业id【单据上传时的收发货企业填的就这个字段】
    */
    private string? partnerEntId;


    /*
        最近修改日期
    */
    private string? lastModDate;


    /*
        创建日期
    */
    private string? crtDate;


    /*
        创建IC名称
    */
    private string? crtIcName;


    /*
        状态
    */
    private string? status;


    /*
        修改IC名称
    */
    private string? modIcName;


    /*
        级别
    */
    private string? partnerLevel;


    /*
        修改IC码
    */
    private string? modIcCode;


    /*
        合作ID
    */
    private string? pEntParId;


    /*
        创建IC码
    */
    private string? crtIcCode;



    [JsonPropertyName("partner_id")]
    public string? PartnerId
    {
        get => partnerId;
        set => this.partnerId = value;
    }

    [JsonPropertyName("partner_name")]
    public string? PartnerName
    {
        get => partnerName;
        set => this.partnerName = value;
    }

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

    [JsonPropertyName("ent_prov_code")]
    public string? EntProvCode
    {
        get => entProvCode;
        set => this.entProvCode = value;
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

    [JsonPropertyName("is_network")]
    public string? IsNetwork
    {
        get => isNetwork;
        set => this.isNetwork = value;
    }

    [JsonPropertyName("partner_capital_name")]
    public string? PartnerCapitalName
    {
        get => partnerCapitalName;
        set => this.partnerCapitalName = value;
    }

    [JsonPropertyName("partner_type")]
    public string? PartnerType
    {
        get => partnerType;
        set => this.partnerType = value;
    }

    [JsonPropertyName("partner_ent_id")]
    public string? PartnerEntId
    {
        get => partnerEntId;
        set => this.partnerEntId = value;
    }

    [JsonPropertyName("last_mod_date")]
    public string? LastModDate
    {
        get => lastModDate;
        set => this.lastModDate = value;
    }

    [JsonPropertyName("crt_date")]
    public string? CrtDate
    {
        get => crtDate;
        set => this.crtDate = value;
    }

    [JsonPropertyName("crt_ic_name")]
    public string? CrtIcName
    {
        get => crtIcName;
        set => this.crtIcName = value;
    }

    [JsonPropertyName("status")]
    public string? Status
    {
        get => status;
        set => this.status = value;
    }

    [JsonPropertyName("mod_ic_name")]
    public string? ModIcName
    {
        get => modIcName;
        set => this.modIcName = value;
    }

    [JsonPropertyName("partner_level")]
    public string? PartnerLevel
    {
        get => partnerLevel;
        set => this.partnerLevel = value;
    }

    [JsonPropertyName("mod_ic_code")]
    public string? ModIcCode
    {
        get => modIcCode;
        set => this.modIcCode = value;
    }

    [JsonPropertyName("p_ent_par_id")]
    public string? PEntParId
    {
        get => pEntParId;
        set => this.pEntParId = value;
    }

    [JsonPropertyName("crt_ic_code")]
    public string? CrtIcCode
    {
        get => crtIcCode;
        set => this.crtIcCode = value;
    }

}

