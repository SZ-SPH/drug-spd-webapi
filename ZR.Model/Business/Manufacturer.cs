
namespace ZR.Model.Business
{
    /// <summary>
    /// 生产厂家
    /// </summary>
    [SugarTable("Manufacturer")]
    public class Manufacturer
    {
        /// <summary>
        /// id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 名称 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编号 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// HIS ID 
        /// </summary>
        public string HisId { get; set; }
    }
}