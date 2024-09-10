using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgUploadretailRequest : AbstractTopApiRequest
{

    /*
        单据编号（唯一）
            */
    private string? billCode;


    /*
        单据时间（一般为药品入出库时间）
            */
    private DateTime? billTime;


    /*
        单据类型[323,零售出库][322,疫苗接种][116,消费者退货入库]
            */
    private long? billType;


    /*
        药品类型[2,特药，3,普药]【可以随便填写，单据上传后会以实际为准】
         默认值:3    */
    private long? physicType;


    /*
        上传单据的医疗机构在码上放心平台的ref_ent_id，可通过“通过企业名得到唯一标识”接口获取
            */
    private string? refUserId;


    /*
        发货企业(可为空)
            */
    private string? fromUserId;


    /*
        单据提交者(appkey编号、可为空)
            */
    private string? operIcCode;


    /*
        单据提交者姓名（可为空）
            */
    private string? operIcName;


    /*
        追溯码【多个码时用逗号拼接的字符串。要求数量在3500个码以下，但一般不要传这么多，如果网络不好很容易传输一半报错】；注意：在同一张单据里，不能有重复的码；在同一张单据中不能同时上传有关联关系的大、小码；
            */
    private IList<string>? traceCodes;


    /*
        购买人证件类型【1身份证2护照3 军官证4 医保卡5接种卡6学生证9其它】
            */
    private string? customerIdType;


    /*
        购买人证件编号
            */
    private string? customerId;


    /*
        用药人电话
            */
    private string? userTel;


    /*
        互联标识 1是  0否
            */
    private string? networkBillFlag;


    /*
        处方医师
            */
    private string? medicDoctor;


    /*
        发药人
            */
    private string? medicDispenser;


    /*
        患者（姓名、院内患者ID均可）
            */
    private string? userName;


    /*
        代理领药人
            */
    private string? userAgent;


    /*
        备注
            */
    private string? remarks;


    [JsonPropertyName("bill_code")]
    public string? BillCode
    {
        get => billCode;
        set => this.billCode = value;
    }

    [JsonPropertyName("bill_time")]
    public DateTime? BillTime
    {
        get => billTime;
        set => this.billTime = value;
    }

    [JsonPropertyName("bill_type")]
    public long? BillType
    {
        get => billType;
        set => this.billType = value;
    }

    [JsonPropertyName("physic_type")]
    public long? PhysicType
    {
        get => physicType;
        set => this.physicType = value;
    }

    [JsonPropertyName("ref_user_id")]
    public string? RefUserId
    {
        get => refUserId;
        set => this.refUserId = value;
    }

    [JsonPropertyName("from_user_id")]
    public string? FromUserId
    {
        get => fromUserId;
        set => this.fromUserId = value;
    }

    [JsonPropertyName("oper_ic_code")]
    public string? OperIcCode
    {
        get => operIcCode;
        set => this.operIcCode = value;
    }

    [JsonPropertyName("oper_ic_name")]
    public string? OperIcName
    {
        get => operIcName;
        set => this.operIcName = value;
    }

    [JsonPropertyName("trace_codes")]
    public IList<string>? TraceCodes
    {
        get => traceCodes;
        set => this.traceCodes = value;
    }

    [JsonPropertyName("customer_id_type")]
    public string? CustomerIdType
    {
        get => customerIdType;
        set => this.customerIdType = value;
    }

    [JsonPropertyName("customer_id")]
    public string? CustomerId
    {
        get => customerId;
        set => this.customerId = value;
    }

    [JsonPropertyName("user_tel")]
    public string? UserTel
    {
        get => userTel;
        set => this.userTel = value;
    }

    [JsonPropertyName("network_bill_flag")]
    public string? NetworkBillFlag
    {
        get => networkBillFlag;
        set => this.networkBillFlag = value;
    }

    [JsonPropertyName("medic_doctor")]
    public string? MedicDoctor
    {
        get => medicDoctor;
        set => this.medicDoctor = value;
    }

    [JsonPropertyName("medic_dispenser")]
    public string? MedicDispenser
    {
        get => medicDispenser;
        set => this.medicDispenser = value;
    }

    [JsonPropertyName("user_name")]
    public string? UserName
    {
        get => userName;
        set => this.userName = value;
    }

    [JsonPropertyName("user_agent")]
    public string? UserAgent
    {
        get => userAgent;
        set => this.userAgent = value;
    }

    [JsonPropertyName("remarks")]
    public string? Remarks
    {
        get => remarks;
        set => this.remarks = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.billCode != null)
        {
            requestParam.Add("bill_code",TopUtils.ConvertBasicType(this.billCode));
        }
        if(this.billTime != null)
        {
            requestParam.Add("bill_time",TopUtils.ConvertBasicType(this.billTime));
        }
        if(this.billType != null)
        {
            requestParam.Add("bill_type",TopUtils.ConvertBasicType(this.billType));
        }
        if(this.physicType != null)
        {
            requestParam.Add("physic_type",TopUtils.ConvertBasicType(this.physicType));
        }
        if(this.refUserId != null)
        {
            requestParam.Add("ref_user_id",TopUtils.ConvertBasicType(this.refUserId));
        }
        if(this.fromUserId != null)
        {
            requestParam.Add("from_user_id",TopUtils.ConvertBasicType(this.fromUserId));
        }
        if(this.operIcCode != null)
        {
            requestParam.Add("oper_ic_code",TopUtils.ConvertBasicType(this.operIcCode));
        }
        if(this.operIcName != null)
        {
            requestParam.Add("oper_ic_name",TopUtils.ConvertBasicType(this.operIcName));
        }
        if(this.traceCodes != null)
        {
            requestParam.Add("trace_codes",TopUtils.ConvertBasicList(this.traceCodes));
        }
        if(this.customerIdType != null)
        {
            requestParam.Add("customer_id_type",TopUtils.ConvertBasicType(this.customerIdType));
        }
        if(this.customerId != null)
        {
            requestParam.Add("customer_id",TopUtils.ConvertBasicType(this.customerId));
        }
        if(this.userTel != null)
        {
            requestParam.Add("user_tel",TopUtils.ConvertBasicType(this.userTel));
        }
        if(this.networkBillFlag != null)
        {
            requestParam.Add("network_bill_flag",TopUtils.ConvertBasicType(this.networkBillFlag));
        }
        if(this.medicDoctor != null)
        {
            requestParam.Add("medic_doctor",TopUtils.ConvertBasicType(this.medicDoctor));
        }
        if(this.medicDispenser != null)
        {
            requestParam.Add("medic_dispenser",TopUtils.ConvertBasicType(this.medicDispenser));
        }
        if(this.userName != null)
        {
            requestParam.Add("user_name",TopUtils.ConvertBasicType(this.userName));
        }
        if(this.userAgent != null)
        {
            requestParam.Add("user_agent",TopUtils.ConvertBasicType(this.userAgent));
        }
        if(this.remarks != null)
        {
            requestParam.Add("remarks",TopUtils.ConvertBasicType(this.remarks));
        }
        return requestParam;
    }

    public override IDictionary<string, TopFileItem> ToFileParam()
    {
        IDictionary<string, TopFileItem> fileParam = new Dictionary<string, TopFileItem>();
        return fileParam;
    }

    public override string GetApiCode()
    {
        return "alibaba.alihealth.drugtrace.top.yljg.uploadretail";
    }

}

