namespace ZR.Model.Business
{
    /// <summary>
    /// 药品基础资料管理
    /// </summary>
   [Tenant(0)]
    [SugarTable("DRUG")]
    public class Drug
    {
        /// <summary>
        /// id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "dRUG_ID")]
        public int DrugId { get; set; }

        /// <summary>
        /// 药品名称 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_NAME")]
        public string DrugName { get; set; }

        /// <summary>
        /// 药品编号 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_CODE")]
        public string DrugCode { get; set; }

        /// <summary>
        /// 药品助记码 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_MNEMONIC_CODE")]
        public string DrugMnemonicCode { get; set; }

        /// <summary>
        /// 药品规格 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_SPECIFICATIONS")]
        public string DrugSpecifications { get; set; }

        /// <summary>
        /// 药品类别 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_CATEGORY")]
        public string DrugCategory { get; set; }

        /// <summary>
        /// 药品品种名称 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_VARIETY_NAME")]
        public string DrugVarietyName { get; set; }

        /// <summary>
        /// 药物分类 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_CLASSIFICATION")]
        public int? DrugClassification { get; set; }

        /// <summary>
        /// 溯源码 
        /// </summary>
        [SugarColumn(ColumnName = "tRACING_SOURCE_CODE")]
        public string TracingSourceCode { get; set; }

        /// <summary>
        /// 批号 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_BATCH_NUMBER")]
        public string DrugBatchNumber { get; set; }

        /// <summary>
        /// 最小单位 
        /// </summary>
        public string Minunit { get; set; }

        /// <summary>
        /// 生产厂家 
        /// </summary>
        [SugarColumn(ColumnName = "produce_Name")]
        public string ProduceName { get; set; }

        /// <summary>
        /// 转换系数 
        /// </summary>
        [SugarColumn(ColumnName = "package_Ratio")]
        public int? PackageRatio { get; set; }

        /// <summary>
        /// 包装单位 
        /// </summary>
        [SugarColumn(ColumnName = "package_Unit")]
        public string PackageUnit { get; set; }

    }
}