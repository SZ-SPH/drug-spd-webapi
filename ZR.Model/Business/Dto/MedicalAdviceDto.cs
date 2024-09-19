namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 医嘱查询对象
    /// </summary>
    public class MedicalAdviceQueryDto : PagerInfo
    {
        public string IpiRegistrationId { get; set; }
        public int? DrugId { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentChineseName { get; set; }
        public string IpiReaistrationNo { get; set; }
        public string AssignDrugSeq { get; set; }
}

/// <summary>
/// 医嘱输入输出对象
/// </summary>
public class MedicalAdviceDto
{
    [Required(ErrorMessage = "id不能为空")]
    [ExcelColumn(Name = "id")]
    [ExcelColumnName("id")]
    public int OrderId { get; set; }

    [ExcelColumn(Name = "病患号")]
    [ExcelColumnName("病患号")]
    public string IpiRegistrationId { get; set; }

    [ExcelColumn(Name = "药品id")]
    [ExcelColumnName("药品id")]
    public int? DrugId { get; set; }

    [ExcelColumn(Name = "药品数量")]
    [ExcelColumnName("药品数量")]
    public int? TotalQty { get; set; }

    [ExcelColumn(Name = "开单医生id")]
    [ExcelColumnName("开单医生id")]
    public string OrderedDoctorId { get; set; }

    [ExcelColumn(Name = "开单医生")]
    [ExcelColumnName("开单医生")]
    public string EmployeeName { get; set; }

    [ExcelColumn(Name = "HIS医嘱号")]
    [ExcelColumnName("HIS医嘱号")]
    public string AssignDrugSeq { get; set; }

    [ExcelColumn(Name = "开单科室id")]
    [ExcelColumnName("开单科室id")]
    public string OrderedDeptId { get; set; }

    [ExcelColumn(Name = "开单科室名称")]
    [ExcelColumnName("开单科室名称")]
    public string DepartmentChineseName { get; set; }

[ExcelColumn(Name = "住院号")]
[ExcelColumnName("住院号")]
public string IpiReaistrationNo { get; set; }



    }
}