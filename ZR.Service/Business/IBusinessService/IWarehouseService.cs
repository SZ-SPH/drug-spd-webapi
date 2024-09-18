using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 仓库service接口
    /// </summary>
    public interface IWarehouseService : IBaseService<Warehouse>
    {
        PagedInfo<WarehouseDto> GetList(WarehouseQueryDto parm);

        Warehouse GetInfo(int Id);


        Warehouse AddWarehouse(Warehouse parm);
        int UpdateWarehouse(Warehouse parm);

        bool TruncateWarehouse();

        (string, object, object) ImportWarehouse(List<Warehouse> list);

        PagedInfo<WarehouseDto> ExportList(WarehouseQueryDto parm);
    }
}