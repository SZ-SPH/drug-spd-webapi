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
    [AppService(ServiceType = typeof(IHisDrugService), ServiceLifetime = LifeTime.Transient)]
    public class HisDrugService : BaseService<HisDrug>, IHisDrugService
    {
        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<HisDrugDto> GetList(HisDrugQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<HisDrug, HisDrugDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public HisDrug GetInfo(string code)
        {
            var response = Queryable()
                .Where(x => x.drugs_code == code)
                .First();

            return response;
        }



        ///// <summary>
        ///// 查询导出表达式
        ///// </summary>
        ///// <param name="parm"></param>
        ///// <returns></returns>
        private static Expressionable<HisDrug> QueryExp(HisDrugQueryDto parm)
        {
            var predicate = Expressionable.Create<HisDrug>();

            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisDrugName), it => it.HisDrugName.Contains(parm.HisDrugName));
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisDrugCode), it => it.HisDrugCode == parm.HisDrugCode);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisDrugMnemonicCode), it => it.HisDrugMnemonicCode.Contains(parm.HisDrugMnemonicCode));
            return predicate;
        }
    }
}