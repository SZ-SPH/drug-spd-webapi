
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 盘点明细查询对象
    /// </summary>
    public class StocktakingItemQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 盘点明细输入输出对象
    /// </summary>
    public class StocktakingItemDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        public int Id { get; set; }
        public string TracingCodePrefix { get; set; }
        public string TracingCode { get; set; }
        /// <summary>
        /// 创建时间 
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 盘点单号主表ID 
        /// </summary>
        public int? StockMainId { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string DrugName { get; set; }
        public string DrugQty { get; set; }
        public string StocktakingQty { get; set; }
        public string DrugSpec { get; set; }
        public string DrugCategory { get; set; }
        public string DrugMnemonicCode { get; set; }
        public string BatchNo { get; set; }
        public string BatchNum { get; set; }
    }
}