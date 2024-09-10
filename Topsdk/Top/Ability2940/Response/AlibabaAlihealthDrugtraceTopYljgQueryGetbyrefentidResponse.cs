using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;
using Topsdk.Top.Ability2940.Domain;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentidResponse : AbstractTopApiResponse
{

    /*
        监控宝推送网站监控信息，返回结果
            */
    private AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentidResultModel? result;


    [JsonPropertyName("result")]
    public AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentidResultModel? Result
    {
        get => result;
        set => this.result = value;
    }

}

