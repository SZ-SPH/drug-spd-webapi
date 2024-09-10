using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 溯源信息Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IChesViewService), ServiceLifetime = LifeTime.Transient)]
    public class ChesViewService : BaseService<ChesView>, IChesViewService
    {
        /// <summary>
        /// 查询溯源信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ChesViewDto> GetList(ChesViewQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<ChesView, ChesViewDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ChesView GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加溯源信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ChesView AddChesView(ChesView model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改溯源信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateChesView(ChesView model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空溯源信息
        /// </summary>
        /// <returns></returns>
        public bool TruncateChesView()
        {
            var newTableName = $"ChesView_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("ChesView", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入溯源信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportChesView(List<ChesView> list)
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
        /// 导出溯源信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ChesViewDto> ExportList(ChesViewQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new ChesViewDto()
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
        private static Expressionable<ChesView> QueryExp(ChesViewQueryDto parm)
        {
            var predicate = Expressionable.Create<ChesView>();

            predicate = predicate.AndIF(parm.Receiptid != null, it => it.Receiptid == parm.Receiptid);
            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Code), it => it.ReceiptCode== parm.Code);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.RefEntId), it => it.RefEntId == parm.RefEntId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EntName), it => it.EntName == parm.EntName);
            return predicate;
        }
    }
}