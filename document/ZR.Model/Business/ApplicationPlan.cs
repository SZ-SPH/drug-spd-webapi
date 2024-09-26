
namespace ZR.Model.Business
{
    /// <summary>
    /// 申请计划
    /// </summary>
    [SugarTable("applicationPlan")]
    public class ApplicationPlan
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 药品 
        /// </summary>
        public int? DrugId { get; set; }

        /// <summary>
        /// 药房 
        /// </summary>
        public int? PharmacyId { get; set; }

        /// <summary>
        /// 数量 
        /// </summary>
        public decimal Qty { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 时间 
        /// </summary>
        public DateTime? Times { get; set; }

        /// <summary>
        /// 操作人 
        /// </summary>
        public string Users { get; set; }

    }
}