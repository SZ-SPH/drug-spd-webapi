using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Model.His
{
    [Tenant(1)]
    [SugarTable("xthis_nhqdwrmyy.V_XYXT_YZXX")]
    public class HisMedical
    {

        public string PH { get; set; }
        public string BR_ID { get; set; }
        public string BR_HM { get; set; }
        public string DRUG_ID { get; set; }
        public string ORDERED_DEPT_ID { get; set; }
        public string DEPARTMENT_CHINESE_NAME { get; set; }
        public string ORDERED_DOCTOR_ID { get; set; }
        public string EMPLOYEE_NAME { get; set; }
        public string FYMX_ID { get; set; }
        public string TYPE_CODE { get; set; }

        //public string br_id { get; set; }
        //public string br_hm { get; set; }
        //public string Drug_id { get; set; }
        //public string Total_qty { get; set; }
        //public string Ordered_dept_id { get; set; }
        //public string Department_chinese_name { get; set; }
        //public string Ordered_doctor_id { get; set; }
        //public string Employee_name { get; set; }
        //public string fymx_id { get; set; }
    }
}
