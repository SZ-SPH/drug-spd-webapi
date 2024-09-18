
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 送货单查询对象
    /// </summary>
    public class DeliveryOrderQueryDto : PagerInfo 
    {
        public string StockId { get; set; }
        public string DrugId { get; set; }
    }

    /// <summary>
    /// 送货单输入输出对象
    /// </summary>
    public class DeliveryOrderDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "备货单")]
        [ExcelColumnName("备货单")]
        public string StockId { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public string DrugId { get; set; }

        [ExcelColumn(Name = "送货药品")]
        [ExcelColumnName("送货药品")]
        public string DeliveryTime { get; set; }

        [ExcelColumn(Name = "单据详情")]
        [ExcelColumnName("单据详情")]
        public string DeliveryDetails { get; set; }

        [ExcelColumn(Name = "配送医院")]
        [ExcelColumnName("配送医院")]
        public string DeliveryHospital { get; set; }

        [ExcelColumn(Name = "配送地址")]
        [ExcelColumnName("配送地址")]
        public string DeliveryAddress { get; set; }

        [ExcelColumn(Name = "配送人")]
        [ExcelColumnName("配送人")]
        public string DeliveryPerson { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remarks { get; set; }

        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public string States { get; set; }

        [ExcelColumn(Name = "创建时间")]
        [ExcelColumnName("创建时间")]
        public string CreateTime { get; set; }



        [ExcelColumn(Name = "状态")]
        public string StatesLabel { get; set; }
    }
}