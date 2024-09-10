
namespace ZR.Model.Business
{
    /// <summary>
    /// 合同管理
    /// </summary>
    [SugarTable("SupplyContract")]
    public class SupplyContract
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 合同编号 
        /// </summary>
        public string ContractCode { get; set; }

        /// <summary>
        /// 合同内容 
        /// </summary>
        public string ContractContent { get; set; }

        /// <summary>
        /// 合同日期 
        /// </summary>
        public string ContractDate { get; set; }

        /// <summary>
        /// 合同药品 
        /// </summary>
        public string DrugId { get; set; }

        /// <summary>
        /// 合同医院 
        /// </summary>
        public string HospitalId { get; set; }

        /// <summary>
        /// 合同供应商 
        /// </summary>
        public string SupplierId { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        public string States { get; set; }

    }
}