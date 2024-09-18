using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgDrugtableCodeResList
{

    /*
        码前缀
    */
    private string? codePrefix;


    /*
        资源码
    */
    private string? resCode;


    /*
        层级
    */
    private string? codeLevel;


    /*
        包装比例
    */
    private string? pkgRatio;



    [JsonPropertyName("code_prefix")]
    public string? CodePrefix
    {
        get => codePrefix;
        set => this.codePrefix = value;
    }

    [JsonPropertyName("res_code")]
    public string? ResCode
    {
        get => resCode;
        set => this.resCode = value;
    }

    [JsonPropertyName("code_level")]
    public string? CodeLevel
    {
        get => codeLevel;
        set => this.codeLevel = value;
    }

    [JsonPropertyName("pkg_ratio")]
    public string? PkgRatio
    {
        get => pkgRatio;
        set => this.pkgRatio = value;
    }

}

