using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 申请计划service接口
    /// </summary>
    public interface IApplicationPlanService : IBaseService<ApplicationPlan>
    {
        PagedInfo<ApplicationPlanDto> GetList(ApplicationPlanQueryDto parm);

        ApplicationPlan GetInfo(int Id);


        ApplicationPlan AddApplicationPlan(ApplicationPlan parm);
        int UpdateApplicationPlan(ApplicationPlan parm);
        
        bool TruncateApplicationPlan();

        (string, object, object) ImportApplicationPlan(List<ApplicationPlan> list);

        PagedInfo<ApplicationPlanDto> ExportList(ApplicationPlanQueryDto parm);
    }
}
