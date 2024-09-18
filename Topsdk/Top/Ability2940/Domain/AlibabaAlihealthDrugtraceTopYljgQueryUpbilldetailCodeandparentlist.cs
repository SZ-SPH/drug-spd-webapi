using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailCodeandparentlist
{

    /*
        追溯码
    */
    private string? code;


    /*
        码级别
    */
    private string? codeLevel;


    /*
        父码
    */
    private string? parentCode;



    [JsonPropertyName("code")]
    public string? Code
    {
        get => code;
        set => this.code = value;
    }

    [JsonPropertyName("code_level")]
    public string? CodeLevel
    {
        get => codeLevel;
        set => this.codeLevel = value;
    }

    [JsonPropertyName("parent_code")]
    public string? ParentCode
    {
        get => parentCode;
        set => this.parentCode = value;
    }

}

