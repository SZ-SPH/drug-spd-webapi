using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeFullInfoDto
{

    /*
        码对象
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeStatusTypeDto? codeStatusTypeDTO;


    /*
        追溯码
    */
    private string? code;


    /*
        企业信息对象
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryCodedetailPUserEntDto? pUserEntDTO;


    /*
        码等级【1代表最小码 如：申请的包装比例是1:5:10, 对应的码等级就是3、2、1, 代表大码、中码、小码】
    */
    private string? packageLevel;


    /*
        药品基本信息对象
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryCodedetailDrugEntBaseDto? drugEntBaseDTO;


    /*
        码生产信息对象
    */
    private AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeProduceInfoDto? codeProduceInfoDTO;



    [JsonPropertyName("code_status_type_d_t_o")]
    public AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeStatusTypeDto? CodeStatusTypeDTO
    {
        get => codeStatusTypeDTO;
        set => this.codeStatusTypeDTO = value;
    }

    [JsonPropertyName("code")]
    public string? Code
    {
        get => code;
        set => this.code = value;
    }

    [JsonPropertyName("p_user_ent_d_t_o")]
    public AlibabaAlihealthDrugtraceTopYljgQueryCodedetailPUserEntDto? PUserEntDTO
    {
        get => pUserEntDTO;
        set => this.pUserEntDTO = value;
    }

    [JsonPropertyName("package_level")]
    public string? PackageLevel
    {
        get => packageLevel;
        set => this.packageLevel = value;
    }

    [JsonPropertyName("drug_ent_base_d_t_o")]
    public AlibabaAlihealthDrugtraceTopYljgQueryCodedetailDrugEntBaseDto? DrugEntBaseDTO
    {
        get => drugEntBaseDTO;
        set => this.drugEntBaseDTO = value;
    }

    [JsonPropertyName("code_produce_info_d_t_o")]
    public AlibabaAlihealthDrugtraceTopYljgQueryCodedetailCodeProduceInfoDto? CodeProduceInfoDTO
    {
        get => codeProduceInfoDTO;
        set => this.codeProduceInfoDTO = value;
    }

}

