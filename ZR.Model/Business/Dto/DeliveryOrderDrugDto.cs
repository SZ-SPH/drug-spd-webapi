
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 送货单药品查询对象
    /// </summary>
    public class DeliveryOrderDrugQueryDto : PagerInfo 
    {
        public int? DeliveryId { get; set; }
        public int? DrugId { get; set; }
        public string DrugName { get; set; }
        public string DrugCode { get; set; }
        public string DrugBatchNo { get; set; }
    }

    /// <summary>
    /// 送货单药品输入输出对象
    /// </summary>
    public class DeliveryOrderDrugDto
    {
        
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "送货单")]
        [ExcelColumnName("送货单")]
        public int? DeliveryId { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public int? DrugId { get; set; }

        [ExcelColumn(Name = "药品名称")]
        [ExcelColumnName("药品名称")]
        public string DrugName { get; set; }

        [ExcelColumn(Name = "药品编号")]
        [ExcelColumnName("药品编号")]
        public string DrugCode { get; set; }

        [ExcelColumn(Name = "药品规格")]
        [ExcelColumnName("药品规格")]
        public string DrugSpecification { get; set; }

        [ExcelColumn(Name = "药品批号")]
        [ExcelColumnName("药品批号")]
        public string DrugBatchNo { get; set; }

        [ExcelColumn(Name = "生产厂家")]
        [ExcelColumnName("生产厂家")]
        public string Manufacturer { get; set; }

        [ExcelColumn(Name = "单价")]
        [ExcelColumnName("单价")]
        public decimal UnitPrice { get; set; }

        [ExcelColumn(Name = "药品数量")]
        [ExcelColumnName("药品数量")]
        public int? DrugQuantity { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remarks { get; set; }

        public string Minunit { get; set; }
        public int? PackageRatio { get; set; }
        public string PackageUnit { get; set; }
        public string Exprie { get; set; }
        public string DateOfManufacture { get; set; }

    }
}