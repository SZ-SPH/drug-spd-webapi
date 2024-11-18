namespace ZR.Model.His.Dto
{
    /// <summary>
    /// 药品基础资料管理查询对象
    /// </summary>
    public class HisManufacturerQueryDto : PagerInfo
    {

    }

    /// <summary>
    /// 药品基础资料管理输入输出对象
    /// </summary>
    public class HisManufacturerDto
    {
        public string ID { get; set; }
        public string MANUFACTURER_NAME { get; set; }
        public string MANUFACTURER_CODE { get; set; }

    }
}