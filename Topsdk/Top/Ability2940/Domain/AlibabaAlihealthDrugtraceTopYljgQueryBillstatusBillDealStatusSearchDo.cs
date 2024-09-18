using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryBillstatusBillDealStatusSearchDo
{

    /*
        出入库号
    */
    private string? storeInoutSeqNo;


    /*
        药品类型
    */
    private string? physicType;


    /*
        上传文件名
    */
    private string? uploadFileName;


    /*
        发货单位
    */
    private string? fromUserName;


    /*
        角色类型
    */
    private string? roleType;


    /*
        创建日期
    */
    private string? crtDate;


    /*
        IC码
    */
    private string? icCode;


    /*
        文件名
    */
    private string? shortFileName;


    /*
        企业名称
    */
    private string? refUserName;


    /*
        单据日期
    */
    private string? billTime;


    /*
        处理状态  0，处理中 1, 上传成功     3, 处理成功     4, 处理失败
    */
    private string? resultType;


    /*
        上传标识
    */
    private string? uploadFlag;


    /*
        处理结果表状态(暂不用)
    */
    private string? processFlag;


    /*
        处理日期
    */
    private string? processDate;


    /*
        单号号
    */
    private string? billCode;


    /*
        单据类型
    */
    private string? billType;


    /*
        收货单位
    */
    private string? toUserName;


    /*
        发货单位主键
    */
    private string? fromUserId;


    /*
        发货单位唯一标识
    */
    private string? fromRefUserId;


    /*
        收货单位主键
    */
    private string? toUserId;


    /*
        用户唯一标识
    */
    private string? refUserId;


    /*
        收货单位唯一标识
    */
    private string? toRefUserId;


    /*
        用户主键
    */
    private string? userId;


    /*
        处理信息
    */
    private string? processInfo;



    [JsonPropertyName("store_inout_seq_no")]
    public string? StoreInoutSeqNo
    {
        get => storeInoutSeqNo;
        set => this.storeInoutSeqNo = value;
    }

    [JsonPropertyName("physic_type")]
    public string? PhysicType
    {
        get => physicType;
        set => this.physicType = value;
    }

    [JsonPropertyName("upload_file_name")]
    public string? UploadFileName
    {
        get => uploadFileName;
        set => this.uploadFileName = value;
    }

    [JsonPropertyName("from_user_name")]
    public string? FromUserName
    {
        get => fromUserName;
        set => this.fromUserName = value;
    }

    [JsonPropertyName("role_type")]
    public string? RoleType
    {
        get => roleType;
        set => this.roleType = value;
    }

    [JsonPropertyName("crt_date")]
    public string? CrtDate
    {
        get => crtDate;
        set => this.crtDate = value;
    }

    [JsonPropertyName("ic_code")]
    public string? IcCode
    {
        get => icCode;
        set => this.icCode = value;
    }

    [JsonPropertyName("short_file_name")]
    public string? ShortFileName
    {
        get => shortFileName;
        set => this.shortFileName = value;
    }

    [JsonPropertyName("ref_user_name")]
    public string? RefUserName
    {
        get => refUserName;
        set => this.refUserName = value;
    }

    [JsonPropertyName("bill_time")]
    public string? BillTime
    {
        get => billTime;
        set => this.billTime = value;
    }

    [JsonPropertyName("result_type")]
    public string? ResultType
    {
        get => resultType;
        set => this.resultType = value;
    }

    [JsonPropertyName("upload_flag")]
    public string? UploadFlag
    {
        get => uploadFlag;
        set => this.uploadFlag = value;
    }

    [JsonPropertyName("process_flag")]
    public string? ProcessFlag
    {
        get => processFlag;
        set => this.processFlag = value;
    }

    [JsonPropertyName("process_date")]
    public string? ProcessDate
    {
        get => processDate;
        set => this.processDate = value;
    }

    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
    }

    [JsonPropertyName("bill_type")]
    public string? BillType
    {
        get => billType;
        set => this.billType = value;
    }

    [JsonPropertyName("to_user_name")]
    public string? ToUserName
    {
        get => toUserName;
        set => this.toUserName = value;
    }

    [JsonPropertyName("from_user_id")]
    public string? FromUserId
    {
        get => fromUserId;
        set => this.fromUserId = value;
    }

    [JsonPropertyName("from_ref_user_id")]
    public string? FromRefUserId
    {
        get => fromRefUserId;
        set => this.fromRefUserId = value;
    }

    [JsonPropertyName("to_user_id")]
    public string? ToUserId
    {
        get => toUserId;
        set => this.toUserId = value;
    }

    [JsonPropertyName("ref_user_id")]
    public string? RefUserId
    {
        get => refUserId;
        set => this.refUserId = value;
    }

    [JsonPropertyName("to_ref_user_id")]
    public string? ToRefUserId
    {
        get => toRefUserId;
        set => this.toRefUserId = value;
    }

    [JsonPropertyName("user_id")]
    public string? UserId
    {
        get => userId;
        set => this.userId = value;
    }

    [JsonPropertyName("process_info")]
    public string? ProcessInfo
    {
        get => processInfo;
        set => this.processInfo = value;
    }

}

