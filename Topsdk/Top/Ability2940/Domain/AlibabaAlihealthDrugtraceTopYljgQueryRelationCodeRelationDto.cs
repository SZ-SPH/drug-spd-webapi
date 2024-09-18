using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeRelationDto
{

    /*
        激活信息
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeActiveInfoDto? codeActiveInfoDto;


    /*
        码关联关系
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo>? codeRelationList;


    /*
        是否是最小包装
    */
    private string? isSmallest;


    /*
        药品包装信息
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryRelationPkgInfoDto? pkgInfoDto;


    /*
        药品基础信息
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryRelationBaseInfosDto? baseInfosDto;


    /*
        生产信息
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryRelationProduceInfoDto>? produceInfoList;



    [JsonPropertyName("code_active_info_dto")]
    public AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeActiveInfoDto? CodeActiveInfoDto
    {
        get => codeActiveInfoDto;
        set => this.codeActiveInfoDto = value;
    }

    [JsonPropertyName("code_relation_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo>? CodeRelationList
    {
        get => codeRelationList;
        set => this.codeRelationList = value;
    }

    [JsonPropertyName("is_smallest")]
    public string? IsSmallest
    {
        get => isSmallest;
        set => this.isSmallest = value;
    }

    [JsonPropertyName("pkg_info_dto")]
    public AlibabaAlihealthDrugtraceTopYljgQueryRelationPkgInfoDto? PkgInfoDto
    {
        get => pkgInfoDto;
        set => this.pkgInfoDto = value;
    }

    [JsonPropertyName("base_infos_dto")]
    public AlibabaAlihealthDrugtraceTopYljgQueryRelationBaseInfosDto? BaseInfosDto
    {
        get => baseInfosDto;
        set => this.baseInfosDto = value;
    }

    [JsonPropertyName("produce_info_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryRelationProduceInfoDto>? ProduceInfoList
    {
        get => produceInfoList;
        set => this.produceInfoList = value;
    }

}

