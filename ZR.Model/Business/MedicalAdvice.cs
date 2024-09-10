
namespace ZR.Model.Business
{
    /// <summary>
    /// 医嘱基础信息
    /// </summary>
    [SugarTable("MEDICAL_ADVICE")]
    public class MedicalAdvice
    {
        /// <summary>
        /// id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "oRDER_ID")]
        public int OrderId { get; set; }

        /// <summary>
        /// 病患号 
        /// </summary>
        [SugarColumn(ColumnName = "pATIENT_NUMBER")]
        public string PatientNumber { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_ID")]
        public string DrugId { get; set; }

        /// <summary>
        /// 药品数量 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_NUMBER")]
        public string DrugNumber { get; set; }

        /// <summary>
        /// 开单科室 
        /// </summary>
        [SugarColumn(ColumnName = "bILLING_DEPARTMENT")]
        public string BillingDepartment { get; set; }

        /// <summary>
        /// 开单医生 
        /// </summary>
        [SugarColumn(ColumnName = "bILLING_DOCTOR")]
        public string BillingDoctor { get; set; }

    }
}