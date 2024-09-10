using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 入库计划service接口
    /// </summary>
    public interface IInventoryPlanService : IBaseService<InventoryPlan>
    {
        PagedInfo<InventoryPlanDto> GetList(InventoryPlanQueryDto parm);

        InventoryPlan GetInfo(int Id);
        bool AddStockProc(string proc, List<SugarParameter> sugars);

        InventoryPlan AddInventoryPlan(InventoryPlan parm);
        int UpdateInventoryPlan(InventoryPlan parm);
        
        bool TruncateInventoryPlan();

        (string, object, object) ImportInventoryPlan(List<InventoryPlan> list);

        PagedInfo<InventoryPlanDto> ExportList(InventoryPlanQueryDto parm);
    }
}
