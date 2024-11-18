using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Model.His
{
    [Tenant(1)]
    [SugarTable("xthis_nhqdwrmyy.V_XYXT_WAREHOUSE_DICT")]
    public class HisWarehouse
    {

        public string WAREHOUSE_CNAME { get; set; }
        public string WAREHOUSE_CODE { get; set; }

    }
}
