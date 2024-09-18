using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlJSONObject
{

    /*
        文件下载地址
    */
    private string? url;



    [JsonPropertyName("url")]
    public string? Url
    {
        get => url;
        set => this.url = value;
    }

}

