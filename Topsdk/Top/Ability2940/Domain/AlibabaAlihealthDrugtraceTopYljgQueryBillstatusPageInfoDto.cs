using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryBillstatusPageInfoDto
{

    /*
        总计
    */
    private long? totalNum;


    /*
        返回列表
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryBillstatusBillDealStatusSearchDo>? resultList;



    [JsonPropertyName("total_num")]
    public long? TotalNum
    {
        get => totalNum;
        set => this.totalNum = value;
    }

    [JsonPropertyName("result_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryBillstatusBillDealStatusSearchDo>? ResultList
    {
        get => resultList;
        set => this.resultList = value;
    }

}

