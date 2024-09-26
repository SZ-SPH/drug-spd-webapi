
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 申请计划查询对象
    /// </summary>
    public class ApplicationPlanQueryDto : PagerInfo 
    {
        public int? DrugId { get; set; }
        public int? PharmacyId { get; set; }
        public string State { get; set; }
        public DateTime? BeginTimes { get; set; }
        public DateTime? EndTimes { get; set; }
        public string Users { get; set; }
    }

    /// <summary>
    /// 申请计划输入输出对象
    /// </summary>
    public class ApplicationPlanDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "药品")]
        [ExcelColumnName("药品")]
        public int? DrugId { get; set; }

        [ExcelColumn(Name = "药房")]
        [ExcelColumnName("药房")]
        public int? PharmacyId { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public decimal Qty { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string State { get; set; }

        [ExcelColumn(Name = "时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("时间")]
        public DateTime? Times { get; set; }

        [ExcelColumn(Name = "操作人")]
        [ExcelColumnName("操作人")]
        public string Users { get; set; }



        [ExcelColumn(Name = "状态")]
        public string StateLabel { get; set; }
    }
}