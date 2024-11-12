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
       List<CodeDetails> outGetList(int MID);

        CodeDetails GetInfo(int Id);


        CodeDetails AddCodeDetails(CodeDetails parm);
        int UpdateCodeDetails(CodeDetails parm);
        
        bool TruncateCodeDetails();

        (string, object, object) ImportCodeDetails(List<CodeDetails> list);


        PagedInfo<CodeexportDto> ExportList(CodeDetailsQueryDto parm);
        List<CodeDetails> QueryPdaAdviceBindCodeList(CodeDetailsQueryDto parm);
        int PdaAdviceAddItem(CodeDetailsQueryDto parm);
        int PdaAdviceDeleteItem(string id);
        void PdaAddCodeDetails(CodeDetailsDto codeDetailsDto);
    }
}
