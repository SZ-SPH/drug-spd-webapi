
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 出库单查询对象
    /// </summary>
    public class OutOrderQueryDto : PagerInfo 
    {
        public string OutOrderCode { get; set; }
        public int? InpharmacyId { get; set; }
        public string UseReceive { get; set; }
        public int? OutWarehouseID { get; set; }
        public DateTime? BeginTimes { get; set; }
        public DateTime? EndTimes { get; set; }
        public string Remarks { get; set; }
    }

    /// <summary>
    /// 出库单输入输出对象
    /// </summary>
    public class OutOrderDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "出库单据")]
        [ExcelColumnName("出库单据")]
        public string OutOrderCode { get; set; }

        [ExcelColumn(Name = "领取部门")]
        [ExcelColumnName("领取部门")]
        public int? InpharmacyId { get; set; }

        [ExcelColumn(Name = "领取人")]
        [ExcelColumnName("领取人")]
        public string UseReceive { get; set; }

        [ExcelColumn(Name = "发出出库")]
        [ExcelColumnName("发出出库")]
        public int? OutWarehouseID { get; set; }

        [ExcelColumn(Name = "时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("时间")]
        public DateTime? Times { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remarks { get; set; }



    }
}