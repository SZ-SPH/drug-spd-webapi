using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;
using Topsdk.Top.Ability2940.Domain;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailResponse : AbstractTopApiResponse
{

    /*
        监控宝推送网站监控信息，返回结果
            */
    private AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailResultModel? result;


    [JsonPropertyName("result")]
    public AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailResultModel? Result
    {
        get => result;
        set => this.result = value;
    }

}

