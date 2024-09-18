using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgListupoutDetailBillUpOutDetailDto
{

    /*
        单据编码
    */
    private string? billCode;


    /*
        单据类型描述
    */
    private string? billTypeName;


    /*
        单据类型
    */
    private string? billType;


    /*
        发货企业名称
    */
    private string? entSendName;


    /*
        发货企业的ref_ent_id
    */
    private string? entSendId;


    /*
        收货企业名称
    */
    private string? entRecvName;


    /*
        收货企业ref_ent_id
    */
    private string? entRecvId;


    /*
        单据日期
    */
    private string? storeOutDate;


    /*
        最后更新时间
    */
    private string? updateDate;


    /*
        药品信息数据
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgListupoutDetailDrugInfosDto>? drugInfosDtoList;



    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
    }

    [JsonPropertyName("bill_type_name")]
    public string? BillTypeName
    {
        get => billTypeName;
        set => this.billTypeName = value;
    }

    [JsonPropertyName("bill_type")]
    public string? BillType
    {
        get => billType;
        set => this.billType = value;
    }

    [JsonPropertyName("ent_send_name")]
    public string? EntSendName
    {
        get => entSendName;
        set => this.entSendName = value;
    }

    [JsonPropertyName("ent_send_id")]
    public string? EntSendId
    {
        get => entSendId;
        set => this.entSendId = value;
    }

    [JsonPropertyName("ent_recv_name")]
    public string? EntRecvName
    {
        get => entRecvName;
        set => this.entRecvName = value;
    }

    [JsonPropertyName("ent_recv_id")]
    public string? EntRecvId
    {
        get => entRecvId;
        set => this.entRecvId = value;
    }

    [JsonPropertyName("store_out_date")]
    public string? StoreOutDate
    {
        get => storeOutDate;
        set => this.storeOutDate = value;
    }

    [JsonPropertyName("update_date")]
    public string? UpdateDate
    {
        get => updateDate;
        set => this.updateDate = value;
    }

    [JsonPropertyName("drug_infos_dto_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgListupoutDetailDrugInfosDto>? DrugInfosDtoList
    {
        get => drugInfosDtoList;
        set => this.drugInfosDtoList = value;
    }

}

