using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Model.His
{

    [Tenant(1)]
    [SugarTable("xthis_nhqdwrmyy.V_XYXT_DRM_MANUFACTURER ")]
    public class HisManufacturer
    {
        //public string br_id { get; set; }
        //public string br_hm { get; set; }
        //public string Drug_id { get; set; }
        //public string Total_qty { get; set; }
        //public string Ordered_dept_id { get; set; }
        //public string Department_chinese_name { get; set; }
        //public string Ordered_doctor_id { get; set; }
        //public string Employee_name { get; set; }
        //public string fymx_id { get; set; }
        public string ID { get; set; }
        public string MANUFACTURER_NAME { get; set; }
        public string MANUFACTURER_CODE { get; set; }

    }

}
