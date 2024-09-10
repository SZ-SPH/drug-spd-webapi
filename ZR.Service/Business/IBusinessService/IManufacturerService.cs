using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 生产厂家service接口
    /// </summary>
    public interface IManufacturerService : IBaseService<Manufacturer>
    {
        PagedInfo<ManufacturerDto> GetList(ManufacturerQueryDto parm);

        Manufacturer GetInfo(int Id);


        Manufacturer AddManufacturer(Manufacturer parm);
        int UpdateManufacturer(Manufacturer parm);
        
        bool TruncateManufacturer();

        (string, object, object) ImportManufacturer(List<Manufacturer> list);

        PagedInfo<ManufacturerDto> ExportList(ManufacturerQueryDto parm);
    }
}
