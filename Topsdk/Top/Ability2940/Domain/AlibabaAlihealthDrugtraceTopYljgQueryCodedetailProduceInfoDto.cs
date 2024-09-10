using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryCodedetailProduceInfoDto
{

    /*
        生产日期
    */
    private string? produceDateStr;


    /*
        最小包装数量
    */
    private string? pkgAmount;


    /*
        有效期至
    */
    private string? expireDate;


    /*
        批次号
    */
    private string? batchNo;



    [JsonPropertyName("produce_date_str")]
    public string? ProduceDateStr
    {
        get => produceDateStr;
        set => this.produceDateStr = value;
    }

    [JsonPropertyName("pkg_amount")]
    public string? PkgAmount
    {
        get => pkgAmount;
        set => this.pkgAmount = value;
    }

    [JsonPropertyName("expire_date")]
    public string? ExpireDate
    {
        get => expireDate;
        set => this.expireDate = value;
    }

    [JsonPropertyName("batch_no")]
    public string? BatchNo
    {
        get => batchNo;
        set => this.batchNo = value;
    }

}

