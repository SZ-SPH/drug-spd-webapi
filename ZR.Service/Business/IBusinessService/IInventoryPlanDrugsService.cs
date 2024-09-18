using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 入库计划药品service接口
    /// </summary>
    public interface IInventoryPlanDrugsService : IBaseService<InventoryPlanDrugs>
    {
        PagedInfo<InventoryPlanDrugsDto> GetList(InventoryPlanDrugsQueryDto parm);

        InventoryPlanDrugs GetInfo(int Id);


        InventoryPlanDrugs AddInventoryPlanDrugs(InventoryPlanDrugs parm);
        int UpdateInventoryPlanDrugs(InventoryPlanDrugs parm);
        
        bool TruncateInventoryPlanDrugs();

        (string, object, object) ImportInventoryPlanDrugs(List<InventoryPlanDrugs> list);

        PagedInfo<InventoryPlanDrugsDto> ExportList(InventoryPlanDrugsQueryDto parm);
    }
}
