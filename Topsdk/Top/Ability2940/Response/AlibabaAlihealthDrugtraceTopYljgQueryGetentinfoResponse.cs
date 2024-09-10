using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;
using Topsdk.Top.Ability2940.Domain;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgQueryGetentinfoResponse : AbstractTopApiResponse
{

    /*
        监控宝推送网站监控信息，返回结果
            */
    private AlibabaAlihealthDrugtraceTopYljgQueryGetentinfoResultModel? result;


    [JsonPropertyName("result")]
    public AlibabaAlihealthDrugtraceTopYljgQueryGetentinfoResultModel? Result
    {
        get => result;
        set => this.result = value;
    }

}

