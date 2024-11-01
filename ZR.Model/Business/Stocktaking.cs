using ZR.Model.Business;

namespace ZR.Model.Business
{
    /// <summary>
    /// 盘点单
    /// </summary>
    [SugarTable("T_STOCKTAKING")]
    public class Stocktaking
    {
        /// <summary>
        /// ID 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 盘点单号 
        /// </summary>
        [SugarColumn(ColumnName = "sTOKING_NO")]
        public string StokingNo { get; set; }

        /// <summary>
        /// 生成时间 
        /// </summary>
        [SugarColumn(ColumnName = "gENERATE_TIME")]
        public DateTime? GenerateTime { get; set; }

        /// <summary>
        /// 生成人 
        /// </summary>
        [SugarColumn(ColumnName = "gENERATE_MAN")]
        public string GenerateMan { get; set; }

        /// <summary>
        /// 状态 暂未启用留空 
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "cREATE_TIME")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        [SugarColumn(ColumnName = "uPDATE_TIME")]
        public DateTime? UpdateTime { get; set; }

        [Navigate(NavigateType.OneToMany, nameof(StocktakingItem.StockMainId), nameof(Id))] //自定义关系映射
        public List<StocktakingItem> StocktakingItemNav { get; set; }
    }
}