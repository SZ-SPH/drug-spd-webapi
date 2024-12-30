
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 合同查询对象
    /// </summary>
    public class SupplyContractQueryDto : PagerInfo 
    {
        public string ContractCode { get; set; }
        public string ContractName { get; set; }
        public string SupplierName { get; set; }
    }

    /// <summary>
    /// 合同输入输出对象
    /// </summary>
    public class SupplyContractDto
    {
        //[Required(ErrorMessage = "合同的唯一标识符不能为空")]
        [ExcelColumn(Name = "合同的唯一标识符")]
        [ExcelColumnName("合同的唯一标识符")]
        public int Id { get; set; }

        [Required(ErrorMessage = "合同编号不能为空")]
        [ExcelColumn(Name = "合同编号")]
        [ExcelColumnName("合同编号")]
        public string ContractCode { get; set; }

        [ExcelColumn(Name = "合同名称")]
        [ExcelColumnName("合同名称")]
        public string ContractName { get; set; }

        [ExcelColumn(Name = "合同开始日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同开始日期")]
        public DateTime? StartDate { get; set; }

        [ExcelColumn(Name = "合同结束日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("合同结束日期")]
        public DateTime? EndDate { get; set; }

        [ExcelColumn(Name = "合同类型")]
        [ExcelColumnName("合同类型")]
        public string ContractType { get; set; }

        [ExcelColumn(Name = "合同供应商名称")]
        [ExcelColumnName("合同供应商名称")]
        public string SupplierName { get; set; }

        [ExcelColumn(Name = "合同状态")]
        [ExcelColumnName("合同状态")]
        public string States { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreatedAt { get; set; }

        [ExcelColumn(Name = "创建人")]
        [ExcelColumnName("创建人")]
        public string CreatedBy { get; set; }

        [ExcelColumn(Name = "修改时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("修改时间")]
        public DateTime? ModifiedAt { get; set; }

        [ExcelColumn(Name = "修改人")]
        [ExcelColumnName("修改人")]
        public string ModifiedBy { get; set; }



        [ExcelColumn(Name = "合同类型")]
        public string ContractTypeLabel { get; set; }
    }

    public class SupladdDto
    {
        [ExcelColumn(Name = "供应商名称")]
        [ExcelColumnName("供应商名称")]
        public string SupplierName { get; set; }
        [ExcelColumn(Name = "药品编码")]
        [ExcelColumnName("药品编码")]
        public string DrugCode { get; set; }

    }
}