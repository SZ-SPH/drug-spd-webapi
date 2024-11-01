using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using ZR.Common;
using Infrastructure.Model;
using Aliyun.OSS;
using System;

namespace ZR.Service.Business
{
    /// <summary>
    /// 盘点单Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IStocktakingService), ServiceLifetime = LifeTime.Transient)]
    public class StocktakingService : BaseService<Stocktaking>, IStocktakingService
    {
        /// <summary>
        /// 查询盘点单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StocktakingDto> GetList(StocktakingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            // maybeTodo
            var response = Context.Queryable<Stocktaking>()
                //.Includes(x => x.StocktakingItemNav) //填充子对象
                .Where(predicate.ToExpression())
                .ToPage<Stocktaking, StocktakingDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Stocktaking GetInfo(int Id)
        {
            var response = Queryable()
                .Includes(x => x.StocktakingItemNav) //填充子对象
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加盘点单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Stocktaking AddStocktaking(Stocktaking model)
        {
            return Context.InsertNav(model).Include(s1 => s1.StocktakingItemNav).ExecuteReturnEntity();
        }

        public void AddStocktakingNo(TokenModel user)
        {
            string TakingNo = $@"ST{SnowFlakeSingle.Instance.getID()}";
            string CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //Context.Insertable().
            //插入盘点主表
            Dictionary<string, object> dict = new Dictionary<string, Object>();
            dict.Add("STOKING_NO", TakingNo);
            dict.Add("GENERATE_TIME", CurrentTime);
            dict.Add("GENERATE_MAN", user.UserName);
            dict.Add("CREATE_TIME", CurrentTime);
            dict.Add("UPDATE_TIME", CurrentTime);
            //盘点主表ID
            int stockingId = Context.Insertable(dict).AS("T_STOCKTAKING").ExecuteReturnIdentity();
            //盘点明细
            var response = Context.Queryable<Stock>()
                .LeftJoin<Drug>((s, d) => s.DrugId == d.DrugId)
                .GroupBy((s, d) => new
                {
                    d.DrugName,
                    s.BatchON,
                    s.BatchNum,
                    d.DrugMnemonicCode,
                    d.DrugSpecifications,
                    d.DrugCategory,
                    d.RefCode
                })
                .Select((s, d) => new StocktakingItem
                {
                    CreateTime = DateTime.Now,
                    UpdateTime = DateTime.Now,
                    StockMainId = stockingId,
                    DrugName = d.DrugName,
                    DrugQty = SqlFunc.AggregateSum(s.InventoryQuantity).ToString(),
                    StocktakingQty = "0",
                    DrugSpec = d.DrugSpecifications,
                    DrugCategory = d.DrugCategory,
                    DrugMnemonicCode = d.DrugMnemonicCode,
                    BatchNo = s.BatchON,
                    BatchNum = s.BatchNum.ToString(),
                    TracingCodePrefix = d.RefCode
                }).ToList();

            Context.Insertable(response).ExecuteCommand();
        }

        /// <summary>
        /// 修改盘点单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateStocktaking(Stocktaking model)
        {
            return Context.UpdateNav(model).Include(z1 => z1.StocktakingItemNav).ExecuteCommand() ? 1 : 0;
        }

        /// <summary>
        /// 导出盘点单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StocktakingDto> ExportList(StocktakingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new StocktakingDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<Stocktaking> QueryExp(StocktakingQueryDto parm)
        {
            var predicate = Expressionable.Create<Stocktaking>();

            return predicate;
        }
    }
}