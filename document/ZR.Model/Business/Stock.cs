
namespace ZR.Model.Business
{
    /// <summary>
    /// 库存
    /// </summary>
    [SugarTable("stock")]
    public class Stock
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 药品 
        /// </summary>
        public int? DrugId { get; set; }

        /// <summary>
        /// 药品数量 
        /// </summary>
        public int? Drugqty { get; set; }

        /// <summary>
        /// 购入价 
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 零售价 
        /// </summary>
        public decimal RetailPrice { get; set; }

        /// <summary>
        /// 库存量 
        /// </summary>
        public string InventoryQuantity { get; set; }

        /// <summary>
        /// 预扣数量 
        /// </summary>
        public string DeQuantity { get; set; }

        /// <summary>
        /// 库存（库存量-预扣） 
        /// </summary>
        public string ActualStock { get; set; }

        /// <summary>
        /// 最小单位 
        /// </summary>
        public string SUnit { get; set; }

        /// <summary>
        /// 包装数量 
        /// </summary>
        public int? Packqty { get; set; }

        /// <summary>
        /// 包装单位 
        /// </summary>
        public string PackUnit { get; set; }

        /// <summary>
        /// 批号 
        /// </summary>
        public string BatchON { get; set; }

        /// <summary>
        /// 批次号 
        /// </summary>
        [SugarColumn(ColumnName = "batch_Num")]
        public int? BatchNum { get; set; }

        /// <summary>
        /// 库房 
        /// </summary>
        public int? WarehouseID { get; set; }

    }
}