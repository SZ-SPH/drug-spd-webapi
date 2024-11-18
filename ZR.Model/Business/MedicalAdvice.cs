namespace ZR.Model.Business
{

    [SugarTable("MEDICALADVICE")]
    public class MedicalAdvice
    {
        /// <summary>
        /// id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "oRDER_ID")]
        public int OrderId { get; set; }

        /// <summary>
        /// 病患号 
        /// </summary>
        [SugarColumn(ColumnName = "ipi_registration_id")]
        public string IpiRegistrationId { get; set; }

        /// <summary>
        /// 药品id(Hisid) 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_ID")]
        public string DrugId { get; set; }

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

        /// <summary>
        /// 病患号码 
        /// </summary>
        [SugarColumn(ColumnName = "patient_Number")]
        public string PatientNumber { get; set; }

        /// <summary>
        /// 发药明细ID 
        /// </summary>
        [SugarColumn(ColumnName = "fymx_id")]
        public string FymxId { get; set; }

        /// <summary>
        /// 类别 1门诊 2住院 
        /// </summary>
        [SugarColumn(ColumnName = "type_code")]
        public string TypeCode { get; set; }

        /// <summary>
        /// 票号 
        /// </summary>
        public string BillNum { get; set; }

    }

    public class MedicalAdviceBind
    {
        public int OrderId { get; set; }
        public string IpiRegistrationId { get; set; }
        public string DrugId { get; set; }
        public int? TotalQty { get; set; }
        public int? TrueQty { get; set; }
        public string OrderedDoctorId { get; set; }
        public string EmployeeName { get; set; }
        public string AssignDrugSeq { get; set; }
        public string OrderedDeptId { get; set; }
        public string DepartmentChineseName { get; set; }
        public string IpiReaistrationNo { get; set; }
        public string DrugName { get; set; }
        public string DrugCode { get; set; }
        public string DrugCategory { get; set; }
        public string DrugMnemonicCode { get; set; }
    }

}