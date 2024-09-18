using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 溯源信息service接口
    /// </summary>
    public interface IChesViewService : IBaseService<ChesView>
    {
        PagedInfo<ChesViewDto> GetList(ChesViewQueryDto parm);

        ChesView GetInfo(int Id);


        ChesView AddChesView(ChesView parm);
        int UpdateChesView(ChesView parm);

        bool TruncateChesView();

        (string, object, object) ImportChesView(List<ChesView> list);

        PagedInfo<ChesViewDto> ExportList(ChesViewQueryDto parm);
    }
}
