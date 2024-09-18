using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;
using Topsdk.Top.Ability2940.Domain;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgGetdruglistResponse : AbstractTopApiResponse
{

    /*
        返回结果
            */
    private AlibabaAlihealthDrugtraceTopYljgGetdruglistResultModel? result;


    [JsonPropertyName("result")]
    public AlibabaAlihealthDrugtraceTopYljgGetdruglistResultModel? Result
    {
        get => result;
        set => this.result = value;
    }

}

