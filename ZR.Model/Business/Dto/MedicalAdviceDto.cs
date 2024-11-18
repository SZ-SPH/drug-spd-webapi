namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 医嘱查询对象
    /// </summary>
    public class MedicalAdviceQueryDto : PagerInfo
    {
        public string IpiRegistrationId { get; set; }
        public string DrugId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentChineseName { get; set; }
        public string IpiReaistrationNo { get; set; }
        public string AssignDrugSeq { get; set; }
        public string OrderedDoctorId { get; set; }
        public string OrderedDeptId { get; set; }
        public string PatientNumber { get; set; }
        public string FymxId { get; set; }
        public string TypeCode { get; set; }
        public string BillNum { get; set; }
    }

    /// <summary>
    /// 输入输出对象
    /// </summary>
    public class MedicalAdviceDto
    {
        [Required(ErrorMessage = "id不能为空")]
        public int OrderId { get; set; }

        public string IpiRegistrationId { get; set; }

        public string DrugId { get; set; }

        public int? TotalQty { get; set; }

        public string OrderedDoctorId { get; set; }

        public string EmployeeName { get; set; }

        public string AssignDrugSeq { get; set; }

        public string OrderedDeptId { get; set; }

        public string DepartmentChineseName { get; set; }

        public string IpiReaistrationNo { get; set; }

        public string PatientNumber { get; set; }

        public string FymxId { get; set; }

        public string TypeCode { get; set; }

        public string BillNum { get; set; }



    }
}