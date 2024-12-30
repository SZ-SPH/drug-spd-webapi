
namespace ZR.Model.Business
{
    /// <summary>
    /// 合同药品
    /// </summary>
    [SugarTable("SupplyContractDrug")]
    public class SupplyContractDrug
    {
        /// <summary>
        /// 合同药品的唯一标识符 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 合同编号 
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 合同药品的唯一标识符 
        /// </summary>
        public string DrugCode { get; set; }

        /// <summary>
        /// 启用状态 
        /// </summary>
        public string States { get; set; }

    }

    public class SupplyDrug
    {
        /// <summary>
        /// 合同药品的唯一标识符 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 合同编号 
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 合同药品的唯一标识符 
        /// </summary>
        public string DrugCode { get; set; }

        /// <summary>
        /// 启用状态 
        /// </summary>
        public string States { get; set; }
        /// <summary>
        /// id 
        /// </summary>
        public int DrugId { get; set; }

        /// <summary>
        /// 药品名称 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_NAME")]
        public string DrugName { get; set; }


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
        /// 药品追溯前八位识别码
        /// </summary>
        [SugarColumn(ColumnName = "ref_code")]
        public string RefCode { get; set; }

        /// <summary>
        /// 包装单位 
        /// </summary>
        [SugarColumn(ColumnName = "package_Unit")]
        public string PackageUnit { get; set; }
        /// <summary>
        /// hisid 
        /// </summary>
        public string HisID { get; set; }

        /// <summary>
        /// 价格 
        /// </summary>
        public decimal Price { get; set; }


        /// <summary>
        /// 默认货位 
        /// </summary>
        public string DefaultLocation { get; set; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        public string ChangeTime { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// HIS价格 
        /// </summary>
        [SugarColumn(ColumnName = "hIS_PRICE")]
        public decimal HisPrice { get; set; }

        /// <summary>
        /// 库房禁用 
        /// </summary>
        [SugarColumn(ColumnName = "kF_ENABLE")]
        public string KfEnable { get; set; }

        /// <summary>
        /// 药房禁用 
        /// </summary>
        [SugarColumn(ColumnName = "yF_ENABLE")]
        public string YfEnable { get; set; }
    }
}