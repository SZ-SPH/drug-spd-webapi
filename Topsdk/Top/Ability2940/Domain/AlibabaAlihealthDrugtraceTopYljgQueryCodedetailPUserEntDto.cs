using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailPUserEntDto
{

    /*
        企业id
    */
    private string? refEntId;


    /*
        企业名称
    */
    private string? entName;



    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("ent_name")]
    public string? EntName
    {
        get => entName;
        set => this.entName = value;
    }

}

