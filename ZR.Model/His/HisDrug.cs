namespace ZR.Model.His
{
    /// <summary>
    /// HIS药品基础资料管理
    /// </summary>
    [Tenant(1)]
    [SugarTable("xthis_nhqdwrmyy.V_XYXT_DRM_DICTIONARY")]
    public class HisDrug
    {
        public string iD
        {
            get; set;
        }

        public string drugs_code { get; set; }
        public string ZCZH { get; set; }


        public string drugs_name { get; set; }
        

        public string drugs_specs { get; set; }


        public string drugs_type { get; set; }

        public string unit { get; set; }

        public string package_unit { get; set; }


        public int package_ratio { get; set; }


        public string short_name { get; set; }


        public int drugs_flag { get; set; }


        public string produce_name { get; set; }

        public string PURCH_PRICE { get; set; }
        public string KFYX { get; set; }
        public string YFYX { get; set; }
    }
}