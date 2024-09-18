using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 药品基础资料管理service接口
    /// </summary>
    public interface IHisDrugService : IBaseService<HisDrug>
    {
        PagedInfo<HisDrugDto> GetList(HisDrugQueryDto parm);

        HisDrug GetInfo(string code);

    }
}