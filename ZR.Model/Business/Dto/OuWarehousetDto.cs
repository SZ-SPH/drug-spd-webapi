namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 出库查询对象
    /// </summary>
    public class OuWarehousetQueryDto : PagerInfo
    {
        public int? DrugId { get; set; }
        public int? OutWarehouseID { get; set; }
        public int? InpharmacyId { get; set; }
        public decimal? Qty { get; set; }
        public int? PharmacyId { get; set; }
        public int? OutorderID { get; set; }

        public DateTime? BeginTimes { get; set; }
        public DateTime? EndTimes { get; set; }
    }

    /// <summary>
    /// 出库输入输出对象
    /// </summary>
    public class OuWarehousetDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "药品")]
        [ExcelColumnName("药品")]
        public int? DrugId { get; set; }
        public string? DrugName { get; set; }

        [ExcelColumn(Name = "出库房")]
        [ExcelColumnName("出库房")]
        public int? OutWarehouseID { get; set; }

        public string? OutWarehouseName { get; set; }

        [ExcelColumn(Name = "入药房")]
        [ExcelColumnName("入药房")]
        public int? InpharmacyId { get; set; }
        public string? InpharmacyName { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Qty { get; set; }

        [ExcelColumn(Name = "申请计划")]
        [ExcelColumnName("申请计划")]
        public int? PharmacyId { get; set; }

        [ExcelColumn(Name = "时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("时间")]
        public DateTime? Times { get; set; }

        [ExcelColumn(Name = "药品名称")]
        [ExcelColumnName("药品名称")]
        public string Drugname { get; set; }

        [ExcelColumn(Name = "规格")]
        [ExcelColumnName("规格")]
        public string DrugSpecifications { get; set; }

        [ExcelColumn(Name = "最小单位")]
        [ExcelColumnName("最小单位")]
        public string Minunit { get; set; }

        [ExcelColumn(Name = "购入价")]
        [ExcelColumnName("购入价")]
        public decimal Buyprice { get; set; }

        [ExcelColumn(Name = "购入金额")]
        [ExcelColumnName("购入金额")]
        public decimal Allbuyprice { get; set; }

        [ExcelColumn(Name = "零售价")]
        [ExcelColumnName("零售价")]
        public decimal RetailPrice { get; set; }

        [ExcelColumn(Name = "售价金额")]
        [ExcelColumnName("售价金额")]
        public decimal AllRetailPrice { get; set; }

        [ExcelColumn(Name = "出库单")]
        [ExcelColumnName("出库单")]
        public int? OutorderID { get; set; }
        [ExcelColumn(Name = "生产厂家")]
        [ExcelColumnName("生产厂家")]
        public string ManufacturerName { get; set; }

        [ExcelColumn(Name = "批号")]
        [ExcelColumnName("批号")]
        public string BatchNumber { get; set; }

        [ExcelColumn(Name = "有效期")]
        [ExcelColumnName("有效期")]
        public string Exprie { get; set; }

        [ExcelColumn(Name = "货位号")]
        [ExcelColumnName("货位号")]
        public string LocationNumber { get; set; }



    }
}