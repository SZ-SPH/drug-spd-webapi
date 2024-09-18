namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 备货单查询对象
    /// </summary>
    public class StockOrderQueryDto : PagerInfo
    {
        public int? ReceiptId { get; set; }
        public int? DrugId { get; set; }
        public int? DeliveryQuantity { get; set; }
        public string DeliveryHospital { get; set; }
        public string DeliveryAddress { get; set; } 
    }

    /// <summary>
    /// 备货单输入输出对象
    /// </summary>
    public class StockOrderDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "入库单id")]
        [ExcelColumnName("入库单id")]
        public int? ReceiptId { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public int? DrugId { get; set; }

        [ExcelColumn(Name = "配送数量")]
        [ExcelColumnName("配送数量")]
        public int? DeliveryQuantity { get; set; }

        [ExcelColumn(Name = "配送医院")]
        [ExcelColumnName("配送医院")]
        public string DeliveryHospital { get; set; }

        [ExcelColumn(Name = "配送地址")]
        [ExcelColumnName("配送地址")]
        public string DeliveryAddress { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remarks { get; set; }

        [ExcelColumn(Name = "配送时间")]
        [ExcelColumnName("配送时间")]
        public string DeliveryTime { get; set; }

        [ExcelColumn(Name = "配送人")]
        [ExcelColumnName("配送人")]
        public string DeliveryPerson { get; set; }



    }
}