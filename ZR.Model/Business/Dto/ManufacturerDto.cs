
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 生产厂家查询对象
    /// </summary>
    public class ManufacturerQueryDto : PagerInfo 
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    /// <summary>
    /// 生产厂家输入输出对象
    /// </summary>
    public class ManufacturerDto
    {
        [Required(ErrorMessage = "id不能为空")]
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Name { get; set; }

        [ExcelColumn(Name = "编号")]
        [ExcelColumnName("编号")]
        public string Code { get; set; }


        public string HisId { get; set; }
    }
}