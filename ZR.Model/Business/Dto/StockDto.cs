
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 库存查询对象
    /// </summary>
    public class StockQueryDto : PagerInfo 
    {
        public int? DrugId { get; set; }
        public string BatchON { get; set; }
        public int? BatchNum { get; set; }
        public int? WarehouseID { get; set; }
    }

    /// <summary>
    /// 库存输入输出对象
    /// </summary>
    public class StockDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "药品")]
        [ExcelColumnName("药品")]
        public int? DrugId { get; set; }

        [ExcelColumn(Name = "药品数量")]
        [ExcelColumnName("药品数量")]
        public int? Drugqty { get; set; }

        [ExcelColumn(Name = "购入价")]
        [ExcelColumnName("购入价")]
        public decimal PurchasePrice { get; set; }

        [ExcelColumn(Name = "零售价")]
        [ExcelColumnName("零售价")]
        public decimal RetailPrice { get; set; }

        [ExcelColumn(Name = "库存量")]
        [ExcelColumnName("库存量")]
        public string InventoryQuantity { get; set; }

        [ExcelColumn(Name = "预扣数量")]
        [ExcelColumnName("预扣数量")]
        public string DeQuantity { get; set; }

        [ExcelColumn(Name = "库存（库存量-预扣）")]
        [ExcelColumnName("库存（库存量-预扣）")]
        public string ActualStock { get; set; }

        [ExcelColumn(Name = "最小单位")]
        [ExcelColumnName("最小单位")]
        public string SUnit { get; set; }

        [ExcelColumn(Name = "包装数量")]
        [ExcelColumnName("包装数量")]
        public int? Packqty { get; set; }

        [ExcelColumn(Name = "包装单位")]
        [ExcelColumnName("包装单位")]
        public string PackUnit { get; set; }

        [ExcelColumn(Name = "批号")]
        [ExcelColumnName("批号")]
        public string BatchON { get; set; }

        [ExcelColumn(Name = "批次号")]
        [ExcelColumnName("批次号")]
        public int? BatchNum { get; set; }

        [ExcelColumn(Name = "库房")]
        [ExcelColumnName("库房")]
        public int? WarehouseID { get; set; }



    }
}