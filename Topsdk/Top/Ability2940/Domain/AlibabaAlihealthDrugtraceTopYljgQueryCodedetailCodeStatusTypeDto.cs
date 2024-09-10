using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeStatusTypeDto
{

    /*
        码状态（A:已激活;I:已核注;O:已核销;C:已注销;S:已售出;E:码不存在）
    */
    private string? codeStatus;



    [JsonPropertyName("code_status")]
    public string? CodeStatus
    {
        get => codeStatus;
        set => this.codeStatus = value;
    }

}

