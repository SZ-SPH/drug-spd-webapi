using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 仓库Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IWarehouseService), ServiceLifetime = LifeTime.Transient)]
    public class WarehouseService : BaseService<Warehouse>, IWarehouseService
    {
        /// <summary>
        /// 查询仓库列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WarehouseDto> GetList(WarehouseQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Warehouse, WarehouseDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Warehouse GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Warehouse AddWarehouse(Warehouse model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改仓库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateWarehouse(Warehouse model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空仓库
        /// </summary>
        /// <returns></returns>
        public bool TruncateWarehouse()
        {
            var newTableName = $"Warehouse_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("Warehouse", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入仓库
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportWarehouse(List<Warehouse> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.Id.IsEmpty(), "id不能为空")
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
        /// 导出仓库
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<WarehouseDto> ExportList(WarehouseQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new WarehouseDto()
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
        private static Expressionable<Warehouse> QueryExp(WarehouseQueryDto parm)
        {
            var predicate = Expressionable.Create<Warehouse>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Name), it => it.Name.Contains(parm.Name));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.State), it => it.State == parm.State);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Code), it => it.Code == parm.Code);
            return predicate;
        }
    }
}