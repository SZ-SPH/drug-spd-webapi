using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 医嘱药品Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IMADrugService), ServiceLifetime = LifeTime.Transient)]
    public class MADrugService : BaseService<MADrug>, IMADrugService
    {
        /// <summary>
        /// 查询医嘱药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MADrugDto> GetList(MADrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MADrug, MADrugDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public MADrug GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加医嘱药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MADrug AddMADrug(MADrug model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改医嘱药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMADrug(MADrug model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空医嘱药品
        /// </summary>
        /// <returns></returns>
        public bool TruncateMADrug()
        {
            var newTableName = $"MADrug_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("MADrug", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入医嘱药品
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMADrug(List<MADrug> list)
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
        /// 导出医嘱药品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MADrugDto> ExportList(MADrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MADrugDto()
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
        private static Expressionable<MADrug> QueryExp(MADrugQueryDto parm)
        {
            var predicate = Expressionable.Create<MADrug>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.MedicalAdviceId), it => it.MedicalAdviceId == parm.MedicalAdviceId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugId), it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugDetails), it => it.DrugDetails == parm.DrugDetails);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CodeId), it => it.CodeId == parm.CodeId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.CodeDetails), it => it.CodeDetails == parm.CodeDetails);
            return predicate;
        }
    }
}