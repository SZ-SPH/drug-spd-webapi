namespace ZR.Model.Business
{
    /// <summary>
    /// 备货单
    /// </summary>
    [SugarTable("StockOrder")]
    public class StockOrder
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 入库单id 
        /// </summary>
        public int? ReceiptId { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        public int? DrugId { get; set; }

        /// <summary>
        /// 配送数量 
        /// </summary>
        public int? DeliveryQuantity { get; set; }

        /// <summary>
        /// 配送医院 
        /// </summary>
        public string DeliveryHospital { get; set; }

        /// <summary>
        /// 配送地址 
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 配送时间 
        /// </summary>
        public string DeliveryTime { get; set; }

        /// <summary>
        /// 配送人 
        /// </summary>
        public string DeliveryPerson { get; set; }

    }
}