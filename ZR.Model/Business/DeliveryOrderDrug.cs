
namespace ZR.Model.Business
{
    /// <summary>
    /// 送货单药品
    /// </summary>
    [SugarTable("DeliveryOrderDrug")]
    public class DeliveryOrderDrug
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// DeliveryId 
        /// </summary>
        public string DeliveryId { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        public string DrugId { get; set; }

        /// <summary>
        /// 药品信息 
        /// </summary>
        public string DrugDetails { get; set; }

        /// <summary>
        /// 数量 
        /// </summary>
        public string DrugQuantity { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remarks { get; set; }

    }
}