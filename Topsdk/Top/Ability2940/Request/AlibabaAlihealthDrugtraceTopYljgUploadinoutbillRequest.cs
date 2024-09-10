using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgUploadinoutbillRequest : AbstractTopApiRequest
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
        单据类型：102代表采购入库、202代表退货出库、205代表销毁出库
            */
    private long? billType;


    /*
        药品类型[2,特药，3,普药]【可以随便填写，单据上传后会以实际为准】
            */
    private long? physicType;


    /*
        上传单据的医疗机构在码上放心平台的ref_ent_id，可通过“通过企业名得到唯一标识”接口获取
            */
    private string? refUserId;


    /*
        代理企业REF标识
            */
    private string? agentRefUserId;


    /*
        发货企业ent_id，可通过“通过企业名得到唯一标识”接口获取；（102采购入库填药品供应商id、202退货出库填医院id、205销毁出库填医院id）
            */
    private string? fromUserId;


    /*
        收货企业ent_id，可通过“通过企业名得到唯一标识”接口获取；（102采购入库填医院id、202退货出库填药品供应商id、205销毁出库填医院id）
            */
    private string? toUserId;


    /*
        直调企业标识
            */
    private string? destUserId;


    /*
        单据提交者(appkey编号、可为空)
            */
    private string? operIcCode;


    /*
        单据提交者姓名（可为空）
            */
    private string? operIcName;


    /*
        仓号
            */
    private string? warehouseId;


    /*
        药品ID[企业自已系统的药品ID]
            */
    private string? drugId;


    /*
        追溯码【多个码时用逗号拼接的字符串。要求数量在3500个码以下，但一般不要传这么多，如果网络不好很容易传输一半报错】注意：在同一张单据里，不能有重复的码；在同一张单据中不能同时上传有关联关系的大、小码
            */
    private IList<string>? traceCodes;


    /*
        客户端类型[必须填2]
            */
    private string? clientType;


    /*
        退货原因代码[退货入出库时填写]（1:破损  2:召回  3:滞销  4:过期失效  5:近效期  6:其他）
            */
    private string? returnReasonCode;


    /*
        退货原因描述[退货入出库时填写]
            */
    private string? returnReasonDes;


    /*
        注销原因代码【销毁出库时填写】（1:破损  2:霉变  3:过期失效  4:其他）
            */
    private string? cancelReasonCode;


    /*
        注销原因描述【销毁出库时填写】
            */
    private string? cancelReasonDes;


    /*
        执行人姓名【销毁出库时填写】
            */
    private string? executerName;


    /*
        执行人证件号【销毁出库时填写】
            */
    private string? executerCode;


    /*
        监督人姓名【销毁出库时填写】
            */
    private string? superviserName;


    /*
        监督人证件号【销毁出库时填写】
            */
    private string? superviserCode;


    /*
        （协同平台数据合规）发货地址（可为空）
            */
    private string? fromAddress;


    /*
        （协同平台数据合规）收货地址（可为空）
            */
    private string? toAddress;


    /*
        （协同平台数据合规）发货单编号（可为空）
            */
    private string? fromBillCode;


    /*
        （协同平台数据合规）订货单编号（可为空）
            */
    private string? orderCode;


    /*
        （协同平台数据合规）发货人（可为空）
            */
    private string? fromPerson;


    /*
        （协同平台数据合规）收货人（可为空）
            */
    private string? toPerson;


    /*
        （协同平台数据合规）药品配送企业【添写ref_ent_id】
            */
    private string? disRefEntId;


    /*
        （协同平台数据合规）药品配送企业entId【添写ent_id】
            */
    private string? disEntId;


    /*
        （协同平台数据合规）应收货总数量（可为空）
            */
    private long? quReceivable;


    /*
        （协同平台数据合规）是否验证，0：未通过验证，1：已验证
            */
    private string? xtIsCheck;


    /*
        （协同平台数据合规）未验证通过原因【验证未通过时填写】
            */
    private string? xtCheckCode;


    /*
        （协同平台数据合规）未验证通过原因描述【验证未通过时填写】
            */
    private string? xtCheckCodeDesc;


    /*
        （协同平台数据合规）药品列表Json[可不填写]
            */
    private string? drugListJson;


    /*
        （协同平台数据合规）单据委托企业refEntId【疫苗药品出库单填写】
            */
    private string? assRefEntId;


    /*
        （协同平台数据合规）单据委托企业entId【疫苗药品出库单填写】
            */
    private string? assEntId;


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

    [JsonPropertyName("agent_ref_user_id")]
    public string? AgentRefUserId
    {
        get => agentRefUserId;
        set => this.agentRefUserId = value;
    }

    [JsonPropertyName("from_user_id")]
    public string? FromUserId
    {
        get => fromUserId;
        set => this.fromUserId = value;
    }

    [JsonPropertyName("to_user_id")]
    public string? ToUserId
    {
        get => toUserId;
        set => this.toUserId = value;
    }

    [JsonPropertyName("dest_user_id")]
    public string? DestUserId
    {
        get => destUserId;
        set => this.destUserId = value;
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

    [JsonPropertyName("warehouse_id")]
    public string? WarehouseId
    {
        get => warehouseId;
        set => this.warehouseId = value;
    }

    [JsonPropertyName("drug_id")]
    public string? DrugId
    {
        get => drugId;
        set => this.drugId = value;
    }

    [JsonPropertyName("trace_codes")]
    public IList<string>? TraceCodes
    {
        get => traceCodes;
        set => this.traceCodes = value;
    }

    [JsonPropertyName("client_type")]
    public string? ClientType
    {
        get => clientType;
        set => this.clientType = value;
    }

    [JsonPropertyName("return_reason_code")]
    public string? ReturnReasonCode
    {
        get => returnReasonCode;
        set => this.returnReasonCode = value;
    }

    [JsonPropertyName("return_reason_des")]
    public string? ReturnReasonDes
    {
        get => returnReasonDes;
        set => this.returnReasonDes = value;
    }

    [JsonPropertyName("cancel_reason_code")]
    public string? CancelReasonCode
    {
        get => cancelReasonCode;
        set => this.cancelReasonCode = value;
    }

    [JsonPropertyName("cancel_reason_des")]
    public string? CancelReasonDes
    {
        get => cancelReasonDes;
        set => this.cancelReasonDes = value;
    }

    [JsonPropertyName("executer_name")]
    public string? ExecuterName
    {
        get => executerName;
        set => this.executerName = value;
    }

    [JsonPropertyName("executer_code")]
    public string? ExecuterCode
    {
        get => executerCode;
        set => this.executerCode = value;
    }

    [JsonPropertyName("superviser_name")]
    public string? SuperviserName
    {
        get => superviserName;
        set => this.superviserName = value;
    }

    [JsonPropertyName("superviser_code")]
    public string? SuperviserCode
    {
        get => superviserCode;
        set => this.superviserCode = value;
    }

    [JsonPropertyName("from_address")]
    public string? FromAddress
    {
        get => fromAddress;
        set => this.fromAddress = value;
    }

    [JsonPropertyName("to_address")]
    public string? ToAddress
    {
        get => toAddress;
        set => this.toAddress = value;
    }

    [JsonPropertyName("from_bill_code")]
    public string? FromBillCode
    {
        get => fromBillCode;
        set => this.fromBillCode = value;
    }

    [JsonPropertyName("order_code")]
    public string? OrderCode
    {
        get => orderCode;
        set => this.orderCode = value;
    }

    [JsonPropertyName("from_person")]
    public string? FromPerson
    {
        get => fromPerson;
        set => this.fromPerson = value;
    }

    [JsonPropertyName("to_person")]
    public string? ToPerson
    {
        get => toPerson;
        set => this.toPerson = value;
    }

    [JsonPropertyName("dis_ref_ent_id")]
    public string? DisRefEntId
    {
        get => disRefEntId;
        set => this.disRefEntId = value;
    }

    [JsonPropertyName("dis_ent_id")]
    public string? DisEntId
    {
        get => disEntId;
        set => this.disEntId = value;
    }

    [JsonPropertyName("qu_receivable")]
    public long? QuReceivable
    {
        get => quReceivable;
        set => this.quReceivable = value;
    }

    [JsonPropertyName("xt_is_check")]
    public string? XtIsCheck
    {
        get => xtIsCheck;
        set => this.xtIsCheck = value;
    }

    [JsonPropertyName("xt_check_code")]
    public string? XtCheckCode
    {
        get => xtCheckCode;
        set => this.xtCheckCode = value;
    }

    [JsonPropertyName("xt_check_code_desc")]
    public string? XtCheckCodeDesc
    {
        get => xtCheckCodeDesc;
        set => this.xtCheckCodeDesc = value;
    }

    [JsonPropertyName("drug_list_json")]
    public string? DrugListJson
    {
        get => drugListJson;
        set => this.drugListJson = value;
    }

    [JsonPropertyName("ass_ref_ent_id")]
    public string? AssRefEntId
    {
        get => assRefEntId;
        set => this.assRefEntId = value;
    }

    [JsonPropertyName("ass_ent_id")]
    public string? AssEntId
    {
        get => assEntId;
        set => this.assEntId = value;
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
        if(this.agentRefUserId != null)
        {
            requestParam.Add("agent_ref_user_id",TopUtils.ConvertBasicType(this.agentRefUserId));
        }
        if(this.fromUserId != null)
        {
            requestParam.Add("from_user_id",TopUtils.ConvertBasicType(this.fromUserId));
        }
        if(this.toUserId != null)
        {
            requestParam.Add("to_user_id",TopUtils.ConvertBasicType(this.toUserId));
        }
        if(this.destUserId != null)
        {
            requestParam.Add("dest_user_id",TopUtils.ConvertBasicType(this.destUserId));
        }
        if(this.operIcCode != null)
        {
            requestParam.Add("oper_ic_code",TopUtils.ConvertBasicType(this.operIcCode));
        }
        if(this.operIcName != null)
        {
            requestParam.Add("oper_ic_name",TopUtils.ConvertBasicType(this.operIcName));
        }
        if(this.warehouseId != null)
        {
            requestParam.Add("warehouse_id",TopUtils.ConvertBasicType(this.warehouseId));
        }
        if(this.drugId != null)
        {
            requestParam.Add("drug_id",TopUtils.ConvertBasicType(this.drugId));
        }
        if(this.traceCodes != null)
        {
            requestParam.Add("trace_codes",TopUtils.ConvertBasicList(this.traceCodes));
        }
        if(this.clientType != null)
        {
            requestParam.Add("client_type",TopUtils.ConvertBasicType(this.clientType));
        }
        if(this.returnReasonCode != null)
        {
            requestParam.Add("return_reason_code",TopUtils.ConvertBasicType(this.returnReasonCode));
        }
        if(this.returnReasonDes != null)
        {
            requestParam.Add("return_reason_des",TopUtils.ConvertBasicType(this.returnReasonDes));
        }
        if(this.cancelReasonCode != null)
        {
            requestParam.Add("cancel_reason_code",TopUtils.ConvertBasicType(this.cancelReasonCode));
        }
        if(this.cancelReasonDes != null)
        {
            requestParam.Add("cancel_reason_des",TopUtils.ConvertBasicType(this.cancelReasonDes));
        }
        if(this.executerName != null)
        {
            requestParam.Add("executer_name",TopUtils.ConvertBasicType(this.executerName));
        }
        if(this.executerCode != null)
        {
            requestParam.Add("executer_code",TopUtils.ConvertBasicType(this.executerCode));
        }
        if(this.superviserName != null)
        {
            requestParam.Add("superviser_name",TopUtils.ConvertBasicType(this.superviserName));
        }
        if(this.superviserCode != null)
        {
            requestParam.Add("superviser_code",TopUtils.ConvertBasicType(this.superviserCode));
        }
        if(this.fromAddress != null)
        {
            requestParam.Add("from_address",TopUtils.ConvertBasicType(this.fromAddress));
        }
        if(this.toAddress != null)
        {
            requestParam.Add("to_address",TopUtils.ConvertBasicType(this.toAddress));
        }
        if(this.fromBillCode != null)
        {
            requestParam.Add("from_bill_code",TopUtils.ConvertBasicType(this.fromBillCode));
        }
        if(this.orderCode != null)
        {
            requestParam.Add("order_code",TopUtils.ConvertBasicType(this.orderCode));
        }
        if(this.fromPerson != null)
        {
            requestParam.Add("from_person",TopUtils.ConvertBasicType(this.fromPerson));
        }
        if(this.toPerson != null)
        {
            requestParam.Add("to_person",TopUtils.ConvertBasicType(this.toPerson));
        }
        if(this.disRefEntId != null)
        {
            requestParam.Add("dis_ref_ent_id",TopUtils.ConvertBasicType(this.disRefEntId));
        }
        if(this.disEntId != null)
        {
            requestParam.Add("dis_ent_id",TopUtils.ConvertBasicType(this.disEntId));
        }
        if(this.quReceivable != null)
        {
            requestParam.Add("qu_receivable",TopUtils.ConvertBasicType(this.quReceivable));
        }
        if(this.xtIsCheck != null)
        {
            requestParam.Add("xt_is_check",TopUtils.ConvertBasicType(this.xtIsCheck));
        }
        if(this.xtCheckCode != null)
        {
            requestParam.Add("xt_check_code",TopUtils.ConvertBasicType(this.xtCheckCode));
        }
        if(this.xtCheckCodeDesc != null)
        {
            requestParam.Add("xt_check_code_desc",TopUtils.ConvertBasicType(this.xtCheckCodeDesc));
        }
        if(this.drugListJson != null)
        {
            requestParam.Add("drug_list_json",TopUtils.ConvertBasicType(this.drugListJson));
        }
        if(this.assRefEntId != null)
        {
            requestParam.Add("ass_ref_ent_id",TopUtils.ConvertBasicType(this.assRefEntId));
        }
        if(this.assEntId != null)
        {
            requestParam.Add("ass_ent_id",TopUtils.ConvertBasicType(this.assEntId));
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
        return "alibaba.alihealth.drugtrace.top.yljg.uploadinoutbill";
    }

}

