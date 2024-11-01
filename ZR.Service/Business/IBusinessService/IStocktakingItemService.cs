using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
    /// <summary>
    /// 盘点明细service接口
    /// </summary>
    public interface IStocktakingItemService : IBaseService<StocktakingItem>
    {
        PagedInfo<StocktakingItemDto> GetList(StocktakingItemQueryDto parm);

        StocktakingItem GetInfo(int Id);


        StocktakingItem AddStocktakingItem(StocktakingItem parm);
        int UpdateStocktakingItem(StocktakingItem parm);

        int PdaUpdateStocktakingItem(StocktakingItem parm);


    }
}
