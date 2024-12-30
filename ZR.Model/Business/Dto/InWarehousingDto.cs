
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 入库信息查询对象
    /// </summary>
    public class InWarehousingQueryDto : PagerInfo 
    {
        public int? DrugId { get; set; }
        public string DrugCode { get; set; }
        public string TracingSourceCode { get; set; }
        public string BatchNumber { get; set; }
        public int? ReceiptId { get; set; }
    }

    /// <summary>
    /// 入库信息输入输出对象
    /// </summary>
    public class InWarehousingDto
    {
        [Required(ErrorMessage = "id不能为空")]
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public int? DrugId { get; set; }

        [ExcelColumn(Name = "药品编码")]
        [ExcelColumnName("药品编码")]
        public string DrugCode { get; set; }

        [ExcelColumn(Name = "药品溯源码")]
        [ExcelColumnName("药品溯源码")]
        public string TracingSourceCode { get; set; }

        [ExcelColumn(Name = "药品批号")]
        [ExcelColumnName("药品批号")]
        public string BatchNumber { get; set; }

        [ExcelColumn(Name = "药品入库数量")]
        [ExcelColumnName("药品入库数量")]
        public decimal InventoryQuantity { get; set; }

        [ExcelColumn(Name = "药品规格")]
        [ExcelColumnName("药品规格")]
        public string DrugSpecifications { get; set; }
        [ExcelColumn(Name = "入库单据id")]
        [ExcelColumnName("入库单据id")]
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

        public int? PackageRatio { get; set; }


        public string PackageUnit { get; set; }

    }

    public class InWarehousingPdaDto
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public string DrugCode { get; set; }
        public string DrugMnemonicCode { get; set; }
        public string DrugSpecifications { get; set; }
        public string DrugCategory { get; set; }
        public string DrugVarietyName { get; set; }
        public string DrugClassification { get; set; }
        public string TracingSourceCode { get; set; }
        public string DrugBatchNumber { get; set; }
        public string Minunit { get; set; }
        public string ProduceName { get; set; }
        public string ProduceId { get; set; }
        public string PackageRatio { get; set; }
        public string PackageUnit { get; set; }
        public string ReceiptId { get; set; }
        public string ExpireDate { get; set; }
        public string Expire { get; set; }
        public string ApprovalLicenceNo { get; set; }
        public string PkgSpecCrit { get; set; }
        public string PkgAmount { get; set; }
        public string PrepnSpec { get; set; }
        public string PrepnTypeDesc { get; set; }
        public string ProduceDateStr { get; set; }
    }
}