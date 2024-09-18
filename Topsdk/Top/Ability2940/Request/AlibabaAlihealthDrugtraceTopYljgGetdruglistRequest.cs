using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Request;

public class AlibabaAlihealthDrugtraceTopYljgGetdruglistRequest : AbstractTopApiRequest
{

    /*
        企业ID
            */
    private string? refEntId;


    /*
        药品通用名
            */
    private string? physicName;


    /*
        批准文号
            */
    private string? approvalLicenceNo;


    /*
        包装规格
            */
    private string? packageSpec;


    /*
        制剂规格
            */
    private string? prepnSpec;


    /*
        页大小
            */
    private long? pageSize;


    /*
        页码
            */
    private long? page;


    [JsonPropertyName("ref_ent_id")]
    public string? RefEntId
    {
        get => refEntId;
        set => this.refEntId = value;
    }

    [JsonPropertyName("physic_name")]
    public string? PhysicName
    {
        get => physicName;
        set => this.physicName = value;
    }

    [JsonPropertyName("approval_licence_no")]
    public string? ApprovalLicenceNo
    {
        get => approvalLicenceNo;
        set => this.approvalLicenceNo = value;
    }

    [JsonPropertyName("package_spec")]
    public string? PackageSpec
    {
        get => packageSpec;
        set => this.packageSpec = value;
    }

    [JsonPropertyName("prepn_spec")]
    public string? PrepnSpec
    {
        get => prepnSpec;
        set => this.prepnSpec = value;
    }

    [JsonPropertyName("page_size")]
    public long? PageSize
    {
        get => pageSize;
        set => this.pageSize = value;
    }

    [JsonPropertyName("page")]
    public long? Page
    {
        get => page;
        set => this.page = value;
    }



    public override IDictionary<string, string> ToRequestParam()
    {
        IDictionary<string, string> requestParam = new Dictionary<string, string>();
        if(this.refEntId != null)
        {
            requestParam.Add("ref_ent_id",TopUtils.ConvertBasicType(this.refEntId));
        }
        if(this.physicName != null)
        {
            requestParam.Add("physic_name",TopUtils.ConvertBasicType(this.physicName));
        }
        if(this.approvalLicenceNo != null)
        {
            requestParam.Add("approval_licence_no",TopUtils.ConvertBasicType(this.approvalLicenceNo));
        }
        if(this.packageSpec != null)
        {
            requestParam.Add("package_spec",TopUtils.ConvertBasicType(this.packageSpec));
        }
        if(this.prepnSpec != null)
        {
            requestParam.Add("prepn_spec",TopUtils.ConvertBasicType(this.prepnSpec));
        }
        if(this.pageSize != null)
        {
            requestParam.Add("page_size",TopUtils.ConvertBasicType(this.pageSize));
        }
        if(this.page != null)
        {
            requestParam.Add("page",TopUtils.ConvertBasicType(this.page));
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
        return "alibaba.alihealth.drugtrace.top.yljg.getdruglist";
    }

}

