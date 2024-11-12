using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using System.ComponentModel;
using ZR.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Topsdk.Top.Ability2940.Domain;
using Topsdk.Top.Ability2940.Response;
using Microsoft.Extensions.Logging;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

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

        public void PdaAddCodeDetails(CodeDetailsDto codeDetailsDto)
        {
            //溯源码
            string tracingCode = codeDetailsDto.Code;
            //根据溯源码获取下面的子码
            var codeList = Tools.CodeInOneWay(tracingCode);
            Dictionary<string, object> codeInfoDict = codeList[0];
            //回补药品的数量，批号和生产日期
            Context.Updateable<InWarehousing>().SetColumns(it => new InWarehousing
            {
                BatchNumber = codeInfoDict["batch_no"].ToString(),
                Exprie = codeInfoDict["exipre_date"].ToString(),
                DateOfManufacture = codeInfoDict["produce_date"].ToString(),
            })
                .Where(it => it.Id == codeDetailsDto.InWarehouseId)
                .ExecuteCommand();

            List<int> drugIdList = Context.Queryable<InWarehousing>().Where(it => it.Id == codeDetailsDto.InWarehouseId).Select(it => it.DrugId).ToList();

            var codeDetails = Tools.codedetail(tracingCode);

            string licenseNO = codeInfoDict["license_no"].ToString();
            string drugEntBaseId = codeInfoDict["drug_ent_base_id"].ToString();
            string entName = codeInfoDict["ent_name"].ToString();
            string refEntId = codeInfoDict["ref_ent_id"].ToString();
            string physicName = codeInfoDict["physic_name"].ToString();
            string physicTypeDesc = codeInfoDict["physic_type_desc"].ToString();
            string pkgSpecCrit = codeInfoDict["pkg_spec_crit"].ToString();
            string prepnSpec = codeInfoDict["prepn_spec"].ToString();
            string prepnTypeSpec = codeInfoDict["prepn_type_spec"].ToString();
            //大码中码
            if (codeInfoDict.ContainsKey("sub_code"))
            {
                //码的集合
                var list = (List<AlibabaAlihealthDrugtraceTopYljgQueryRelationCodeInfo>)codeInfoDict["sub_code"];
                var CodeDetailList = new List<CodeDetails>();
                list.ForEach((item) => 
                {
                    var CodeDetailItem = new CodeDetails() 
                    {
                        Receiptid = codeDetailsDto.Receiptid,
                        /// 追溯码 
                        Code = item.Code,
                        //药品ID
                        DrugId = drugIdList[0],
                        ///父码
                        ParentCode = item.ParentCode,
                        /// 药品类型描述 
                        PhysicTypeDesc = codeInfoDict["physic_type_desc"].ToString(),
                        /// 企业id 
                        RefEntId = codeInfoDict["ref_ent_id"].ToString(),
                        /// 企业名称 
                        EntName = codeInfoDict["ent_name"].ToString(),
                        /// 药品名称 
                        PhysicName = codeInfoDict["physic_name"].ToString(),
                        /// 有效期 
                        Exprie = codeInfoDict["expire"].ToString(),
                        /// 药品id
                        DrugEntBaseInfoId = codeInfoDict["drug_ent_base_id"].ToString(),
                        /// 批准文号
                        ApprovalLicenceNo = codeInfoDict["license_no"].ToString(),
                        /// 包装规格
                        PkgSpecCrit = codeInfoDict["pkg_spec_crit"].ToString(),
                        /// 剂型描述 
                        PrepnSpec = codeInfoDict["prepn_spec"].ToString(),
                        /// 生产日期 
                        PrepnTypeDesc = codeInfoDict["prepn_type_spec"].ToString(),
                        /// 剂型描述 
                        ProduceDateStr = codeInfoDict["produce_date"].ToString(),
                        /// 最小包装数量  
                        PkgAmount = codeInfoDict["pkg_amount"].ToString(),
                        /// 有效期至 
                        ExpireDate = codeInfoDict["exipre_date"].ToString(),
                        /// 批次号 
                        BatchNo = codeInfoDict["batch_no"].ToString(),
                        ///入库ID
                        InWarehouseId = codeDetailsDto.InWarehouseId,
                        PackageLevel = "1",
                        MedicalAdviceId = 0,
                    };
                    CodeDetailList.Add(CodeDetailItem);
                });
                Context.Insertable<CodeDetails>(CodeDetailList).ExecuteCommand();
            }
            else
            {
                var codeDetailFormat = new CodeDetails
                {

                    Receiptid = codeDetailsDto.Receiptid,
                    /// 追溯码 
                    Code = codeInfoDict["code"].ToString(),
                    //药品ID
                    DrugId = drugIdList[0],
                    /// 药品类型描述 
                    PhysicTypeDesc = codeInfoDict["physic_type_desc"].ToString(),
                    /// 企业id 
                    RefEntId = codeInfoDict["ref_ent_id"].ToString(),
                    /// 企业名称 
                    EntName = codeInfoDict["ent_name"].ToString(),
                    /// 药品名称 
                    PhysicName = codeInfoDict["physic_name"].ToString(),
                    /// 有效期 
                    Exprie = codeInfoDict["expire"].ToString(),
                    /// 药品id
                    DrugEntBaseInfoId = codeInfoDict["drug_ent_base_id"].ToString(),
                    /// 批准文号
                    ApprovalLicenceNo = codeInfoDict["license_no"].ToString(),
                    /// 包装规格
                    PkgSpecCrit = codeInfoDict["pkg_spec_crit"].ToString(),
                    /// 剂型描述 
                    PrepnSpec = codeInfoDict["prepn_spec"].ToString(),
                    /// 生产日期 
                    PrepnTypeDesc = codeInfoDict["prepn_type_spec"].ToString(),
                    /// 剂型描述 
                    ProduceDateStr = codeInfoDict["produce_date"].ToString(),
                    /// 最小包装数量  
                    PkgAmount = codeInfoDict["pkg_amount"].ToString(),
                    /// 有效期至 
                    ExpireDate = codeInfoDict["exipre_date"].ToString(),
                    /// 批次号 
                    BatchNo = codeInfoDict["batch_no"].ToString(),
                    //入库ID
                    InWarehouseId = codeDetailsDto.InWarehouseId,
                    MedicalAdviceId = 0,
                };
                Context.Insertable<CodeDetails>(codeDetailFormat).ExecuteCommand();
            }
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
                    InvoiceCode = it.InvoiceCode,
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