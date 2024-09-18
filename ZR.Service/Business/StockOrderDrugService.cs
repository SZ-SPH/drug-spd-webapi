using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 备货单药品Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IStockOrderDrugService), ServiceLifetime = LifeTime.Transient)]
    public class StockOrderDrugService : BaseService<StockOrderDrug>, IStockOrderDrugService
    {
        /// <summary>
        /// 查询备货单药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StockOrderDrugDto> GetList(StockOrderDrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<StockOrderDrug, StockOrderDrugDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public StockOrderDrug GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加备货单药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public StockOrderDrug AddStockOrderDrug(StockOrderDrug model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改备货单药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateStockOrderDrug(StockOrderDrug model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空备货单药品
        /// </summary>
        /// <returns></returns>
        public bool TruncateStockOrderDrug()
        {
            var newTableName = $"StockOrderDrug_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("StockOrderDrug", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入备货单药品
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportStockOrderDrug(List<StockOrderDrug> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "Id不能为空")
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
        /// 导出备货单药品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StockOrderDrugDto> ExportList(StockOrderDrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new StockOrderDrugDto()
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
        private static Expressionable<StockOrderDrug> QueryExp(StockOrderDrugQueryDto parm)
        {
            var predicate = Expressionable.Create<StockOrderDrug>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.StockId), it => it.StockId == parm.StockId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugId), it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugDetails), it => it.DrugDetails.Contains(parm.DrugDetails));
            return predicate;
        }
    }
}