using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 合同药品service接口
    /// </summary>
    public interface ISupplyContractDrugService : IBaseService<SupplyContractDrug>
    {
        PagedInfo<SupplyDrugDto> GetList(SupplyDrugQueryDto parm);

        SupplyContractDrug GetInfo(int Id);


        SupplyContractDrug AddSupplyContractDrug(SupplyContractDrug parm);
        int UpdateSupplyContractDrug(SupplyContractDrug parm);
        
        bool TruncateSupplyContractDrug();

        (string, object, object) ImportSupplyContractDrug(List<SupplyContractDrug> list);

        PagedInfo<SupplyContractDrugDto> ExportList(SupplyContractDrugQueryDto parm);
    }
}
