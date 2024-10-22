using Infrastructure.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZR.Model.Business.Dto;
using ZR.Model.Business;
using ZR.Service.Business.IBusinessService;

namespace ZR.Service.Business
{
    [AppService(ServiceType = typeof(ISourceTracingService), ServiceLifetime = LifeTime.Transient)]
    public class SourceTracingService : BaseService<SourceTracing>, ISourceTracingService
    {
        public List<SourceTracing> GetSources()
        {
            var response = Queryable()
                .ToList();
            return response;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SourceTracing GetInfo(int Id)
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
        public SourceTracing AddSourceTracing(SourceTracing model)
        {
            return Insertable(model).ExecuteReturnEntity();
        }
    }
}