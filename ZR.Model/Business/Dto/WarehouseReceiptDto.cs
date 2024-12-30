namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 入库单查询对象
    /// </summary>
    public class WarehouseReceiptQueryDto : PagerInfo
    {
        public string ReceiptCode { get; set; }
        public string StorageTime { get; set; }
        public string CreationTime { get; set; }
        public string Creator { get; set; }
        public string ChangeTime { get; set; }
        public string ModifiedBy { get; set; }
        public string State { get; set; }
        public int? SupplierId { get; set; }

    }

    /// <summary>
    /// 入库单输入输出对象
    /// </summary>
    public class WarehouseReceiptDto
    {
        [Required(ErrorMessage = "入库单id不能为空")]
        [ExcelColumn(Name = "入库单id")]
        [ExcelColumnName("入库单id")]
        public int ReceiptId { get; set; }

        [ExcelColumn(Name = "入库单编号")]
        [ExcelColumnName("入库单编号")]
        public string ReceiptCode { get; set; }

        [ExcelColumn(Name = "入库时间")]
        [ExcelColumnName("入库时间")]
        public string StorageTime { get; set; }

        [ExcelColumn(Name = "创建时间")]
        [ExcelColumnName("创建时间")]
        public string CreationTime { get; set; }

        [ExcelColumn(Name = "创建人")]
        [ExcelColumnName("创建人")]
        public string Creator { get; set; }

        [ExcelColumn(Name = "修改时间")]
        [ExcelColumnName("修改时间")]
        public string ChangeTime { get; set; }

        [ExcelColumn(Name = "修改人")]
        [ExcelColumnName("修改人")]
        public string ModifiedBy { get; set; }

        [ExcelColumn(Name = "State")]
        [ExcelColumnName("State")]
        public string State { get; set; }

        public int? SupplierId { get; set; }

        /// <summary>
        /// 发票
        /// </summary>
        public string InvoiceNumber { get; set; }
        public string HisBuyCode { get; set; }
        public string Mark { get; set; }

        
    }
}