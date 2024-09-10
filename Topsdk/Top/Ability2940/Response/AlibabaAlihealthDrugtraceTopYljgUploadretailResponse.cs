using System.Collections.Generic;
using System.Text.Json.Serialization;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Response;

public class AlibabaAlihealthDrugtraceTopYljgUploadretailResponse : AbstractTopApiResponse
{

    /*
        上传单据文件队列表标识
            */
    private string? model;


    /*
        错误码(BILL_DECODE_ERROR 单据转码失败 2.BILL_FILE_NAME_DUPLICATE_UPLOAD 文件名重复)
            */
    private string? msgCode;


    /*
        错误信息
            */
    private string? msgInfo;


    /*
        操作是否成功(true 成功 ,false失败)
            */
    private bool? responseSuccess;


    [JsonPropertyName("model")]
    public string? Model
    {
        get => model;
        set => this.model = value;
    }

    [JsonPropertyName("msg_code")]
    public string? MsgCode
    {
        get => msgCode;
        set => this.msgCode = value;
    }

    [JsonPropertyName("msg_info")]
    public string? MsgInfo
    {
        get => msgInfo;
        set => this.msgInfo = value;
    }

    [JsonPropertyName("response_success")]
    public bool? ResponseSuccess
    {
        get => responseSuccess;
        set => this.responseSuccess = value;
    }

}

