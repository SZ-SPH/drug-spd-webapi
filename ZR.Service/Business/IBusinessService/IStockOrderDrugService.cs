using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 备货单药品service接口
    /// </summary>
    public interface IStockOrderDrugService : IBaseService<StockOrderDrug>
    {
        PagedInfo<StockOrderDrugDto> GetList(StockOrderDrugQueryDto parm);

        StockOrderDrug GetInfo(int Id);


        StockOrderDrug AddStockOrderDrug(StockOrderDrug parm);
        int UpdateStockOrderDrug(StockOrderDrug parm);

        bool TruncateStockOrderDrug();

        (string, object, object) ImportStockOrderDrug(List<StockOrderDrug> list);

        PagedInfo<StockOrderDrugDto> ExportList(StockOrderDrugQueryDto parm);
    }
}