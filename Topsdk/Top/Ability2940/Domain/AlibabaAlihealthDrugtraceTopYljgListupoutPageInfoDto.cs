using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgListupoutPageInfoDto
{

    /*
        返回列表
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgListupoutBillUpOutDetailDo>? resultList;


    /*
        总数
    */
    private long? totalNum;



    [JsonPropertyName("result_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgListupoutBillUpOutDetailDo>? ResultList
    {
        get => resultList;
        set => this.resultList = value;
    }

    [JsonPropertyName("total_num")]
    public long? TotalNum
    {
        get => totalNum;
        set => this.totalNum = value;
    }

}

