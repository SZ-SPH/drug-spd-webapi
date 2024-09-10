using System.Text.Json.Serialization;
using System.Collections.Generic;
using Topsdk.Util;

namespace Topsdk.Top.Ability2940.Domain;

public class AlibabaAlihealthDrugtraceTopYljgQueryRelationProduceInfoDto
{

    /*
        生产日期
    */
    private DateTime? produceDate;


    /*
        有效期
    */
    private string? expireDate;


    /*
        批次号
    */
    private string? batchNo;


    /*
        码
    */
    private string? code;


    /*
        最小包装数量
    */
    private string? pkgAmount;



    [JsonPropertyName("produce_date")]
    public DateTime? ProduceDate
    {
        get => produceDate;
        set => this.produceDate = value;
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

    [JsonPropertyName("code")]
    public string? Code
    {
        get => code;
        set => this.code = value;
    }

    [JsonPropertyName("pkg_amount")]
    public string? PkgAmount
    {
        get => pkgAmount;
        set => this.pkgAmount = value;
    }

}

