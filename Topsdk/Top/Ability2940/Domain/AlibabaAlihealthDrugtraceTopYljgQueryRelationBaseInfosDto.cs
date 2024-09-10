using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationBaseInfosDto
{

    /*
        药品基础信息
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryRelationBaseInfoDto>? baseInfoList;



    [JsonPropertyName("base_info_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryRelationBaseInfoDto>? BaseInfoList
    {
        get => baseInfoList;
        set => this.baseInfoList = value;
    }

}

