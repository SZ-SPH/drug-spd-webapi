using ZR.Model.Business;

namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 盘点单查询对象
    /// </summary>
    public class StocktakingQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 盘点单输入输出对象
    /// </summary>
    public class StocktakingDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        public int Id { get; set; }

        [ExcelColumn(Name = "盘点单号")]
        [ExcelColumnName("盘点单号")]
        public string StokingNo { get; set; }

        [ExcelColumn(Name = "生成时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("生成时间")]
        public DateTime? GenerateTime { get; set; }

        [ExcelColumn(Name = "生成人")]
        [ExcelColumnName("生成人")]
        public string GenerateMan { get; set; }

        [ExcelColumn(Name = "状态 暂未启用留空")]
        [ExcelColumnName("状态 暂未启用留空")]
        public string State { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelColumn(Name = "修改时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("修改时间")]
        public DateTime? UpdateTime { get; set; }

        [ExcelColumn(Name = "库存数量")]
        [ExcelColumnName("库存数量")]
        public string DrugQty { get; set; }

        [ExcelColumn(Name = "盘点数量")]
        [ExcelColumnName("盘点数量")]
        public string StockTakingQty { get; set; }

        [ExcelIgnore]
        public List<StocktakingItemDto> StocktakingItemNav { get; set; }
        [ExcelColumn(Name = "状态 暂未启用留空")]
        public string StateLabel { get; set; }
    }
}