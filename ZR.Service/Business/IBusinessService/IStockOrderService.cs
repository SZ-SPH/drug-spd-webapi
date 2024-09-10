using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 备货单service接口
    /// </summary>
    public interface IStockOrderService : IBaseService<StockOrder>
    {
        PagedInfo<StockOrderDto> GetList(StockOrderQueryDto parm);

        StockOrder GetInfo(int Id);


        StockOrder AddStockOrder(StockOrder parm);
        int UpdateStockOrder(StockOrder parm);

        bool TruncateStockOrder();

        (string, object, object) ImportStockOrder(List<StockOrder> list);

        PagedInfo<StockOrderDto> ExportList(StockOrderQueryDto parm);
    }
}