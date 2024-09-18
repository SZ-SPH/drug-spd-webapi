
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 入库计划查询对象
    /// </summary>
    public class InventoryPlanQueryDto : PagerInfo 
    {
        public string InventoryPlanCode { get; set; }
        public string StorageTime { get; set; }
        public string CreationTime { get; set; }
        public string Creator { get; set; }
        public string ChangeTime { get; set; }
        public string ModifiedBy { get; set; }
        public string States { get; set; }
    }

    /// <summary>
    /// 入库计划输入输出对象
    /// </summary>
    public class InventoryPlanDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "备货单编号")]
        [ExcelColumnName("备货单编号")]
        public string InventoryPlanCode { get; set; }

        [ExcelColumn(Name = "备货时间")]
        [ExcelColumnName("备货时间")]
        public string StorageTime { get; set; }

        [ExcelColumn(Name = "创建时间")]
        [ExcelColumnName("创建时间")]
        public string CreationTime { get; set; }

        [ExcelColumn(Name = "创建人")]
        [ExcelColumnName("创建人")]
        public string Creator { get; set; }

        [ExcelColumn(Name = "修改时间")]
        [ExcelColumnName("修改时间")]
        public string ChangeTime { get; set; }

        [ExcelColumn(Name = "修改人")]
        [ExcelColumnName("修改人")]
        public string ModifiedBy { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string States { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remarks { get; set; }



    }
}