using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using System;
using MailKit.Search;

namespace ZR.Service.Business
{
    /// <summary>
    /// 医嘱Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IMedicalAdviceService), ServiceLifetime = LifeTime.Transient)]
    public class MedicalAdviceService : BaseService<MedicalAdvice>, IMedicalAdviceService
    {
        /// <summary>
        /// 查询医嘱列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MedicalAdviceDto> GetList(MedicalAdviceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            parm.Sort = "";
            var response = Context.Queryable<MedicalAdvice>()
                .LeftJoin<Drug>((it,d) => it.DrugId == d.HisID)
                .OrderBy((it) => it.OrderId)
                .Where(predicate.ToExpression())
                .Select((it,d) => new MedicalAdvice
                {
                    IpiReaistrationNo = it.IpiReaistrationNo,
                    DepartmentChineseName = it.DepartmentChineseName,
                    OrderedDeptId = it.OrderedDeptId,
                    AssignDrugSeq = it.AssignDrugSeq,
                    EmployeeName = it.EmployeeName,
                    OrderedDoctorId = it.OrderedDoctorId,
                    TotalQty = it.TotalQty,
                    //DrugName = d.DrugName,
                    DrugId = it.DrugId,
                    IpiRegistrationId = it.IpiRegistrationId,
                    OrderId = it.OrderId
                })
                .ToPage<MedicalAdvice, MedicalAdviceDto>(parm);

            return response;
        }

        public List<MedicalAdviceBind> PdaQueryMedicalAdviceByHisId(MedicalAdviceQueryDto parm)
        {
            var response = Context.Queryable<MedicalAdvice>()
                .LeftJoin<Drug>((o, cus) => o.DrugId == cus.HisID)
                .LeftJoin<CodeDetails>((o,cus,cd) => o.OrderId == cd.MedicalAdviceId)
                .Where(o => o.AssignDrugSeq == parm.AssignDrugSeq)
                .GroupBy((o, cus, cd) => new
                {
                    o.OrderId,
                    o.IpiRegistrationId,
                    o.DrugId,
                    o.TotalQty,
                    o.OrderedDoctorId,
                    o.EmployeeName,
                    o.AssignDrugSeq,
                    o.OrderedDeptId,
                    o.DepartmentChineseName,
                    o.IpiReaistrationNo,
                    cus.DrugName,
                    cus.DrugCode,
                    cus.DrugCategory,
                    cus.DrugMnemonicCode
                })
                .Select((o,cus,cd) => new MedicalAdviceBind()
                {
                    OrderId = o.OrderId,
                    IpiRegistrationId = o.IpiRegistrationId,
                    DrugId = o.DrugId,
                    TotalQty = o.TotalQty,
                    TrueQty = SqlFunc.AggregateCount(cd.MedicalAdviceId),
                    OrderedDoctorId  = o.OrderedDoctorId,
                    EmployeeName = o.EmployeeName,
                    AssignDrugSeq = o.AssignDrugSeq,
                    OrderedDeptId = o.OrderedDoctorId,
                    DepartmentChineseName = o.DepartmentChineseName,
                    IpiReaistrationNo = o.IpiReaistrationNo,
                    DrugName = cus.DrugName,
                    DrugCode = cus.DrugCode,
                    DrugCategory = cus.DrugCategory,
                    DrugMnemonicCode = cus.DrugMnemonicCode
                })
                .ToList();
            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="OrderId"></param>
        /// <returns></returns>
        public MedicalAdvice GetInfo(int OrderId)
        {
            var response = Queryable()
                .Where(x => x.OrderId == OrderId)
                .First();

            return response;
        }

        /// <summary>
        /// 添加医嘱
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MedicalAdvice AddMedicalAdvice(MedicalAdvice model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改医嘱
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMedicalAdvice(MedicalAdvice model)
        {
            return Update(model, true, "修改医嘱");
        }

        /// <summary>
        /// 清空医嘱
        /// </summary>
        /// <returns></returns>
        public bool TruncateMedicalAdvice()
        {
            var newTableName = $"MEDICAL_ADVICE_{DateTime.Now:yyyyMMdd}";
            if (Queryable().Any() && !Context.DbMaintenance.IsAnyTable(newTableName))
            {
                Context.DbMaintenance.BackupTable("MEDICAL_ADVICE", newTableName);
            }

            return Truncate();
        }
        /// <summary>
        /// 导入医嘱
        /// </summary>
        /// <returns></returns>
        public (string, object, object) ImportMedicalAdvice(List<MedicalAdvice> list)
        {
            var x = Context.Storageable(list)
                .SplitInsert(it => !it.Any())
                .SplitError(x => x.Item.OrderId.IsEmpty(), "id不能为空")
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
        /// 导出医嘱
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MedicalAdviceDto> ExportList(MedicalAdviceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new MedicalAdviceDto()
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
        private static Expressionable<MedicalAdvice> QueryExp(MedicalAdviceQueryDto parm)
        {
            var predicate = Expressionable.Create<MedicalAdvice>();

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IpiRegistrationId), it => it.IpiRegistrationId == parm.IpiRegistrationId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.AssignDrugSeq), it => it.AssignDrugSeq == parm.AssignDrugSeq);
            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.EmployeeName), it => it.EmployeeName == parm.EmployeeName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DepartmentChineseName), it => it.DepartmentChineseName == parm.DepartmentChineseName);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.IpiReaistrationNo), it => it.IpiReaistrationNo == parm.IpiReaistrationNo);


            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.OrderedDoctorId), it => it.OrderedDoctorId == parm.OrderedDoctorId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.OrderedDeptId), it => it.OrderedDeptId == parm.OrderedDeptId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.PatientNumber), it => it.PatientNumber == parm.PatientNumber);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.FymxId), it => it.FymxId == parm.FymxId);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TypeCode), it => it.TypeCode == parm.TypeCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BillNum), it => it.BillNum == parm.BillNum);
            return predicate;
        }
    }
}