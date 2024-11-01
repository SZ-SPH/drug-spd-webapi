using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 盘点明细Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IStocktakingItemService), ServiceLifetime = LifeTime.Transient)]
    public class StocktakingItemService : BaseService<StocktakingItem>, IStocktakingItemService
    {
        /// <summary>
        /// 查询盘点明细列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StocktakingItemDto> GetList(StocktakingItemQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<StocktakingItem, StocktakingItemDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public StocktakingItem GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加盘点明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public StocktakingItem AddStocktakingItem(StocktakingItem model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改盘点明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateStocktakingItem(StocktakingItem model)
        {
            return Update(model, true);
        }

        public int PdaUpdateStocktakingItem(StocktakingItem model)
        {
            string tracingCodePrefix = model.TracingCodePrefix;
            int v = Context.Updateable<StocktakingItem>().SetColumns(it => it.StocktakingQty == (int.Parse(it.StocktakingQty) + int.Parse(model.StocktakingQty)).ToString()).Where(it => it.TracingCodePrefix == model.TracingCodePrefix).ExecuteCommand();
            return v;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<StocktakingItem> QueryExp(StocktakingItemQueryDto parm)
        {
            var predicate = Expressionable.Create<StocktakingItem>();

            return predicate;
        }
    }
}