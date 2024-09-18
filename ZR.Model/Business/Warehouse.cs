namespace ZR.Model.Business
{
    /// <summary>
    /// 仓库
    /// </summary>
    [SugarTable("Warehouse")]
    public class Warehouse
    {
        /// <summary>
        /// id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 名称 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 状态 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 编码 
        /// </summary>
        public string Code { get; set; }

    }
}