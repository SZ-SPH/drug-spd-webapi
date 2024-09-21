using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 生命周期service接口
    /// </summary>
    public interface ILifeProcessService : IBaseService<LifeProcess>
    {
        PagedInfo<LifeProcessDto> GetList(LifeProcessQueryDto parm);

        LifeProcess GetInfo(int Id);


        LifeProcess AddLifeProcess(LifeProcess parm);

        Task<int> AddLifeProcessAsync(LifeProcess parm);
        int UpdateLifeProcess(LifeProcess parm);

        bool TruncateLifeProcess();

        (string, object, object) ImportLifeProcess(List<LifeProcess> list);

        PagedInfo<LifeProcessDto> ExportList(LifeProcessQueryDto parm);
    }
}