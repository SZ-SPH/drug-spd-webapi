namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 仓库查询对象
    /// </summary>
    public class WarehouseQueryDto : PagerInfo
    {
        public string Name { get; set; }
        public string State { get; set; }
        public string Code { get; set; }
    }

    /// <summary>
    /// 仓库输入输出对象
    /// </summary>
    public class WarehouseDto
    {
        [Required(ErrorMessage = "id不能为空")]
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "名称")]
        [ExcelColumnName("名称")]
        public string Name { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string State { get; set; }

        [ExcelColumn(Name = "编码")]
        [ExcelColumnName("编码")]
        public string Code { get; set; }



    }
}