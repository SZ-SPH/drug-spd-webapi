using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Model.Business
{
    public class ZsmItem
    {
        public string Zsm { get; set; }
    }

    public class RequestPayload
    {
        public string Fymx_Id { get; set; }
        public List<ZsmItem> Zsm_List { get; set; }
    }

    public class Med
    {
        public int Id { get; set; }

    }
}
