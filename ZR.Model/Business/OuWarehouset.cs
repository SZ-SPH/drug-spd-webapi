
namespace ZR.Model.Business
{
    /// <summary>
    /// 出库
    /// </summary>
    [SugarTable("OuWarehouset")]
    public class OuWarehouset
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 药品 
        /// </summary>
        public int? DrugId { get; set; }

        /// <summary>
        /// 出库房 
        /// </summary>
        public int? OutWarehouseID { get; set; }

        /// <summary>
        /// 入药房 
        /// </summary>
        public int? InpharmacyId { get; set; }

        /// <summary>
        /// 数量 
        /// </summary>
        public decimal Qty { get; set; }

        /// <summary>
        /// 申请计划 
        /// </summary>
        public int? PharmacyId { get; set; }

        /// <summary>
        /// 时间 
        /// </summary>
        public DateTime? Times { get; set; }

    }
}