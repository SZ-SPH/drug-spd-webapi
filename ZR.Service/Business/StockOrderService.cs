using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using System.ComponentModel;

namespace ZR.Service.Business
{
    /// <summary>
    /// 备货单Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IStockOrderService), ServiceLifetime = LifeTime.Transient)]
    public class StockOrderService : BaseService<StockOrder>, IStockOrderService
    {
        /// <summary>
        /// 查询备货单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StockOrderDto> GetList(StockOrderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<StockOrder, StockOrderDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public StockOrder GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加备货单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public StockOrder AddStockOrder(StockOrder model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改备货单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateStockOrder(StockOrder model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空备货单
        /// </summary>
        /// <returns></returns>
        public bool TruncateStockOrder()
        {
            var newTableName = $"StockOrder_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("StockOrder", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入备货单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportStockOrder(List<StockOrder> list)
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
        /// 导出备货单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<StockOrderDto> ExportList(StockOrderQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new StockOrderDto()
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
        private static Expressionable<StockOrder> QueryExp(StockOrderQueryDto parm)
        {
            var predicate = Expressionable.Create<StockOrder>();

            predicate = predicate.AndIF(parm.ReceiptId != null, it => it.ReceiptId == parm.ReceiptId);
            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(parm.DeliveryQuantity != null, it => it.DeliveryQuantity == parm.DeliveryQuantity);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DeliveryHospital), it => it.DeliveryHospital.Contains(parm.DeliveryHospital));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DeliveryAddress), it => it.DeliveryAddress.Contains(parm.DeliveryAddress));
            return predicate;
        }
    }
}