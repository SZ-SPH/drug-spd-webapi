using ZR.Model.Business.Dto;
using ZR.Model.His;
using ZR.Model.His.Dto;

namespace ZR.Service.His.IHisService
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