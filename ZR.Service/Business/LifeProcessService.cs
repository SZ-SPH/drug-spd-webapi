using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using Microsoft.IdentityModel.Tokens;

namespace ZR.Service.Business
{
    /// <summary>
    /// 生命周期Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ILifeProcessService), ServiceLifetime = LifeTime.Transient)]
    public class LifeProcessService : BaseService<LifeProcess>, ILifeProcessService
    {
        /// <summary>
        /// 查询生命周期列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<LifeProcessDto> GetList(LifeProcessQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<LifeProcess, LifeProcessDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public LifeProcess GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加生命周期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public LifeProcess AddLifeProcess(LifeProcess model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        public async Task<int> AddLifeProcessAsync(LifeProcess parm)
        {
            return await Insertable(parm).ExecuteCommandAsync();
        }

        /// <summary>
        /// 修改生命周期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateLifeProcess(LifeProcess model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空生命周期
        /// </summary>
        /// <returns></returns>
        public bool TruncateLifeProcess()
        {
            var newTableName = $"LifeProcess_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("LifeProcess", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入生命周期
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportLifeProcess(List<LifeProcess> list)
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
        /// 导出生命周期
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<LifeProcessDto> ExportList(LifeProcessQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new LifeProcessDto()
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
        private static Expressionable<LifeProcess> QueryExp(LifeProcessQueryDto parm)
        {
            var predicate = Expressionable.Create<LifeProcess>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Receiptid), it => it.Receiptid == parm.Receiptid);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DRUGId), it => it.DRUGId == parm.DRUGId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CodeId), it => it.CodeId == parm.CodeId);

            predicate = predicate.AndIF(parm.MedicalAdviceId != null, it => it.MedicalAdviceId == parm.MedicalAdviceId);

            return predicate;
        }
    }
}
