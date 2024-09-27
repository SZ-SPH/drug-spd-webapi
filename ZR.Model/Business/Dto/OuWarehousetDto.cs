
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



    }
}