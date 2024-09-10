using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;
using Topsdk.Top.Ability2940.Domain;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResponse : AbstractTopApiResponse
{

    /*
        最外层结果
            */
    private AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResultModel? result;


    [JsonPropertyName("result")]
    public AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResultModel? Result
    {
        get => result;
        set => this.result = value;
    }

}

