using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZR.Model.Business.Dto;
using ZR.Model.Business;

namespace ZR.Service.Business.IBusinessService
{
 public interface ISourceTracingService : IBaseService<SourceTracing>
    {    


        SourceTracing GetInfo(int Id);

        SourceTracing AddSourceTracing(SourceTracing parm);
        List<SourceTracing> GetSources();


    }
}
