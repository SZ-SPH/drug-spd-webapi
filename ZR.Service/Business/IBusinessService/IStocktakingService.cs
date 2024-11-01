using ZR.Model.Business.Dto;
using ZR.Model.Business;
using Infrastructure.Model;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 盘点单service接口
    /// </summary>
    public interface IStocktakingService : IBaseService<Stocktaking>
    {
        PagedInfo<StocktakingDto> GetList(StocktakingQueryDto parm);

        Stocktaking GetInfo(int Id);


        Stocktaking AddStocktaking(Stocktaking parm);
        int UpdateStocktaking(Stocktaking parm);


        PagedInfo<StocktakingDto> ExportList(StocktakingQueryDto parm);
        void AddStocktakingNo(TokenModel user);
    }
}
