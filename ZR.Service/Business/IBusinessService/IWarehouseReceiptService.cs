using ZR.Model.Business.Dto;
using ZR.Model.Business;
namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 入库单service接口
    /// </summary>
    public interface IWarehouseReceiptService : IBaseService<WarehouseReceipt>
    {

        bool AddReceiptdrug(string proc, List<SugarParameter> sugars);
        PagedInfo<WarehouseReceiptDto> GetList(WarehouseReceiptQueryDto parm);

        WarehouseReceipt GetInfo(int ReceiptId);


        WarehouseReceipt AddWarehouseReceipt(WarehouseReceipt parm);
        int UpdateWarehouseReceipt(WarehouseReceipt parm);

        bool TruncateWarehouseReceipt();

        (string, object, object) ImportWarehouseReceipt(List<WarehouseReceipt> list);

        PagedInfo<WarehouseReceiptDto> ExportList(WarehouseReceiptQueryDto parm);
        List<WarehouseReceipt> GetCode();

    }
}
