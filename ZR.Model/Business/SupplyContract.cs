
namespace ZR.Model.Business
{
    /// <summary>
    /// 合同
    /// </summary>
    [SugarTable("SupplyContract")]
    public class SupplyContract
    {
        /// <summary>
        /// 合同的唯一标识符 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 合同编号 
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 合同名称 
        /// </summary>
        public string ContractName { get; set; }

        /// <summary>
        /// 合同开始日期 
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 合同结束日期 
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 合同类型 
        /// </summary>
        public string ContractType { get; set; }

        /// <summary>
        /// 合同供应商名称 
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 合同状态 
        /// </summary>
        public string States { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 创建人 
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        public DateTime? ModifiedAt { get; set; }

        /// <summary>
        /// 修改人 
        /// </summary>
        public string ModifiedBy { get; set; }

    }
}