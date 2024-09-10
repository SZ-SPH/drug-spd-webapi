using Infrastructure.Attribute;
using Infrastructure.Extensions;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Repository;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    /// <summary>
    /// 医嘱基础信息Service业务层处理
    /// </summary>
    [AppService(ServiceType = typeof(IMedicalAdviceService), ServiceLifetime = LifeTime.Transient)]
    public class MedicalAdviceService : BaseService<MedicalAdvice>, IMedicalAdviceService
    {
        /// <summary>
        /// 查询医嘱基础信息列表
        /// </summary>
        /// <param name="parm"></param>
        /// <returns></returns>
        public PagedInfo<MedicalAdviceDto> GetList(MedicalAdviceQueryDto parm)
        {
            var predicate = QueryExp(parm);

            var response = Queryable()
                .Where(predicate.ToExpression())
                .ToPage<MedicalAdvice, MedicalAdviceDto>(parm);

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
        /// 添加医嘱基础信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MedicalAdvice AddMedicalAdvice(MedicalAdvice model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }

        /// <summary>
        /// 修改医嘱基础信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateMedicalAdvice(MedicalAdvice model)
        {
            return Update(model, true);
        }

        /// <summary>
        /// 导出医嘱基础信息
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

            return predicate;
        }
    }
}