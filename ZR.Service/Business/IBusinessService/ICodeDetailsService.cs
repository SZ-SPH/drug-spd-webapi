using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 码信息service接口
    /// </summary>
    public interface ICodeDetailsService : IBaseService<CodeDetails>
    {
        PagedInfo<CodeDetailsDto> GetList(CodeDetailsQueryDto parm);

        CodeDetails GetInfo(int Id);


        CodeDetails AddCodeDetails(CodeDetails parm);
        int UpdateCodeDetails(CodeDetails parm);
        
        bool TruncateCodeDetails();

        (string, object, object) ImportCodeDetails(List<CodeDetails> list);

        PagedInfo<CodeDetailsDto> ExportList(CodeDetailsQueryDto parm);
    }
}
