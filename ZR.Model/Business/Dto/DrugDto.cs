namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 药品基础资料管理查询对象
    /// </summary>
    public class DrugQueryDto : PagerInfo
    {
        public string DrugName { get; set; }
        public string DrugCode { get; set; }
        public string DrugMnemonicCode { get; set; }
    }
    public class GYSDrugQueryDto : PagerInfo
    {
        public string SupplierName { get; set; }
        public string DrugName { get; set; }
        public string DrugCode { get; set; }
        public string DrugMnemonicCode { get; set; }
    }
    /// <summary>
    /// 药品基础资料管理输入输出对象
    /// </summary>
    public class DrugDto
    {
        [Required(ErrorMessage = "id不能为空")]
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        public int DrugId { get; set; }

        [ExcelColumn(Name = "药品名称")]
        [ExcelColumnName("药品名称")]
        public string DrugName { get; set; }

        [ExcelColumn(Name = "药品编号")]
        [ExcelColumnName("药品编号")]
        public string DrugCode { get; set; }

        [ExcelColumn(Name = "药品助记码")]
        [ExcelColumnName("药品助记码")]
        public string DrugMnemonicCode { get; set; }

        [ExcelColumn(Name = "药品规格")]
        [ExcelColumnName("药品规格")]
        public string DrugSpecifications { get; set; }

        [ExcelColumn(Name = "药品类别")]
        [ExcelColumnName("药品类别")]
        public string DrugCategory { get; set; }

        [ExcelColumn(Name = "药品品种名称")]
        [ExcelColumnName("药品品种名称")]
        public string DrugVarietyName { get; set; }

        [ExcelColumn(Name = "药物分类")]
        [ExcelColumnName("药物分类")]
        public int? DrugClassification { get; set; }

        [ExcelColumn(Name = "溯源码")]
        [ExcelColumnName("溯源码")]
        public string TracingSourceCode { get; set; }

        [ExcelColumn(Name = "批号")]
        [ExcelColumnName("批号")]
        public string DrugBatchNumber { get; set; }

        [ExcelColumn(Name = "最小单位")]
        [ExcelColumnName("最小单位")]
        public string Minunit { get; set; }

        [ExcelColumn(Name = "生产厂家")]
        [ExcelColumnName("生产厂家")]
        public string ProduceName { get; set; }

        [ExcelColumn(Name = "转换系数")]
        [ExcelColumnName("转换系数")]
        public int? PackageRatio { get; set; }

        [ExcelColumn(Name = "包装单位")]
        [ExcelColumnName("包装单位")]
        public string PackageUnit { get; set; }

        public string HisID { get; set; }

        public decimal Price { get; set; }

        public string RefCode { get; set; }

        public string DefaultLocation { get; set; }

        public string ChangeTime { get; set; }

        public string CreationTime { get; set; }

        public decimal HisPrice { get; set; }

        public string KfEnable { get; set; }

        public string YfEnable { get; set; }

    }
}