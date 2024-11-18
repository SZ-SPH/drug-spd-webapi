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
    [AppService(ServiceType = typeof(IHisManufacturerService), ServiceLifetime = LifeTime.Transient)]
    public class HisManufacturerService : BaseService<HisManufacturer>, IHisManufacturerService
    {
        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<HisManufacturerDto> GetList(HisManufacturerQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<HisManufacturer, HisManufacturerDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public HisManufacturer GetInfo(string code)
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
        private static Expressionable<HisManufacturer> QueryExp(HisManufacturerQueryDto parm)
        {
            var predicate = Expressionable.Create<HisManufacturer>();

            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisManufacturerName), it => it.HisManufacturerName.Contains(parm.HisManufacturerName));
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisManufacturerCode), it => it.HisManufacturerCode == parm.HisManufacturerCode);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisManufacturerMnemonicCode), it => it.HisManufacturerMnemonicCode.Contains(parm.HisManufacturerMnemonicCode));
            return predicate;
        }
    }
}