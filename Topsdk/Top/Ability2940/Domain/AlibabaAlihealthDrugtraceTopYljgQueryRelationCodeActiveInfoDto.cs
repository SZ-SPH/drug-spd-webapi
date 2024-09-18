using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeActiveInfoDto
{

    /*
        处理标志
    */
    private string? processFlag;


    /*
        状态
    */
    private string? status;


    /*
        关联关系类型
    */
    private string? relationType;


    /*
        紧急人
    */
    private string? userCert;


    /*
        生产编号
    */
    private string? prodCode;


    /*
        操作人姓名
    */
    private string? operIcName;


    /*
        上传文件名
    */
    private string? uploadFileName;


    /*
        上传文件路径
    */
    private string? uploadFilePath;


    /*
        激活时间
    */
    private DateTime? activeDate;


    /*
        企业ID
    */
    private string? refEntId;


    /*
        旧企业ID
    */
    private string? entId;


    /*
        处理日期
    */
    private DateTime? processDate;


    /*
        处理结束时间
    */
    private DateTime? processEndDate;


    /*
        操作人编码
    */
    private string? operIcCode;


    /*
        上传标识
    */
    private string? uploadFlag;


    /*
        激活时间
    */
    private DateTime? crtDate;


    /*
        处理数量
    */
    private string? processCount;


    /*
        总激活数量
    */
    private long? activeCount;


    /*
        最大包装数量
    */
    private long? otherNum;


    /*
        小码数量
    */
    private long? smallNum;


    /*
        关联关系文件上传日期
    */
    private string? crtDateString;


    /*
        单据id
    */
    private string? billInId;


    /*
        激活信息id
    */
    private string? codeActiveInfoId;



    [JsonPropertyName("process_flag")]
    public string? ProcessFlag
    {
        get => processFlag;
        set => this.processFlag = value;
    }

    [JsonPropertyName("status")]
    public string? Status
    {
        get => status;
        set => this.status = value;
    }

    [JsonPropertyName("relation_type")]
    public string? RelationType
    {
        get => relationType;
        set => this.relationType = value;
    }

    [JsonPropertyName("user_cert")]
    public string? UserCert
    {
        get => userCert;
        set => this.userCert = value;
    }

    [JsonPropertyName("prod_code")]
    public string? ProdCode
    {
        get => prodCode;
        set => this.prodCode = value;
    }

    [JsonPropertyName("oper_ic_name")]
    public string? OperIcName
    {
        get => operIcName;
        set => this.operIcName = value;
    }

    [JsonPropertyName("upload_file_name")]
    public string? UploadFileName
    {
        get => uploadFileName;
        set => this.uploadFileName = value;
    }

    [JsonPropertyName("upload_file_path")]
    public string? UploadFilePath
    {
        get => uploadFilePath;
        set => this.uploadFilePath = value;
    }

    [JsonPropertyName("active_date")]
    public DateTime? ActiveDate
    {
        get => activeDate;
        set => this.activeDate = value;
    }

    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("ent_id")]
    public string? EntId
    {
        get => entId;
        set => this.entId = value;
    }

    [JsonPropertyName("process_date")]
    public DateTime? ProcessDate
    {
        get => processDate;
        set => this.processDate = value;
    }

    [JsonPropertyName("process_end_date")]
    public DateTime? ProcessEndDate
    {
        get => processEndDate;
        set => this.processEndDate = value;
    }

    [JsonPropertyName("oper_ic_code")]
    public string? OperIcCode
    {
        get => operIcCode;
        set => this.operIcCode = value;
    }

    [JsonPropertyName("upload_flag")]
    public string? UploadFlag
    {
        get => uploadFlag;
        set => this.uploadFlag = value;
    }

    [JsonPropertyName("crt_date")]
    public DateTime? CrtDate
    {
        get => crtDate;
        set => this.crtDate = value;
    }

    [JsonPropertyName("process_count")]
    public string? ProcessCount
    {
        get => processCount;
        set => this.processCount = value;
    }

    [JsonPropertyName("active_count")]
    public long? ActiveCount
    {
        get => activeCount;
        set => this.activeCount = value;
    }

    [JsonPropertyName("other_num")]
    public long? OtherNum
    {
        get => otherNum;
        set => this.otherNum = value;
    }

    [JsonPropertyName("small_num")]
    public long? SmallNum
    {
        get => smallNum;
        set => this.smallNum = value;
    }

    [JsonPropertyName("crt_date_string")]
    public string? CrtDateString
    {
        get => crtDateString;
        set => this.crtDateString = value;
    }

    [JsonPropertyName("bill_in_id")]
    public string? BillInId
    {
        get => billInId;
        set => this.billInId = value;
    }

    [JsonPropertyName("code_active_info_id")]
    public string? CodeActiveInfoId
    {
        get => codeActiveInfoId;
        set => this.codeActiveInfoId = value;
    }

}

