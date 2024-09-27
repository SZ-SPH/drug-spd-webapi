using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 申请计划Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IApplicationPlanService), ServiceLifetime = LifeTime.Transient)]
    public class ApplicationPlanService : BaseService<ApplicationPlan>, IApplicationPlanService
    {
        /// <summary>
        /// 查询申请计划列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ApplicationPlanDto> GetList(ApplicationPlanQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                //.OrderBy("Id asc")
                .Where(predicate.ToExpression())
                .ToPage<ApplicationPlan, ApplicationPlanDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ApplicationPlan GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }


       
        public List<ApplicationPlan> AllGetInfo(List<int> Ids)
        {
            var drugIds = Ids; // 你的 drugid 列表
            var response = Queryable()
                           .Where(it => Ids.Contains((int)it.Id))
                           .ToList();
            return response;
        }


        /// <summary>
        /// 添加申请计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ApplicationPlan AddApplicationPlan(ApplicationPlan model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改申请计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateApplicationPlan(ApplicationPlan model)
        {
            return Update(model, true, "修改申请计划");
        }

        /// <summary>
        /// 清空申请计划
        /// </summary>
        /// <returns></returns>
        public bool TruncateApplicationPlan()
        {
            var newTableName = $"applicationPlan_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("applicationPlan", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入申请计划
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportApplicationPlan(List<ApplicationPlan> list)
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
        /// 导出申请计划
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<ApplicationPlanDto> ExportList(ApplicationPlanQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new ApplicationPlanDto()
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
        private static Expressionable<ApplicationPlan> QueryExp(ApplicationPlanQueryDto parm)
        {
            var predicate = Expressionable.Create<ApplicationPlan>();

            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(parm.PharmacyId != null, it => it.PharmacyId == parm.PharmacyId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.State), it => it.State == parm.State);
            predicate = predicate.AndIF(parm.BeginTimes == null, it => it.Times >= DateTime.Now.ToShortDateString().ParseToDateTime());
            predicate = predicate.AndIF(parm.BeginTimes != null, it => it.Times >= parm.BeginTimes);
            predicate = predicate.AndIF(parm.EndTimes != null, it => it.Times <= parm.EndTimes);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Users), it => it.Users == parm.Users);
            return predicate;
        }
    }
}