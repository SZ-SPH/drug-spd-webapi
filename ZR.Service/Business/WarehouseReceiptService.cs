using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 入库单Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IWarehouseReceiptService), ServiceLifetime = LifeTime.Transient)]
    public class WarehouseReceiptService : BaseService<WarehouseReceipt>, IWarehouseReceiptService
    {
        public bool AddReceiptdrug(string proc, List<SugarParameter> sugars)
        {

            var dt = UseStoredProcedureToDataTable(proc, sugars);

            return true;

        }

        /// <summary>
        /// 查询入库单列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WarehouseReceiptDto> GetList(WarehouseReceiptQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<WarehouseReceipt, WarehouseReceiptDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="ReceiptId"></param>
        /// <returns></returns>
        public WarehouseReceipt GetInfo(int ReceiptId)
        {
            var response = Queryable()
                .Where(x => x.ReceiptId == ReceiptId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加入库单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public WarehouseReceipt AddWarehouseReceipt(WarehouseReceipt model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改入库单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWarehouseReceipt(WarehouseReceipt model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空入库单
        /// </summary>
        /// <returns></returns>
        public bool TruncateWarehouseReceipt()
        {
            var newTableName = $"WarehouseReceipt_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("WarehouseReceipt", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入入库单
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportWarehouseReceipt(List<WarehouseReceipt> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.ReceiptId.IsEmpty(), "入库单id不能为空")
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
        /// 导出入库单
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WarehouseReceiptDto> ExportList(WarehouseReceiptQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new WarehouseReceiptDto()
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
        private static Expressionable<WarehouseReceipt> QueryExp(WarehouseReceiptQueryDto parm)
        {
            var predicate = Expressionable.Create<WarehouseReceipt>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ReceiptCode), it => it.ReceiptCode.Contains(parm.ReceiptCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.StorageTime), it => it.StorageTime == parm.StorageTime);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CreationTime), it => it.CreationTime == parm.CreationTime);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Creator), it => it.Creator == parm.Creator);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ChangeTime), it => it.ChangeTime == parm.ChangeTime);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ModifiedBy), it => it.ModifiedBy == parm.ModifiedBy);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.State), it => it.State == parm.State);
            predicate = predicate.AndIF(parm.SupplierId != null, it => it.SupplierId == parm.SupplierId);


            return predicate;
        }
    }
}