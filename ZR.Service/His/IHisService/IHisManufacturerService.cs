using ZR.Model.Business.Dto;
using ZR.Model.His;
using ZR.Model.His.Dto;

namespace ZR.Service.His.IHisService
{
    /// <summary>
    /// 药品基础资料管理service接口
    /// </summary>
    public interface IHisManufacturerService : IBaseService<HisManufacturer>
    {
        PagedInfo<HisManufacturerDto> GetList(HisManufacturerQueryDto parm);

        HisManufacturer GetInfo(string code);

    }
}