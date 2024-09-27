using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using ZR.Model.System;
using SqlSugar;

namespace ZR.Service.Business
{
    /// <summary>
    /// 入库信息Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IInWarehousingService), ServiceLifetime = LifeTime.Transient)]
    public class InWarehousingService : BaseService<InWarehousing>, IInWarehousingService
    {
        /// <summary>
        /// 查询入库信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InWarehousingDto> GetList(InWarehousingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<InWarehousing, InWarehousingDto>(parm);

            return response;
        }
        

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public InWarehousing GetInfo(int Id)
        {
            var response = Queryable()
                .Where(x => x.Id == Id)
                .First();

            return response;
        }

        /// <summary>
        /// 添加入库信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public InWarehousing AddInWarehousing(InWarehousing model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// pda添加入库信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public InWarehousing AddInWarehousingWithCondition(InWarehousing parm)
        {
            var inWarehousing = Queryable().Where(x => x.DrugCode == parm.DrugCode && x.ReceiptId==parm.ReceiptId).First();
            //不为空，说明已有该药品，则将药品数量加1
            if(inWarehousing != null)
            {
                parm = inWarehousing;
                parm.InventoryQuantity += 1;
                Update(parm, false);
                return parm;
            }
            return Insertable(parm).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改入库信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInWarehousing(InWarehousing model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 导出入库信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InWarehousingDto> ExportList(InWarehousingQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InWarehousingDto()
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
        private static Expressionable<InWarehousing> QueryExp(InWarehousingQueryDto parm)
        {
            var predicate = Expressionable.Create<InWarehousing>();

            predicate = predicate.AndIF(parm.DrugId != null, it => it.DrugId == parm.DrugId);

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugCode), it => it.DrugCode.Contains(parm.DrugCode));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.TracingSourceCode), it => it.TracingSourceCode == parm.TracingSourceCode);
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.BatchNumber), it => it.BatchNumber == parm.BatchNumber);
            predicate = predicate.AndIF(parm.ReceiptId != null, it => it.ReceiptId == parm.ReceiptId);
            return predicate;
        }

        public List<InWarehousing> inGetList(int Id)
        { 
                var response = Queryable()
                .Where(x => x.ReceiptId == Id).ToList();
                 return response;
        }

    }
}