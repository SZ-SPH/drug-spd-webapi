
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 医嘱药品查询对象
    /// </summary>
    public class MADrugQueryDto : PagerInfo 
    {
        public string MedicalAdviceId { get; set; }
        public string DrugId { get; set; }
        public string DrugDetails { get; set; }
        public string CodeId { get; set; }
        public string CodeDetails { get; set; }
    }

    /// <summary>
    /// 医嘱药品输入输出对象
    /// </summary>
    public class MADrugDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "医嘱id")]
        [ExcelColumnName("医嘱id")]
        public string MedicalAdviceId { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public string DrugId { get; set; }

        [ExcelColumn(Name = "药品信息")]
        [ExcelColumnName("药品信息")]
        public string DrugDetails { get; set; }

        [ExcelColumn(Name = "药品数量")]
        [ExcelColumnName("药品数量")]
        public string DrugQuantity { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remarks { get; set; }

        [ExcelColumn(Name = "药品码")]
        [ExcelColumnName("药品码")]
        public string CodeId { get; set; }

        [ExcelColumn(Name = "药品码详情")]
        [ExcelColumnName("药品码详情")]
        public string CodeDetails { get; set; }



    }
}