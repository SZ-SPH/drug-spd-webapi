using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 供应商基础功能Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISupplierService), ServiceLifetime = LifeTime.Transient)]
    public class SupplierService : BaseService<Supplier>, ISupplierService
    {
        /// <summary>
        /// 查询供应商基础功能列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SupplierDto> GetList(SupplierQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Supplier, SupplierDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Supplier GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加供应商基础功能
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Supplier AddSupplier(Supplier model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改供应商基础功能
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSupplier(Supplier model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空供应商基础功能
        /// </summary>
        /// <returns></returns>
        public bool TruncateSupplier()
        {
            var newTableName = $"SUPPLIER_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("SUPPLIER", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入供应商基础功能
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSupplier(List<Supplier> list)
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
        /// 导出供应商基础功能
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SupplierDto> ExportList(SupplierQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SupplierDto()
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
        private static Expressionable<Supplier> QueryExp(SupplierQueryDto parm)
        {
            var predicate = Expressionable.Create<Supplier>();

            predicate = predicate.AndIF(parm.Id != null, it => it.Id == parm.Id);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SupplierName), it => it.SupplierName.Contains(parm.SupplierName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SocialCreditCode), it => it.SocialCreditCode == parm.SocialCreditCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EnterpriseAddress), it => it.EnterpriseAddress.Contains(parm.EnterpriseAddress));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EnterprisePhone), it => it.EnterprisePhone == parm.EnterprisePhone);
            return predicate;
        }
    }
}