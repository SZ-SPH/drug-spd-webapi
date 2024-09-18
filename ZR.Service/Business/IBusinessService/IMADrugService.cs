using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 医嘱药品service接口
    /// </summary>
    public interface IMADrugService : IBaseService<MADrug>
    {
        PagedInfo<MADrugDto> GetList(MADrugQueryDto parm);

        MADrug GetInfo(int Id);


        MADrug AddMADrug(MADrug parm);
        int UpdateMADrug(MADrug parm);
        
        bool TruncateMADrug();

        (string, object, object) ImportMADrug(List<MADrug> list);

        PagedInfo<MADrugDto> ExportList(MADrugQueryDto parm);
    }
}
