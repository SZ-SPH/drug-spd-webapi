namespace ZR.Model.Business
{
    /// <summary>
    /// 医嘱
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
        [SugarColumn(ColumnName = "ipi_registration_id")]
        public string IpiRegistrationId { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_ID")]
        public int? DrugId { get; set; }

        /// <summary>
        /// 药品数量 
        /// </summary>
        [SugarColumn(ColumnName = "total_qty")]
        public int? TotalQty { get; set; }

        /// <summary>
        /// 开单医生id 
        /// </summary>
        [SugarColumn(ColumnName = "ordered_doctor_id")]
        public string OrderedDoctorId { get; set; }

        /// <summary>
        /// 开单医生 
        /// </summary>
        [SugarColumn(ColumnName = "employee_name")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// HIS医嘱号 
        /// </summary>
        [SugarColumn(ColumnName = "aSSIGN_DRUG_SEQ")]
        public string AssignDrugSeq { get; set; }

        /// <summary>
        /// 开单科室id 
        /// </summary>
        [SugarColumn(ColumnName = "ordered_dept_id")]
        public string OrderedDeptId { get; set; }

        /// <summary>
        /// 开单科室名称 
        /// </summary>
        [SugarColumn(ColumnName = "department_chinese_name")]
        public string DepartmentChineseName { get; set; }

    /// <summary>
    /// 住院号 
    /// </summary>
    [SugarColumn(ColumnName = "ipi_reaistration_no")]
    public string IpiReaistrationNo { get; set; }

}
}