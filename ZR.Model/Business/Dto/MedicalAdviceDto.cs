
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 医嘱基础信息查询对象
    /// </summary>
    public class MedicalAdviceQueryDto : PagerInfo 
    {
        //病患号 科室 医生     
        public string PatientNumber { get; set; }
        public string BillingDepartment { get; set; }
        public string BillingDoctor { get; set; }
    }

    /// <summary>
    /// 医嘱基础信息输入输出对象
    /// </summary>
    public class MedicalAdviceDto
    {
        [Required(ErrorMessage = "id不能为空")]
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        public int OrderId { get; set; }

        [ExcelColumn(Name = "病患号")]
        [ExcelColumnName("病患号")]
        public string PatientNumber { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public string DrugId { get; set; }

        [ExcelColumn(Name = "药品数量")]
        [ExcelColumnName("药品数量")]
        public string DrugNumber { get; set; }

        [ExcelColumn(Name = "开单科室")]
        [ExcelColumnName("开单科室")]
        public string BillingDepartment { get; set; }

        [ExcelColumn(Name = "开单医生")]
        [ExcelColumnName("开单医生")]
        public string BillingDoctor { get; set; }



    }
}