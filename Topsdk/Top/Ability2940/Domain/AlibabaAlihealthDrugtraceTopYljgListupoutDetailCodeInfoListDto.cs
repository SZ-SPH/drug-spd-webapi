using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgListupoutDetailCodeInfoListDto
{

    /*
        制剂规格
    */
    private string? prepnSpec;


    /*
        最小制剂数量
    */
    private string? prepnAmount;


    /*
        最小包装数量
    */
    private string? pkgAmount;


    /*
        监管码级别
    */
    private string? codeLevel;


    /*
        监管码
    */
    private string? code;



    [JsonPropertyName("prepn_spec")]
    public string? PrepnSpec
    {
        get => prepnSpec;
        set => this.prepnSpec = value;
    }

    [JsonPropertyName("prepn_amount")]
    public string? PrepnAmount
    {
        get => prepnAmount;
        set => this.prepnAmount = value;
    }

    [JsonPropertyName("pkg_amount")]
    public string? PkgAmount
    {
        get => pkgAmount;
        set => this.pkgAmount = value;
    }

    [JsonPropertyName("code_level")]
    public string? CodeLevel
    {
        get => codeLevel;
        set => this.codeLevel = value;
    }

    [JsonPropertyName("code")]
    public string? Code
    {
        get => code;
        set => this.code = value;
    }

}

