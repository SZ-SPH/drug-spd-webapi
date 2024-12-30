
namespace ZR.Model.Business
{
    /// <summary>
    /// 送货单
    /// </summary>
    [SugarTable("DeliveryOrder")]
    public class DeliveryOrder
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 备货单id 
        /// </summary>
        public int? StockId { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        public int? DrugId { get; set; }

        /// <summary>
        /// 单据号 
        /// </summary>
        public string BillCode { get; set; }

        /// <summary>
        /// 发票号 
        /// </summary>
        public string InvoiceNo { get; set; }

        /// <summary>
        /// 单据详情 
        /// </summary>
        public string DeliveryDetails { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        public string States { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 推送时间 
        /// </summary>
        public DateTime? PushTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatedBy { get; set; }

    }
}