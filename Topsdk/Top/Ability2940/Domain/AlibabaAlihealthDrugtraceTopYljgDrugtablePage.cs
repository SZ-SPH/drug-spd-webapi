using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgDrugtablePage
{

    /*
        总计
    */
    private long? totalNum;


    /*
        返回列表
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgDrugtableDrugTableDto>? resultList;


    /*
        当前页
    */
    private long? page;


    /*
        分页大小
    */
    private long? pageSize;



    [JsonPropertyName("total_num")]
    public long? TotalNum
    {
        get => totalNum;
        set => this.totalNum = value;
    }

    [JsonPropertyName("result_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgDrugtableDrugTableDto>? ResultList
    {
        get => resultList;
        set => this.resultList = value;
    }

    [JsonPropertyName("page")]
    public long? Page
    {
        get => page;
        set => this.page = value;
    }

    [JsonPropertyName("page_size")]
    public long? PageSize
    {
        get => pageSize;
        set => this.pageSize = value;
    }

}

