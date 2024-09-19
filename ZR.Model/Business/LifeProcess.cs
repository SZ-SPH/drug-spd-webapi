
namespace ZR.Model.Business
{
    /// <summary>
    /// 
    /// </summary>
    [SugarTable("LifeProcess")]
    public class LifeProcess
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// Receiptid 
        /// </summary>
        public string Receiptid { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        public string DRUGId { get; set; }

        /// <summary>
        /// 追溯码id 
        /// </summary>
        public string CodeId { get; set; }

        /// <summary>
        /// 操作人 
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// 时间 
        /// </summary>
        public string Times { get; set; }

        /// <summary>
        /// 详情 
        /// </summary>
        public string Details { get; set; }
        public int? MedicalAdviceId { get; set; }

    }
}