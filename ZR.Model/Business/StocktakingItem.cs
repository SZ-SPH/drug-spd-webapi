
namespace ZR.Model.Business
{
    /// <summary>
    /// 盘点明细
    /// </summary>
    [SugarTable("T_STOCKTAKING_ITEM")]
    public class StocktakingItem
    {
        /// <summary>
        /// ID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(ColumnName = "TRACINGCODE_PREFIX")]
        public string TracingCodePrefix { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "cREATE_TIME")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        [SugarColumn(ColumnName = "uPDATE_TIME")]
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 盘点单号主表ID 
        /// </summary>
        [SugarColumn(ColumnName = "sTOCK_MAIN_ID")]
        public int? StockMainId { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        [SugarColumn(ColumnName = "DRUG_NAME")]
        public string DrugName { get; set; }

        [SugarColumn(ColumnName = "DRUG_QTY")]
        public string DrugQty { get; set; }

        [SugarColumn(ColumnName = "STOCKTAKING_QTY")]
        public string StocktakingQty { get; set; }

        [SugarColumn(ColumnName = "DRUG_SPEC")]
        public string DrugSpec { get; set; }

        [SugarColumn(ColumnName = "DRUG_CATEGORY")]
        public string DrugCategory { get; set; }

        [SugarColumn(ColumnName = "DRUG_MNEMONICCODE")]
        public string DrugMnemonicCode { get; set; }

        [SugarColumn(ColumnName = "BATCH_NO")]
        public string BatchNo { get; set; }

        [SugarColumn(ColumnName = "BATCH_NUM")]
        public string BatchNum { get; set; }

    }
}