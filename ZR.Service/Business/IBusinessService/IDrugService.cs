using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 药品基础资料管理service接口
    /// </summary>
    public interface IDrugService : IBaseService<Drug>
    {
        PagedInfo<DrugDto> GetList(DrugQueryDto parm);
        PagedInfo<DrugDto> GYSGetList(GYSDrugQueryDto parm);

        Drug GetListWithCondition(InWarehousingPdaDto parm);

        Drug GetInfo(int DrugId);


        Drug AddDrug(Drug parm);
        int UpdateDrug(Drug parm);

        bool TruncateDrug();

        (string, object, object) ImportDrug(List<Drug> list);

        PagedInfo<DrugDto> ExportList(DrugQueryDto parm);
        int TopSevenBind(InWarehousingDto param);
    }
}