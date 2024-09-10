namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 供应商基础功能查询对象
    /// </summary>
    public class SupplierQueryDto : PagerInfo
    {
        public int? Id { get; set; }
        public string SupplierName { get; set; }
        public string SocialCreditCode { get; set; }
        public string EnterpriseAddress { get; set; }
        public string EnterprisePhone { get; set; }
    }

    /// <summary>
    /// 供应商基础功能输入输出对象
    /// </summary>
    public class SupplierDto
    {
        [Required(ErrorMessage = "id不能为空")]
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string SupplierName { get; set; }

        [ExcelColumn(Name = "社会信用代码")]
        [ExcelColumnName("社会信用代码")]
        public string SocialCreditCode { get; set; }

        [ExcelColumn(Name = "企业地址")]
        [ExcelColumnName("企业地址")]
        public string EnterpriseAddress { get; set; }

        [ExcelColumn(Name = "企业电话")]
        [ExcelColumnName("企业电话")]
        public string EnterprisePhone { get; set; }



    }
}
