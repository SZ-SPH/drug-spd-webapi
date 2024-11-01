
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

    public class PdaStockVo
    {
        //ID
        public int Id { get; set; }
        //药品ID
        public int? DrugId { get; set; }
        //库存数量
        public decimal InventoryQuantity { get; set; }
        //药品名称
        public string DrugName { get; set; }
        //药品编码
        public string DrugCode { get; set; }
        //药品助记码
        public string DrugMnemonicCode { get; set; }
        //药品规格
        public string DrugSpecifications { get; set; }

    }

    //库存对象
    public class StockVo
    {
        public int Id { get; set; }
        public int? DrugId { get; set; }
        public string DrugName { get; set; }
        public int? Drugqty { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal InventoryQuantity { get; set; }
        public decimal DeQuantity { get; set; }
        public decimal ActualStock { get; set; }
        public string SUnit { get; set; }
        public int? Packqty { get; set; }
        public string PackUnit { get; set; }
        public string BatchON { get; set; }
        public int? BatchNum { get; set; }
        public int? WarehouseID { get; set; }
        //药品通用名称
        public string DrugMnemonicCode { get; set; }
        //药品规格
        public string DrugSpecifications { get; set; }
        //药品类别
        public string DrugCategory { get; set; }
        //药品追溯前八位识别码
        public string RefCode { get; set; }

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
        public decimal InventoryQuantity { get; set; }

        [ExcelColumn(Name = "预扣数量")]
        [ExcelColumnName("预扣数量")]
        public decimal DeQuantity { get; set; }

        [ExcelColumn(Name = "库存（库存量-预扣）")]
        [ExcelColumnName("库存（库存量-预扣）")]
        public decimal ActualStock { get; set; }

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