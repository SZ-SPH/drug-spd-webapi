using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;
using Topsdk.Top.Ability2940.Domain;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlResponse : AbstractTopApiResponse
{

    /*
        接口返回
            */
    private AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlResultModel? result;


    [JsonPropertyName("result")]
    public AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlResultModel? Result
    {
        get => result;
        set => this.result = value;
    }

}

