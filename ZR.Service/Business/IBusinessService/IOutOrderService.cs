using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 出库单service接口
    /// </summary>
    public interface IOutOrderService : IBaseService<OutOrder>
    {
        PagedInfo<OutOrderDto> GetList(OutOrderQueryDto parm);

        OutOrder GetInfo(int Id);


        OutOrder AddOutOrder(OutOrder parm);
        int UpdateOutOrder(OutOrder parm);
        
        bool TruncateOutOrder();

        (string, object, object) ImportOutOrder(List<OutOrder> list);

        PagedInfo<OutOrderDto> ExportList(OutOrderQueryDto parm);
    }
}
