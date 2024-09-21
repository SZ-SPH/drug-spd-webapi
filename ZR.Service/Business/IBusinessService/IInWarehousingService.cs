using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 入库信息service接口
    /// </summary>
    public interface IInWarehousingService : IBaseService<InWarehousing>
    {
        PagedInfo<InWarehousingDto> GetList(InWarehousingQueryDto parm);

        InWarehousing GetInfo(int Id);


        InWarehousing AddInWarehousing(InWarehousing parm);

        InWarehousing AddInWarehousingWithCondition(InWarehousing parm);
        int UpdateInWarehousing(InWarehousing parm);


        PagedInfo<InWarehousingDto> ExportList(InWarehousingQueryDto parm);

        List<InWarehousing> inGetList(int Id);

    }
}