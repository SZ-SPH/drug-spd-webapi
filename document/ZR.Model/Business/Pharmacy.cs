
namespace ZR.Model.Business
{
    /// <summary>
    /// 药房
    /// </summary>
    [SugarTable("pharmacy")]
    public class Pharmacy
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 药房名称 
        /// </summary>
        public string PharmacyName { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        public string State { get; set; }

    }
}