using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.His.Dto;
using ZR.Repository;
using ZR.Model.His;
using ZR.Service.His.IHisService;

namespace ZR.Service.His
{
    /// <summary>
    /// 药品基础资料管理Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IHisSupplierService), ServiceLifetime = LifeTime.Transient)]
    public class HisSupplierService : BaseService<HisSupplier>, IHisSupplierService
    {
        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<HisSupplierDto> GetList(HisSupplierQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<HisSupplier, HisSupplierDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public HisSupplier GetInfo(string code)
        {
            var response = Queryable()
                .Where(x => x.ID == code)
                .First();

            return response;
        }



        ///// <summary>
        ///// 查询导出表达式
        ///// </summary>
        ///// <param name="parm"></param>
        ///// <returns></returns>
        private static Expressionable<HisSupplier> QueryExp(HisSupplierQueryDto parm)
        {
            var predicate = Expressionable.Create<HisSupplier>();

            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisSupplierName), it => it.HisSupplierName.Contains(parm.HisSupplierName));
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisSupplierCode), it => it.HisSupplierCode == parm.HisSupplierCode);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisSupplierMnemonicCode), it => it.HisSupplierMnemonicCode.Contains(parm.HisSupplierMnemonicCode));
            return predicate;
        }
    }
}