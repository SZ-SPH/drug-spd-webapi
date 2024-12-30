
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
        public int DrugId { get; set; }

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
        public int InventoryQuantity { get; set; }

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


        /// <summary>
        /// 生产厂家 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string ManufacturerId { get; set; }
        /// <summary>
        /// 有效期 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string Exprie { get; set; }

        /// <summary>
        /// 价格 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public decimal? Price { get; set; }
        /// <summary>
        /// 货位号 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string LocationNumber { get; set; }
        /// <summary>
        /// 生产日期 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string DateOfManufacture { get; set; }
        /// 最小单位 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string Minunit { get; set; }
        //[ExcelColumn(Name = "转换系数")]
        //[ExcelColumnName("转换系数")]
        public int? PackageRatio { get; set; }

        //[ExcelColumn(Name = "包装单位")]
        //[ExcelColumnName("包装单位")]
        public string PackageUnit { get; set; }


    }
}