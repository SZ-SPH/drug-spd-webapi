using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 货位service接口
    /// </summary>
    public interface ILocationService : IBaseService<Location>
    {
        PagedInfo<LocationDto> GetList(LocationQueryDto parm);

        Location GetInfo(int Id);


        Location AddLocation(Location parm);
        int UpdateLocation(Location parm);
        
        bool TruncateLocation();

        (string, object, object) ImportLocation(List<Location> list);

        PagedInfo<LocationDto> ExportList(LocationQueryDto parm);
    }
}
