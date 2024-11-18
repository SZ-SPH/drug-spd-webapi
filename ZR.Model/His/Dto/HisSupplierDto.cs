namespace ZR.Model.His.Dto
{
    /// <summary>
    /// 药品基础资料管理查询对象
    /// </summary>
    public class HisSupplierQueryDto : PagerInfo
    {

    }

    /// <summary>
    /// 药品基础资料管理输入输出对象
    /// </summary>
    public class HisSupplierDto
    {

        public string ID { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string SOCIAL_CREDIT_CODE { get; set; }
        public string ADDRESS { get; set; }
        public string PHONE { get; set; }
    }
}