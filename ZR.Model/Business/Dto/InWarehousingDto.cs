
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
        public string InventoryQuantity { get; set; }

        [ExcelColumn(Name = "药品规格")]
        [ExcelColumnName("药品规格")]
        public string DrugSpecifications { get; set; }
        [ExcelColumn(Name = "入库单据id")]
        [ExcelColumnName("入库单据id")]
        public int? ReceiptId { get; set; }



    }
}