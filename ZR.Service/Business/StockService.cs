using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using Org.BouncyCastle.Crypto;

namespace ZR.Service.Business
{
    /// <summary>
    /// 库存Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IStockService), ServiceLifetime = LifeTime.Transient)]
    public class StockService : BaseService<Stock>, IStockService
    {
        /// <summary>
        /// 查询库存列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StockDto> GetList(StockQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Stock, StockDto>(parm);

            return response;
        }

        /// <summary>
        /// PDA查询库存列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public List<PdaStockVo> GetPdaList(StockQueryDto parm)
        {
            var predicate = QueryExp(parm);
            var value = Context.Queryable<Stock>()
                .LeftJoin<Drug>((s, d) => s.DrugId == d.DrugId)
                .Where(predicate.ToExpression())
                .Select((s, d) => new PdaStockVo
                {
                    Id = s.Id,
                    DrugId = s.DrugId,
                    InventoryQuantity = s.InventoryQuantity,
                    DrugName = d.DrugName,
                    DrugCode = d.DrugCode,
                    DrugMnemonicCode = d.DrugMnemonicCode,
                    DrugSpecifications = d.DrugSpecifications
                }).ToList();
            return value;

        }

        public Stock SGetList(int drugid)
        {

            var response = Queryable()
                .OrderBy("Id asc")
                .Where(x => x.DrugId == drugid).First();


            return response;
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Stock GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        public List<Stock> AllGetInfo(List<int> Ids)
        {
            var drugIds = Ids; // 你的 drugid 列表
            var response = Queryable()
                           .Where(it => Ids.Contains((int)it.DrugId))
                           .ToList();
            return response;
        }


        public Stock InGetInfo(int drugid,string batchON)
        {
            var response = Queryable()
                           .Where(it =>it.DrugId==drugid && it.BatchON==batchON)
                           .First();
            return response;
        }


        /// <summary>
        /// 添加库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Stock AddStock(Stock model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        public async Task<Stock> AddStockAsync(Stock parm)
        {
            return await Insertable(parm).ExecuteReturnEntityAsync();
        }

        /// <summary>
        /// 修改库存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateStock(Stock model)
        {
            return Update(model, true, "修改库存");
        }

        /// <summary>
        /// 清空库存
        /// </summary>
        /// <returns></returns>
        public bool TruncateStock()
        {
            var newTableName = $"stock_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("stock", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入库存
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportStock(List<Stock> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                //.WhereColumns(it => it.UserName)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();//插入可插入部分;

            string msg = $"插入{x.InsertList.Count} 更新{x.UpdateList.Count} 错误数据{x.ErrorList.Count} 不计算数据{x.IgnoreList.Count} 删除数据{x.DeleteList.Count} 总共{x.TotalList.Count}";                    
            Console.WriteLine(msg);

            //输出错误信息               
            foreach (var item in x.ErrorList)
            {
                Console.WriteLine("错误" + item.StorageMessage);
            }
            foreach (var item in x.IgnoreList)
            {
                Console.WriteLine("忽略" + item.StorageMessage);
            }

            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 导出库存
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StockDto> ExportList(StockQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new StockDto()
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
        private static Expressionable<Stock> QueryExp(StockQueryDto parm)
        {
            var predicate = Expressionable.Create<Stock>();

            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BatchON), it => it.BatchON == parm.BatchON);
            predicate = predicate.AndIF(parm.BatchNum != null, it => it.BatchNum == parm.BatchNum);
            predicate = predicate.AndIF(parm.WarehouseID != null, it => it.WarehouseID == parm.WarehouseID);
            return predicate;
        }
    }
}