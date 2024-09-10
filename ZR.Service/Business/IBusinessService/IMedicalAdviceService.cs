using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 医嘱基础信息service接口
    /// </summary>
    public interface IMedicalAdviceService : IBaseService<MedicalAdvice>
    {
        PagedInfo<MedicalAdviceDto> GetList(MedicalAdviceQueryDto parm);

        MedicalAdvice GetInfo(int OrderId);


        MedicalAdvice AddMedicalAdvice(MedicalAdvice parm);
        int UpdateMedicalAdvice(MedicalAdvice parm);


        PagedInfo<MedicalAdviceDto> ExportList(MedicalAdviceQueryDto parm);
    }
}
