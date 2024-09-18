using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo
{

    /*
        码状态（A:已激活;I:已核注;O:已核销;C:已注销;S:已售出;E:码不存在）
    */
    private string? status;


    /*
        追溯码
    */
    private string? code;


    /*
        码等级--展示等级 【相当于包装等级，1代表最大展示等级, 如：申请的包装比例是1:5:10, 对应的码展示等级就是 1、2、3, 代表大码、中码、小码】
    */
    private string? codeLevel;


    /*
        父码
    */
    private string? parentCode;


    /*
        码等级【1代表最小码 如：申请的包装比例是1:5:10, 对应的码等级就是3、2、1, 代表大码、中码、小码】
    */
    private string? codePackLevel;



    [JsonPropertyName("status")]
    public string? Status
    {
        get => status;
        set => this.status = value;
    }

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

    [JsonPropertyName("code_pack_level")]
    public string? CodePackLevel
    {
        get => codePackLevel;
        set => this.codePackLevel = value;
    }

}

