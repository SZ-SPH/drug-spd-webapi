using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 库存service接口
    /// </summary>
    public interface IStockService : IBaseService<Stock>
    {
        PagedInfo<StockVo> GetList(StockQueryDto parm);
        List<PdaStockVo> GetPdaList(StockQueryDto parm);
       List<Stock> AllGetInfo(List<int> parm);  
        Stock GetInfo(int Id);
        Stock SGetList(int Id);

        Stock InGetInfo(int Id,string batchON);

        Stock AddStock(Stock parm);

        Task<Stock> AddStockAsync(Stock parm);
        int UpdateStock(Stock parm);
        
        bool TruncateStock();

        (string, object, object) ImportStock(List<Stock> list);

        PagedInfo<StockDto> ExportList(StockQueryDto parm);
    }
}
