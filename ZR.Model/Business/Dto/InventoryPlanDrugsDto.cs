
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 入库计划药品查询对象
    /// </summary>
    public class InventoryPlanDrugsQueryDto : PagerInfo 
    {
        public string PlanId { get; set; }
        public string DrugId { get; set; }
        public string DrugDetails { get; set; }

    }

    /// <summary>
    /// 入库计划药品输入输出对象
    /// </summary>
    public class InventoryPlanDrugsDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "入库计划id")]
        [ExcelColumnName("入库计划id")]
        public string PlanId { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public string DrugId { get; set; }

        [ExcelColumn(Name = "药品信息")]
        [ExcelColumnName("药品信息")]
        public string DrugDetails { get; set; }

        [ExcelColumn(Name = "数量")]
        [ExcelColumnName("数量")]
        public string DrugQuantity { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remarks { get; set; }



    }
}