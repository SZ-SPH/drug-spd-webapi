using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using System.ComponentModel;

namespace ZR.Service.Business
{
    /// <summary>
    /// 码信息Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ICodeDetailsService), ServiceLifetime = LifeTime.Transient)]
    public class CodeDetailsService : BaseService<CodeDetails>, ICodeDetailsService
    {
        /// <summary>
        /// 查询码信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<CodeDetailsDto> GetList(CodeDetailsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<CodeDetails, CodeDetailsDto>(parm);

            return response;
        }
        public List<CodeDetails> outGetList(int MID)
        {

            var response = Queryable()
                .Where(x => x.MedicalAdviceId == MID).ToList();
            return response;
        }
        
        public List<CodeDetails> QueryPdaAdviceBindCodeList(CodeDetailsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToList();
            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CodeDetails GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加码信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CodeDetails AddCodeDetails(CodeDetails model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改码信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateCodeDetails(CodeDetails model)
        {
            return Update(model, true);
        }

        public int PdaAdviceDeleteItem(string id)
        {
            int res = Context.Updateable<CodeDetails>()
                .SetColumns(it => new CodeDetails
                {
                    MedicalAdviceId = null
                })
                .Where(it => it.Id.ToString() == id)
                .ExecuteCommand();
            return res;
        }

        /// <summary>
        /// PDA 添加码信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public int PdaAdviceAddItem(CodeDetailsQueryDto parm)
        {
            var codeDetailres = Context.Queryable<CodeDetails>()
            .Where(it => it.MedicalAdviceId == null && it.Code == parm.Code)
            .Take(1)  // 获取符合条件的第一条记录
            .First();
            int res = Context.Updateable<CodeDetails>()
                .SetColumns(it => new CodeDetails
                {
                    MedicalAdviceId =parm.MedicalAdviceId
                }).Where(it => it.Id == codeDetailres.Id)
                .ExecuteCommand();
            return res;
        }

        /// <summary>
        /// 清空码信息
        /// </summary>
        /// <returns></returns>
        public bool TruncateCodeDetails()
        {
            var newTableName = $"CodeDetails_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("CodeDetails", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入码信息
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportCodeDetails(List<CodeDetails> list)
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
        /// 导出码信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<CodeexportDto> ExportList(CodeDetailsQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select(it => new CodeexportDto()
                {        
                    Code = it.Code,
                    PhysicTypeDesc = it.PhysicTypeDesc,
                    RefEntId = it.RefEntId,
                    EntName = it.EntName,
                    // 使用辅助方法获取枚举描述
                    PackageLevel = it.PackageLevel,
                    PhysicName = it.PhysicName,
                    Exprie = it.Exprie,
                    DrugEntBaseInfoId = it.DrugEntBaseInfoId,
                    ApprovalLicenceNo = it.ApprovalLicenceNo,
                    PkgSpecCrit = it.PkgSpecCrit,
                    PrepnSpec = it.PrepnSpec,
                    PrepnTypeDesc = it.PrepnTypeDesc,
                    ProduceDateStr = it.ProduceDateStr,
                    PkgAmount = it.PkgAmount,
                    ExpireDate = it.ExpireDate,
                    BatchNo = it.BatchNo,
                }, true)
                .ToPage(parm);

            return response;
        }
   
        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<CodeDetails> QueryExp(CodeDetailsQueryDto parm)
        {
            var predicate = Expressionable.Create<CodeDetails>();

            predicate = predicate.AndIF(parm.Receiptid != null, it => it.Receiptid == parm.Receiptid);
            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(parm.DrugId != null, it => it.InWarehouseId == parm.InWarehouseId);
            predicate = predicate.AndIF(parm.DrugId != null, it => it.MedicalAdviceId == parm.MedicalAdviceId);

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.Code), it => it.Code == parm.Code);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.RefEntId), it => it.RefEntId == parm.RefEntId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EntName), it => it.EntName == parm.EntName);
            return predicate;
        }
    }
}