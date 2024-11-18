using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Model.His
{
    [Tenant(1)]
    [SugarTable("xthis_nhqdwrmyy.V_XYXT_DRM_SUPPLIER")]
    public class HisSupplier
    {
        public string ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string SOCIAL_CREDIT_CODE { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }

    }
}
