
namespace ZR.Model.Business
{
    /// <summary>
    /// 入库计划药品
    /// </summary>
    [SugarTable("InventoryPlanDrugs")]
    public class InventoryPlanDrugs
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 入库计划id 
        /// </summary>
        public string PlanId { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        public string DrugId { get; set; }

        /// <summary>
        /// 药品信息 
        /// </summary>
        public string DrugDetails { get; set; }

        /// <summary>
        /// 数量 
        /// </summary>
        public string DrugQuantity { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remarks { get; set; }

    }
}