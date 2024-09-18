using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 送货单service接口
    /// </summary>
    public interface IDeliveryOrderService : IBaseService<DeliveryOrder>
    {
        PagedInfo<DeliveryOrderDto> GetList(DeliveryOrderQueryDto parm);

        DeliveryOrder GetInfo(int Id);


        DeliveryOrder AddDeliveryOrder(DeliveryOrder parm);
        int UpdateDeliveryOrder(DeliveryOrder parm);
        
        bool TruncateDeliveryOrder();

        (string, object, object) ImportDeliveryOrder(List<DeliveryOrder> list);

        PagedInfo<DeliveryOrderDto> ExportList(DeliveryOrderQueryDto parm);
    }
}
