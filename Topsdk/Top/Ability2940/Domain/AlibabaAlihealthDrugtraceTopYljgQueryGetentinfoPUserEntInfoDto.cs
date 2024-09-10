using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryGetentinfoPUserEntInfoDto
{

    /*
        企业唯一标识【ref_ent_id】
    */
    private string? refEntId;


    /*
        企业ID【ent_id】
    */
    private string? entId;


    /*
        入网标识【0非入网;1开头代表入网企业;200代表入驻马上放心的企业】
    */
    private string? networkType;



    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("ent_id")]
    public string? EntId
    {
        get => entId;
        set => this.entId = value;
    }

    [JsonPropertyName("network_type")]
    public string? NetworkType
    {
        get => networkType;
        set => this.networkType = value;
    }

}

