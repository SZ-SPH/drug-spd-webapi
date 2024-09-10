using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;
using Topsdk.Top.Ability2940.Domain;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeResponse : AbstractTopApiResponse
{

    /*
        接口返回model
            */
    private AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeResult? result;


    [JsonPropertyName("result")]
    public AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeResult? Result
    {
        get => result;
        set => this.result = value;
    }

}

