using ZR.Model.Business.Dto;
using ZR.Model.Business;
using Infrastructure.Model;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 入库信息service接口
    /// </summary>
    public interface IInWarehousingDrugService : IBaseService<InWarehousingDrug>
    {
        PagedInfo<InWarehousingDrugDto> GetList(InWarehousingDrugQueryDto parm);

        InWarehousingDrug GetInfo(int Id);


        InWarehousingDrug AddInWarehousingDrug(InWarehousingDrug parm);
        int UpdateInWarehousingDrug(InWarehousingDrug parm);


        PagedInfo<InWarehousingDrugDto> ExportList(InWarehousingDrugQueryDto parm);
        int UpdatePdaInWarehousingDrug(InWarehousingDrugDto parm);
    }
}