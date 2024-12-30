
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 送货单查询对象
    /// </summary>
    public class DeliveryOrderQueryDto : PagerInfo 
    {
        public string BillCode { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? BeginCreateTime { get; set; }
        public DateTime? EndCreateTime { get; set; }
        public DateTime? BeginPushTime { get; set; }
        public DateTime? EndPushTime { get; set; }
    }

    /// <summary>
    /// 送货单输入输出对象
    /// </summary>
    public class DeliveryOrderDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "备货单id")]
        [ExcelColumnName("备货单id")]
        public int? StockId { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public int? DrugId { get; set; }

        [ExcelColumn(Name = "单据号")]
        [ExcelColumnName("单据号")]
        public string BillCode { get; set; }

        [ExcelColumn(Name = "发票号")]
        [ExcelColumnName("发票号")]
        public string InvoiceNo { get; set; }

        [ExcelColumn(Name = "单据详情")]
        [ExcelColumnName("单据详情")]
        public string DeliveryDetails { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remarks { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string States { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelColumn(Name = "推送时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("推送时间")]
        public DateTime? PushTime { get; set; }



        [ExcelColumn(Name = "创建人")]
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }


    }
}