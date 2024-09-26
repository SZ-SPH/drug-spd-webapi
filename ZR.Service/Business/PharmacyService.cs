using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 药房Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IPharmacyService), ServiceLifetime = LifeTime.Transient)]
    public class PharmacyService : BaseService<Pharmacy>, IPharmacyService
    {
        /// <summary>
        /// 查询药房列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PharmacyDto> GetList(PharmacyQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Pharmacy, PharmacyDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Pharmacy GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加药房
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Pharmacy AddPharmacy(Pharmacy model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改药房
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePharmacy(Pharmacy model)
        {
            return Update(model, true, "修改药房");
        }

        /// <summary>
        /// 清空药房
        /// </summary>
        /// <returns></returns>
        public bool TruncatePharmacy()
        {
            var newTableName = $"pharmacy_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("pharmacy", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入药房
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportPharmacy(List<Pharmacy> list)
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
        /// 导出药房
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<PharmacyDto> ExportList(PharmacyQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new PharmacyDto()
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
        private static Expressionable<Pharmacy> QueryExp(PharmacyQueryDto parm)
        {
            var predicate = Expressionable.Create<Pharmacy>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PharmacyName), it => it.PharmacyName == parm.PharmacyName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.State), it => it.State == parm.State);
            return predicate;
        }
    }
}