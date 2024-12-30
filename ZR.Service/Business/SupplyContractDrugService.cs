using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 合同药品Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(ISupplyContractDrugService), ServiceLifetime = LifeTime.Transient)]
    public class SupplyContractDrugService : BaseService<SupplyContractDrug>, ISupplyContractDrugService
    {
        /// <summary>
        /// 查询合同药品列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SupplyDrugDto> GetList(SupplyDrugQueryDto parm)
        {
            //var predicate = QueryExp(parm);

            //var response = Queryable()
            //    .Where(predicate.ToExpression())
            //    .ToPage<SupplyContractDrug, SupplyContractDrugDto>(parm);

            var predicate = QueryExp(parm);

            var response = Queryable()
                .LeftJoin<Drug>((it, d) => it.DrugCode == d.DrugCode)
                .Select((it, d) =>
                            new SupplyDrug
                            {
                                Id = it.Id,
                                ContractCode = it.ContractCode,
                                DrugCode = d.DrugCode,
                                States = it.States,
                                DrugId = d.DrugId,
                                DrugName = d.DrugName,
                                DrugMnemonicCode = d.DrugMnemonicCode,
                                DrugSpecifications = d.DrugSpecifications,
                                DrugCategory = d.DrugCategory,
                                DrugVarietyName = d.DrugVarietyName,
                                DrugClassification = d.DrugClassification,
                                TracingSourceCode = d.TracingSourceCode,
                                DrugBatchNumber = d.DrugBatchNumber,
                                Minunit = d.Minunit,
                                ProduceName = d.ProduceName,
                                PackageRatio = d.PackageRatio,
                                RefCode = d.RefCode,
                                PackageUnit = d.PackageUnit,
                                HisID = d.HisID,
                                Price = d.Price,
                                DefaultLocation = d.DefaultLocation,
                                ChangeTime = d.ChangeTime,
                                CreationTime = d.CreationTime,
                                HisPrice = d.HisPrice,
                                KfEnable = d.KfEnable,
                                YfEnable = d.YfEnable
                            }
                )
                 .Where(predicate.ToExpression())
                 .ToPage<SupplyDrug, SupplyDrugDto>(parm);
            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SupplyContractDrug GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加合同药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SupplyContractDrug AddSupplyContractDrug(SupplyContractDrug model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改合同药品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSupplyContractDrug(SupplyContractDrug model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 清空合同药品
        /// </summary>
        /// <returns></returns>
        public bool TruncateSupplyContractDrug()
        {
            var newTableName = $"SupplyContractDrug_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("SupplyContractDrug", newTableName);
            }
            
            return Truncate();
        }
        /// <summary>
        /// 导入合同药品
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportSupplyContractDrug(List<SupplyContractDrug> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                //.SplitError(x => x.Item.ContractCode.IsEmpty(), "合同编号不能为空")
                //.SplitError(x => x.Item.DrugCode.IsEmpty(), "合同药品的唯一标识符不能为空")
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
        /// 导出合同药品
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<SupplyContractDrugDto> ExportList(SupplyContractDrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new SupplyContractDrugDto()
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
        private static Expressionable<SupplyContractDrug> QueryExp(SupplyContractDrugQueryDto parm)
        {
            var predicate = Expressionable.Create<SupplyContractDrug>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ContractCode), it => it.ContractCode == parm.ContractCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugCode), it => it.DrugCode == parm.DrugCode);
            return predicate;
        }

        private static Expressionable<SupplyDrug> QueryExp(SupplyDrugQueryDto parm)
        {
            var predicate = Expressionable.Create<SupplyDrug>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.ContractCode), it => it.ContractCode == parm.ContractCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugCode), it => it.DrugCode == parm.DrugCode);
            return predicate;
        }
    }
}