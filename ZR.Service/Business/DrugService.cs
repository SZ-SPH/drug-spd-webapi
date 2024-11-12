using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using ZR.Common;
using Topsdk.Top.Ability2940.Domain;

namespace ZR.Service.Business
{
    /// <summary>
    /// 药品基础资料管理Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IDrugService), ServiceLifetime = LifeTime.Transient)]
    public class DrugService : BaseService<Drug>, IDrugService
    {
        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<DrugDto> GetList(DrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<Drug, DrugDto>(parm);

            return response;
        }

        public Drug GetListWithCondition(InWarehousingPdaDto parm)
        {
            string tracingCodePrefix = "";
            Dictionary<string, object> dict = Tools.CodeInOneWay(parm.TracingSourceCode)[0];
            if (dict.ContainsKey("sub_code")) 
            {
                var value = ( List<AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo>) dict["sub_code"];
                tracingCodePrefix = value[0].Code;
            }
            else
            {
                tracingCodePrefix = dict["code"].ToString();
            }
            var response = Queryable()
                .Where(x => x.RefCode == tracingCodePrefix)
                .First();
            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="DrugId"></param>
        /// <returns></returns>
        public Drug GetInfo(int DrugId)
        {
            var response = Queryable()
                .Where(x => x.DrugId == DrugId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加药品基础资料管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Drug AddDrug(Drug model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改药品基础资料管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateDrug(Drug model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空药品基础资料管理
        /// </summary>
        /// <returns></returns>
        public bool TruncateDrug()
        {
            var newTableName = $"DRUG_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("DRUG", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入药品基础资料管理
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportDrug(List<Drug> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.DrugId.IsEmpty(), "id不能为空")
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
        /// 导出药品基础资料管理
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<DrugDto> ExportList(DrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new DrugDto()
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
        private static Expressionable<Drug> QueryExp(DrugQueryDto parm)
        {
            var predicate = Expressionable.Create<Drug>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugName), it => it.DrugName.Contains(parm.DrugName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugCode), it => it.DrugCode == parm.DrugCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugMnemonicCode), it => it.DrugMnemonicCode.Contains(parm.DrugMnemonicCode));
            return predicate;
        }
    }
}