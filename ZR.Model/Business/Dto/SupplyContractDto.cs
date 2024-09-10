
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 合同管理查询对象
    /// </summary>
    public class SupplyContractQueryDto : PagerInfo 
    {
        public string ContractCode { get; set; }
        public string ContractDate { get; set; }
        public string DrugId { get; set; }
        public string SupplierId { get; set; }
        public string States { get; set; }
    }

    /// <summary>
    /// 合同管理输入输出对象
    /// </summary>
    public class SupplyContractDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "合同编号")]
        [ExcelColumnName("合同编号")]
        public string ContractCode { get; set; }

        [ExcelColumn(Name = "合同内容")]
        [ExcelColumnName("合同内容")]
        public string ContractContent { get; set; }

        [ExcelColumn(Name = "合同日期")]
        [ExcelColumnName("合同日期")]
        public string ContractDate { get; set; }

        [ExcelColumn(Name = "合同药品")]
        [ExcelColumnName("合同药品")]
        public string DrugId { get; set; }

        [ExcelColumn(Name = "合同医院")]
        [ExcelColumnName("合同医院")]
        public string HospitalId { get; set; }

        [ExcelColumn(Name = "合同供应商")]
        [ExcelColumnName("合同供应商")]
        public string SupplierId { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string States { get; set; }



    }
}