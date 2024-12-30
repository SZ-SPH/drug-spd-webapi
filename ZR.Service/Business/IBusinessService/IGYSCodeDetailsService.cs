using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 送货单追溯码service接口
    /// </summary>
    public interface IGYSCodeDetailsService : IBaseService<GYSCodeDetails>
    {
        PagedInfo<GYSCodeDetailsDto> GetList(GYSCodeDetailsQueryDto parm);

        GYSCodeDetails GetInfo(int Id);
        List<GYSCodeDetails> CodeGetList(int id, int inid);

        GYSCodeDetails AddGYSCodeDetails(GYSCodeDetails parm);
        int UpdateGYSCodeDetails(GYSCodeDetails parm);
        
        bool TruncateGYSCodeDetails();

        (string, object, object) ImportGYSCodeDetails(List<GYSCodeDetails> list);

        PagedInfo<GYSCodeDetailsDto> ExportList(GYSCodeDetailsQueryDto parm);
    }
}
