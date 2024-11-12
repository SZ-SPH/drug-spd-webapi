using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 供应商基础功能service接口
    /// </summary>
    public interface ISupplierService : IBaseService<Supplier>
    {
        PagedInfo<SupplierDto> GetList(SupplierQueryDto parm);
        List<Supplier> AllGetList(AllSupplierQueryDto parm);

        Supplier GetInfo(int Id);


        Supplier AddSupplier(Supplier parm);
        int UpdateSupplier(Supplier parm);

        bool TruncateSupplier();

        (string, object, object) ImportSupplier(List<Supplier> list);

        PagedInfo<SupplierDto> ExportList(SupplierQueryDto parm);
    }
}