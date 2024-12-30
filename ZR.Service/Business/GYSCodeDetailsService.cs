using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 送货单追溯码Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IGYSCodeDetailsService), ServiceLifetime = LifeTime.Transient)]
    public class GYSCodeDetailsService : BaseService<GYSCodeDetails>, IGYSCodeDetailsService
    {
        /// <summary>
        /// 查询送货单追溯码列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<GYSCodeDetailsDto> GetList(GYSCodeDetailsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<GYSCodeDetails, GYSCodeDetailsDto>(parm);

            return response;
        }
        public List<GYSCodeDetails> CodeGetList(int id,int inid)
        {
            var response = Queryable()
                .Where(it => it.Deliveryid == id && it.InDeliveryId == inid)
                .Where(it => it.Deliveryid != null && it.InDeliveryId != null)
                .ToList();
            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public GYSCodeDetails GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加送货单追溯码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GYSCodeDetails AddGYSCodeDetails(GYSCodeDetails model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改送货单追溯码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateGYSCodeDetails(GYSCodeDetails model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空送货单追溯码
        /// </summary>
        /// <returns></returns>
        public bool TruncateGYSCodeDetails()
        {
            var newTableName = $"GYSCodeDetails_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("GYSCodeDetails", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入送货单追溯码
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportGYSCodeDetails(List<GYSCodeDetails> list)
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
        /// 导出送货单追溯码
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<GYSCodeDetailsDto> ExportList(GYSCodeDetailsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new GYSCodeDetailsDto()
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
        private static Expressionable<GYSCodeDetails> QueryExp(GYSCodeDetailsQueryDto parm)
        {
            var predicate = Expressionable.Create<GYSCodeDetails>();

            predicate = predicate.AndIF(parm.Deliveryid != null, it => it.Deliveryid == parm.Deliveryid);
            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Code), it => it.Code == parm.Code);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PhysicName), it => it.PhysicName.Contains(parm.PhysicName));
            predicate = predicate.AndIF(parm.InDeliveryId != null, it => it.InDeliveryId == parm.InDeliveryId);
            predicate = predicate.AndIF(parm.MedicalAdviceId != null, it => it.MedicalAdviceId == parm.MedicalAdviceId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.InvoiceCode), it => it.InvoiceCode == parm.InvoiceCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ParentCode), it => it.ParentCode == parm.ParentCode);
            return predicate;
        }
    }
}