namespace ZR.Model.His.Dto
{
    /// <summary>
    /// 药品基础资料管理查询对象
    /// </summary>
    public class HisWarehouseQueryDto : PagerInfo
    {

    }

    /// <summary>
    /// 药品基础资料管理输入输出对象
    /// </summary>
    public class HisWarehouseDto
    {


        public string WAREHOUSE_CNAME { get; set; }
        public string WAREHOUSE_CODE { get; set; }

    }
}