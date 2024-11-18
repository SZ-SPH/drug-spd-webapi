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
    [AppService(ServiceType = typeof(IHisMedicalService), ServiceLifetime = LifeTime.Transient)]
    public class HisMedicalService : BaseService<HisMedical>, IHisMedicalService
    {
        /// <summary>
        /// 查询药品基础资料管理列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<HisMedicalDto> GetList(HisMedicalQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<HisMedical, HisMedicalDto>(parm);

            return response;
        }


        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public HisMedical GetInfo(string code)
        {
            var response = Queryable()
                .Where(x => x.FYMX_ID == code)
                .First();

            return response;
        }



        ///// <summary>
        ///// 查询导出表达式
        ///// </summary>
        ///// <param name="parm"></param>
        ///// <returns></returns>
        private static Expressionable<HisMedical> QueryExp(HisMedicalQueryDto parm)
        {
            var predicate = Expressionable.Create<HisMedical>();

            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisMedicalName), it => it.HisMedicalName.Contains(parm.HisMedicalName));
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisMedicalCode), it => it.HisMedicalCode == parm.HisMedicalCode);
            //predicate = predicate.AndIF(!string.IsNullOrEmpty(parm.HisMedicalMnemonicCode), it => it.HisMedicalMnemonicCode.Contains(parm.HisMedicalMnemonicCode));
            return predicate;
        }
    }
}