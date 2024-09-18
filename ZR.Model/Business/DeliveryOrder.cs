
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
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 备货单 
        /// </summary>
        public string StockId { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        public string DrugId { get; set; }

        /// <summary>
        /// 送货药品 
        /// </summary>
        public string DeliveryTime { get; set; }

        /// <summary>
        /// 单据详情 
        /// </summary>
        public string DeliveryDetails { get; set; }

        /// <summary>
        /// 配送医院 
        /// </summary>
        public string DeliveryHospital { get; set; }

        /// <summary>
        /// 配送地址 
        /// </summary>
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// 配送人 
        /// </summary>
        public string DeliveryPerson { get; set; }

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
        public string CreateTime { get; set; }

    }
}