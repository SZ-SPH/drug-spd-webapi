using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using Aliyun.OSS;

namespace ZR.Service.Business
{
    /// <summary>
    /// 送货单药品Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IDeliveryOrderDrugService), ServiceLifetime = LifeTime.Transient)]
    public class DeliveryOrderDrugService : BaseService<DeliveryOrderDrug>, IDeliveryOrderDrugService
    {
        /// <summary>
        /// 查询送货单药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<DeliveryOrderDrugDto> GetList(DeliveryOrderDrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Id asc")
                .Where(predicate.ToExpression())
                .ToPage<DeliveryOrderDrug, DeliveryOrderDrugDto>(parm);

            return response;
        }
        public List<DeliveryOrderDrug> DrugGetList(int DeliveryId)
        {
            var response = Queryable()
            //.OrderBy("Id asc")
               .Where(it => it.DeliveryId != null && it.DeliveryId == DeliveryId).ToList();

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DeliveryOrderDrug GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加送货单药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DeliveryOrderDrug AddDeliveryOrderDrug(DeliveryOrderDrug model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改送货单药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateDeliveryOrderDrug(DeliveryOrderDrug model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空送货单药品
        /// </summary>
        /// <returns></returns>
        public bool TruncateDeliveryOrderDrug()
        {
            var newTableName = $"DeliveryOrderDrug_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("DeliveryOrderDrug", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入送货单药品
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportDeliveryOrderDrug(List<DeliveryOrderDrug> list)
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
        /// 导出送货单药品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<DeliveryOrderDrugDto> ExportList(DeliveryOrderDrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new DeliveryOrderDrugDto()
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
        private static Expressionable<DeliveryOrderDrug> QueryExp(DeliveryOrderDrugQueryDto parm)
        {
            var predicate = Expressionable.Create<DeliveryOrderDrug>();

            predicate = predicate.AndIF(parm.DeliveryId != null, it => it.DeliveryId == parm.DeliveryId);
            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugName), it => it.DrugName.Contains(parm.DrugName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugCode), it => it.DrugCode == parm.DrugCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugBatchNo), it => it.DrugBatchNo == parm.DrugBatchNo);
            return predicate;
        }
    }
}