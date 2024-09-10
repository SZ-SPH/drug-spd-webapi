using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeProduceInfoDto
{

    /*
        生产信息集合
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryCodedetailProduceInfoDto>? produceInfoList;



    [JsonPropertyName("produce_info_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryCodedetailProduceInfoDto>? ProduceInfoList
    {
        get => produceInfoList;
        set => this.produceInfoList = value;
    }

}

