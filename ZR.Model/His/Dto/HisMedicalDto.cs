namespace ZR.Model.His.Dto
{
    /// <summary>
    /// 药品基础资料管理查询对象
    /// </summary>
    public class HisMedicalQueryDto : PagerInfo
    {

    }

    /// <summary>
    /// 药品基础资料管理输入输出对象
    /// </summary>
    public class HisMedicalDto
    {

        public string PH { get; set; }
        public string BR_ID { get; set; }
        public string BR_HM { get; set; }
        public string DRUG_ID { get; set; }
        public string ORDERED_DEPT_ID { get; set; }
        public string DEPARTMENT_CHINESE_NAME { get; set; }
        public string ORDERED_DOCTOR_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string FYMX_ID { get; set; }
        public string TYPE_CODE { get; set; }

    }
}