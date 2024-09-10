using Topsdk.Top.Ability2940.Request;
using Topsdk.Top.Ability2940.Response;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940;


public class Ability2940
{

    private ITopApiClient topApiClient;

    public Ability2940(ITopApiClient topApiClient)
    {
        this.topApiClient = topApiClient;
    }

    /*
        获取服务截止日期
        alibaba.alihealth.drugtrace.top.yljg.service.getenddate
    */
    public AlibabaAlihealthDrugtraceTopYljgServiceGetenddateResponse AlibabaAlihealthDrugtraceTopYljgServiceGetenddate(AlibabaAlihealthDrugtraceTopYljgServiceGetenddateRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgServiceGetenddateResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        零售单据上传接口
        alibaba.alihealth.drugtrace.top.yljg.uploadretail
    */
    public AlibabaAlihealthDrugtraceTopYljgUploadretailResponse AlibabaAlihealthDrugtraceTopYljgUploadretail(AlibabaAlihealthDrugtraceTopYljgUploadretailRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgUploadretailResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        获取重点追溯品种明细下载URL
        alibaba.alihealth.drugtrace.top.yljg.getkeyflagdruginfo.downloadurl
    */
    public AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlResponse AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurl(AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgGetkeyflagdruginfoDownloadurlResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        出入库单据上传
        alibaba.alihealth.drugtrace.top.yljg.uploadinoutbill
    */
    public AlibabaAlihealthDrugtraceTopYljgUploadinoutbillResponse AlibabaAlihealthDrugtraceTopYljgUploadinoutbill(AlibabaAlihealthDrugtraceTopYljgUploadinoutbillRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgUploadinoutbillResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        上传单据后处理状态查询
        alibaba.alihealth.drugtrace.top.yljg.query.billstatus
    */
    public AlibabaAlihealthDrugtraceTopYljgQueryBillstatusResponse AlibabaAlihealthDrugtraceTopYljgQueryBillstatus(AlibabaAlihealthDrugtraceTopYljgQueryBillstatusRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgQueryBillstatusResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        查询药品信息
        alibaba.alihealth.drugtrace.top.yljg.getdruglist
    */
    public AlibabaAlihealthDrugtraceTopYljgGetdruglistResponse AlibabaAlihealthDrugtraceTopYljgGetdruglist(AlibabaAlihealthDrugtraceTopYljgGetdruglistRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgGetdruglistResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        通过一个码，查询这个码对应的上游企业出库单的单据号
        alibaba.alihealth.drugtrace.top.yljg.query.upbillcode
    */
    public AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeResponse AlibabaAlihealthDrugtraceTopYljgQueryUpbillcode(AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgQueryUpbillcodeResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        往来单位查询
        alibaba.alihealth.drugtrace.top.yljg.query.listparts
    */
    public AlibabaAlihealthDrugtraceTopYljgQueryListpartsResponse AlibabaAlihealthDrugtraceTopYljgQueryListparts(AlibabaAlihealthDrugtraceTopYljgQueryListpartsRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgQueryListpartsResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        根据单据号查询单据的详情信息【注意：查询的是本企业的单据】
        alibaba.alihealth.drugtrace.top.yljg.query.upbilldetail
    */
    public AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailResponse AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetail(AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgQueryUpbilldetailResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        单码关联关系查询
        alibaba.alihealth.drugtrace.top.yljg.query.relation
    */
    public AlibabaAlihealthDrugtraceTopYljgQueryRelationResponse AlibabaAlihealthDrugtraceTopYljgQueryRelation(AlibabaAlihealthDrugtraceTopYljgQueryRelationRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgQueryRelationResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        通过企业名得到唯一标识ref_ent_id及企业ent_id
        alibaba.alihealth.drugtrace.top.yljg.query.getentinfo
    */
    public AlibabaAlihealthDrugtraceTopYljgQueryGetentinfoResponse AlibabaAlihealthDrugtraceTopYljgQueryGetentinfo(AlibabaAlihealthDrugtraceTopYljgQueryGetentinfoRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgQueryGetentinfoResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        根据码查询码信息
        alibaba.alihealth.drugtrace.top.yljg.query.codedetail
    */
    public AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResponse AlibabaAlihealthDrugtraceTopYljgQueryCodedetail(AlibabaAlihealthDrugtraceTopYljgQueryCodedetailRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgQueryCodedetailResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        医疗机构查询本企业上游企业出库单据信息
        alibaba.alihealth.drugtrace.top.yljg.listupout
    */
    public AlibabaAlihealthDrugtraceTopYljgListupoutResponse AlibabaAlihealthDrugtraceTopYljgListupout(AlibabaAlihealthDrugtraceTopYljgListupoutRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgListupoutResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        查询药品目录信息
        alibaba.alihealth.drugtrace.top.yljg.drugtable
    */
    public AlibabaAlihealthDrugtraceTopYljgDrugtableResponse AlibabaAlihealthDrugtraceTopYljgDrugtable(AlibabaAlihealthDrugtraceTopYljgDrugtableRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgDrugtableResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        上游出库单单据明细查询
        alibaba.alihealth.drugtrace.top.yljg.listupout.detail
    */
    public AlibabaAlihealthDrugtraceTopYljgListupoutDetailResponse AlibabaAlihealthDrugtraceTopYljgListupoutDetail(AlibabaAlihealthDrugtraceTopYljgListupoutDetailRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgListupoutDetailResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }
    /*
        根据企业唯一标识查看企业详细信息
        alibaba.alihealth.drugtrace.top.yljg.query.getbyrefentid
    */
    public AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentidResponse AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentid(AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentidRequest request)
    {
        var jsonResult = topApiClient.Execute(request.GetApiCode(),request.ToRequestParam(),request.ToFileParam());
        if (string.IsNullOrEmpty(jsonResult))
        {
            throw new Exception("error");
        }
        var resultObj = TopUtils.parseResultJson<AlibabaAlihealthDrugtraceTopYljgQueryGetbyrefentidResponse>(jsonResult);
        if(string.IsNullOrEmpty(resultObj.Body))
        {
            resultObj.Body = jsonResult;
        }
        return resultObj;
    }

    public ITopApiClient TopApiClient
    {
        get => topApiClient;
        set => topApiClient = value ?? throw new ArgumentNullException(nameof(value));
    }
}
