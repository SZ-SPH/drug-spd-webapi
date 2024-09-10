using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationPkgInfoDto
{

    /*
        码信息
    */
    private IList<string>? codeList;



    [JsonPropertyName("code_list")]
    public IList<string>? CodeList
    {
        get => codeList;
        set => this.codeList = value;
    }

}

