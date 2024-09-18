using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 合同管理Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISupplyContractService), ServiceLifetime = LifeTime.Transient)]
    public class SupplyContractService : BaseService<SupplyContract>, ISupplyContractService
    {
        /// <summary>
        /// 查询合同管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SupplyContractDto> GetList(SupplyContractQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Id asc")
                .Where(predicate.ToExpression())
                .ToPage<SupplyContract, SupplyContractDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SupplyContract GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加合同管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SupplyContract AddSupplyContract(SupplyContract model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改合同管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSupplyContract(SupplyContract model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空合同管理
        /// </summary>
        /// <returns></returns>
        public bool TruncateSupplyContract()
        {
            var newTableName = $"SupplyContract_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("SupplyContract", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入合同管理
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSupplyContract(List<SupplyContract> list)
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
        /// 导出合同管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SupplyContractDto> ExportList(SupplyContractQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SupplyContractDto()
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
        private static Expressionable<SupplyContract> QueryExp(SupplyContractQueryDto parm)
        {
            var predicate = Expressionable.Create<SupplyContract>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ContractCode), it => it.ContractCode == parm.ContractCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ContractDate), it => it.ContractDate == parm.ContractDate);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugId), it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.SupplierId), it => it.SupplierId == parm.SupplierId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.States), it => it.States == parm.States);
            return predicate;
        }
    }
}