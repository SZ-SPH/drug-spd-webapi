
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 药房查询对象
    /// </summary>
    public class PharmacyQueryDto : PagerInfo 
    {
        public string PharmacyName { get; set; }
        public string State { get; set; }
    }

    /// <summary>
    /// 药房输入输出对象
    /// </summary>
    public class PharmacyDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "药房名称")]
        [ExcelColumnName("药房名称")]
        public string PharmacyName { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string State { get; set; }



        [ExcelColumn(Name = "状态")]
        public string StateLabel { get; set; }
    }
}