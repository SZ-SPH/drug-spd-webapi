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
    [AppService(ServiceType = typeof(IHisWarehouseService), ServiceLifetime = LifeTime.Transient)]
    public class HisWarehouseService : BaseService<HisWarehouse>, IHisWarehouseService
    {
        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<HisWarehouseDto> GetList(HisWarehouseQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<HisWarehouse, HisWarehouseDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public HisWarehouse GetInfo(string code)
        {
            var response = Queryable()
                .Where(x => x.WAREHOUSE_CODE == code)
                .First();

            return response;
        }



        ///// <summary>
        ///// 查询导出表达式
        ///// </summary>
        ///// <param name="parm"></param>
        ///// <returns></returns>
        private static Expressionable<HisWarehouse> QueryExp(HisWarehouseQueryDto parm)
        {
            var predicate = Expressionable.Create<HisWarehouse>();

            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisWarehouseName), it => it.HisWarehouseName.Contains(parm.HisWarehouseName));
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisWarehouseCode), it => it.HisWarehouseCode == parm.HisWarehouseCode);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisWarehouseMnemonicCode), it => it.HisWarehouseMnemonicCode.Contains(parm.HisWarehouseMnemonicCode));
            return predicate;
        }
    }
}