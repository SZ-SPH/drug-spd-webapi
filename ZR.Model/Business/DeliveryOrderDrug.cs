
namespace ZR.Model.Business
{
    /// <summary>
    /// 送货单药品
    /// </summary>
    [SugarTable("DeliveryOrderDrug")]
    public class DeliveryOrderDrug
    {
        /// <summary>
        /// Id，自增主键 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }
        public int Mixqty { get; set; }

        
        /// <summary>
        /// 送货单 
        /// </summary>
        public int? DeliveryId { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        public int? DrugId { get; set; }

        /// <summary>
        /// 药品名称 
        /// </summary>
        public string DrugName { get; set; }

        /// <summary>
        /// 药品编号 
        /// </summary>
        public string DrugCode { get; set; }

        /// <summary>
        /// 药品规格 
        /// </summary>
        public string DrugSpecification { get; set; }

        /// <summary>
        /// 药品批号 
        /// </summary>
        public string DrugBatchNo { get; set; }

        /// <summary>
        /// 生产厂家 
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// 单价 
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 药品数量 
        /// </summary>
        public int? DrugQuantity { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remarks { get; set; }
        public string Minunit { get; set; }
        public int? PackageRatio { get; set; }
        public string PackageUnit { get; set; }
        public string Exprie { get; set; }
        public string DateOfManufacture { get; set; }
        public int count { get; set; }

    }

    [SugarTable("VDrugsGYS")]

    public class VdrugsGYS
    {
        public int Ids { get; set; }
        public int CodeCount { get; set; }
    }
}