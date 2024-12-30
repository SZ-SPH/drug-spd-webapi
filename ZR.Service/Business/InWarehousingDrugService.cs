using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;
using Microsoft.AspNetCore.JsonPatch.Internal;

namespace ZR.Service.Business
{
    /// <summary>
    /// 入库信息Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IInWarehousingDrugService), ServiceLifetime = LifeTime.Transient)]
    public class InWarehousingDrugService : BaseService<InWarehousingDrug>, IInWarehousingDrugService
    {
        /// <summary>
        /// 查询入库信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InWarehousingDrugDto> GetList(InWarehousingDrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<InWarehousingDrug, InWarehousingDrugDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public InWarehousingDrug GetInfo(int Id)
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
        public InWarehousingDrug AddInWarehousingDrug(InWarehousingDrug model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改入库信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateInWarehousingDrug(InWarehousingDrug model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 导出入库信息
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<InWarehousingDrugDto> ExportList(InWarehousingDrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .Select((it) => new InWarehousingDrugDto()
                {
                }, true)
                .ToPage(parm);

            return response;
        }

        public int UpdatePdaInWarehousingDrug(InWarehousingDrugDto parm)
        {
            if ("药品入库数量".Equals(parm.Text))
            {
               int res = Context.Updateable<InWarehousing>()
                    .SetColumns(it => it.InventoryQuantity == int.Parse(parm.Content))
                    .Where(it => it.Id == parm.Id).ExecuteCommand();
                return res;
            }
            else if ("药品批号".Equals(parm.Text))
            {
                int res = Context.Updateable<InWarehousing>()
                    .SetColumns(it => it.BatchNumber == parm.Content)
                    .Where(it => it.Id == parm.Id).ExecuteCommand();
                return res;
            }
            else if ("有效期至".Equals(parm.Text))
            {
                int res = Context.Updateable<InWarehousing>()
                    .SetColumns(it => it.Exprie == parm.Content)
                    .Where(it => it.Id == parm.Id).ExecuteCommand();
                return res;
            }
            else if ("价格".Equals(parm.Text))
            {
                int res = Context.Updateable<InWarehousing>()
                    .SetColumns(it => it.Price == int.Parse(parm.Content))
                    .Where(it => it.Id == parm.Id).ExecuteCommand();
                return res;
            }
            else if ("货位号".Equals(parm.Text))
            {
                int res = Context.Updateable<InWarehousing>()
                    .SetColumns(it => it.LocationNumber == parm.Content)
                    .Where(it => it.Id == parm.Id).ExecuteCommand();
                return res;
            }
            else if ("生产日期".Equals(parm.Text))
            {
                int res = Context.Updateable<InWarehousing>()
                    .SetColumns(it => it.DateOfManufacture == parm.Content)
                    .Where(it => it.Id == parm.Id).ExecuteCommand();
                return res;
            }
            return -1;
        }




        /// <summary>
        /// 查询导出表达式
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        private static Expressionable<InWarehousingDrug> QueryExp(InWarehousingDrugQueryDto parm)
        {
            var predicate = Expressionable.Create<InWarehousingDrug>();

        // int? Receiptid { get; set; }
        // int? DRUGID { get; set; }
        //string DRUGCODE { get; set; }
        //string DRUGNAME { get; set; }

            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DrugName), it => it.DrugName.Contains(parm.DrugName));
            predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.DRUGCODE), it => it.DrugCode.Contains(parm.DRUGCODE));
            predicate = predicate.AndIF(parm.DRUGID != null, it => it.DrugId == parm.DRUGID);
            predicate = predicate.AndIF(parm.Receiptid != null, it => it.ReceiptId == parm.Receiptid);

            return predicate;
        }
    }
}