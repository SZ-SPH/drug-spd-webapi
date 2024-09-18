
namespace ZR.Model.Business
{
    /// <summary>
    /// 入库计划
    /// </summary>
    [SugarTable("InventoryPlan")]
    public class InventoryPlan
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 入库单编号 
        /// </summary>
        public string InventoryPlanCode { get; set; }

        /// <summary>
        /// 入库时间 
        /// </summary>
        public string StorageTime { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// 创建人 
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        public string ChangeTime { get; set; }

        /// <summary>
        /// 修改人 
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        public string States { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remarks { get; set; }

    }
}