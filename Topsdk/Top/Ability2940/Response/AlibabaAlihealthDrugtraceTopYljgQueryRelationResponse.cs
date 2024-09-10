using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;
using Topsdk.Top.Ability2940.Domain;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationResponse : AbstractTopApiResponse
{

    /*
        接口返回model
            */
    private AlibabaAlihealthDrugtraceTopYljgQueryRelationResultModel? result;


    [JsonPropertyName("result")]
    public AlibabaAlihealthDrugtraceTopYljgQueryRelationResultModel? Result
    {
        get => result;
        set => this.result = value;
    }

}

