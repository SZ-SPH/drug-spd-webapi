using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 送货单药品service接口
    /// </summary>
    public interface IDeliveryOrderDrugService : IBaseService<DeliveryOrderDrug>
    {
        PagedInfo<DeliveryOrderDrugDto> GetList(DeliveryOrderDrugQueryDto parm);

        DeliveryOrderDrug GetInfo(int Id);


        DeliveryOrderDrug AddDeliveryOrderDrug(DeliveryOrderDrug parm);
        int UpdateDeliveryOrderDrug(DeliveryOrderDrug parm);
        
        bool TruncateDeliveryOrderDrug();

        (string, object, object) ImportDeliveryOrderDrug(List<DeliveryOrderDrug> list);

        PagedInfo<DeliveryOrderDrugDto> ExportList(DeliveryOrderDrugQueryDto parm);
    }
}
