
namespace ZR.Model.Business
{
    /// <summary>
    /// 医嘱药品
    /// </summary>
    [SugarTable("MADrug")]
    public class MADrug
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 医嘱id 
        /// </summary>
        public string MedicalAdviceId { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        public string DrugId { get; set; }

        /// <summary>
        /// 药品信息 
        /// </summary>
        public string DrugDetails { get; set; }

        /// <summary>
        /// 药品数量 
        /// </summary>
        public string DrugQuantity { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 药品码 
        /// </summary>
        public string CodeId { get; set; }

        /// <summary>
        /// 药品码详情 
        /// </summary>
        public string CodeDetails { get; set; }

    }
}