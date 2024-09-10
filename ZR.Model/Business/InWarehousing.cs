
namespace ZR.Model.Business
{
    /// <summary>
    /// 入库信息
    /// </summary>
    [SugarTable("InWarehousing")]
    public class InWarehousing
    {
        /// <summary>
        /// id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_ID")]
        public int? DrugId { get; set; }

        /// <summary>
        /// 药品编码 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_CODE")]
        public string DrugCode { get; set; }

        /// <summary>
        /// 药品溯源码 
        /// </summary>
        [SugarColumn(ColumnName = "tRACING_SOURCE_CODE")]
        public string TracingSourceCode { get; set; }

        /// <summary>
        /// 药品批号 
        /// </summary>
        [SugarColumn(ColumnName = "bATCH_NUMBER")]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 药品入库数量 
        /// </summary>
        [SugarColumn(ColumnName = "iNVENTORY_QUANTITY")]
        public string InventoryQuantity { get; set; }

        /// <summary>
        /// 药品规格 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_SPECIFICATIONS")]
        public string DrugSpecifications { get; set; }
        /// <summary>
        /// 入库单据id 
        /// </summary>
        [SugarColumn(ColumnName = "rECEIPT_ID")]
        public int? ReceiptId { get; set; }
    }
}