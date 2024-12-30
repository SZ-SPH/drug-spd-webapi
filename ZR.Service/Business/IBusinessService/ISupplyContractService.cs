using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 合同service接口
    /// </summary>
    public interface ISupplyContractService : IBaseService<SupplyContract>
    {
        PagedInfo<SupplyContractDto> GetList(SupplyContractQueryDto parm);

        SupplyContract GetInfo(int Id);


        SupplyContract AddSupplyContract(SupplyContract parm);
        int UpdateSupplyContract(SupplyContract parm);
        
        bool TruncateSupplyContract();

        (string, object, object) ImportSupplyContract(List<SupplyContract> list);

        PagedInfo<SupplyContractDto> ExportList(SupplyContractQueryDto parm);
    }
}
