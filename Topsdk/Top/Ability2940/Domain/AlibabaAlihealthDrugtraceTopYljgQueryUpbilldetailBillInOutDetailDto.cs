using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailBillInOutDetailDto
{

    /*
        修改时间
    */
    private string? modDate;


    /*
        处理时间
    */
    private string? processDate;


    /*
        单据日期
    */
    private string? billTime;


    /*
        收货企业id
    */
    private string? toUserId;


    /*
        收货企业名称
    */
    private string? toEntName;


    /*
        发货企业id
    */
    private string? fromUserId;


    /*
        发货企业名称
    */
    private string? fromEntName;


    /*
        单据类型名称
    */
    private string? billTypeName;


    /*
        单据类型
    */
    private string? billType;


    /*
        单据号码
    */
    private string? billCode;


    /*
        单据详情
    */
    private IList<AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailBillchkinoutdetaillistdtolist>? billChkInOutDetailListDTOList;



    [JsonPropertyName("mod_date")]
    public string? ModDate
    {
        get => modDate;
        set => this.modDate = value;
    }

    [JsonPropertyName("process_date")]
    public string? ProcessDate
    {
        get => processDate;
        set => this.processDate = value;
    }

    [JsonPropertyName("bill_time")]
    public string? BillTime
    {
        get => billTime;
        set => this.billTime = value;
    }

    [JsonPropertyName("to_user_id")]
    public string? ToUserId
    {
        get => toUserId;
        set => this.toUserId = value;
    }

    [JsonPropertyName("to_ent_name")]
    public string? ToEntName
    {
        get => toEntName;
        set => this.toEntName = value;
    }

    [JsonPropertyName("from_user_id")]
    public string? FromUserId
    {
        get => fromUserId;
        set => this.fromUserId = value;
    }

    [JsonPropertyName("from_ent_name")]
    public string? FromEntName
    {
        get => fromEntName;
        set => this.fromEntName = value;
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

    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
    }

    [JsonPropertyName("bill_chk_in_out_detail_list_d_t_o_list")]
    public IList<AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailBillchkinoutdetaillistdtolist>? BillChkInOutDetailListDTOList
    {
        get => billChkInOutDetailListDTOList;
        set => this.billChkInOutDetailListDTOList = value;
    }

}

