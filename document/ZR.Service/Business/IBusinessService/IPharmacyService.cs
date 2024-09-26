using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 药房service接口
    /// </summary>
    public interface IPharmacyService : IBaseService<Pharmacy>
    {
        PagedInfo<PharmacyDto> GetList(PharmacyQueryDto parm);

        Pharmacy GetInfo(int Id);


        Pharmacy AddPharmacy(Pharmacy parm);
        int UpdatePharmacy(Pharmacy parm);
        
        bool TruncatePharmacy();

        (string, object, object) ImportPharmacy(List<Pharmacy> list);

        PagedInfo<PharmacyDto> ExportList(PharmacyQueryDto parm);
    }
}
