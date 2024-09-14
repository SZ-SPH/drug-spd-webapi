
namespace ZR.Model.Business
{
    /// <summary>
    /// 入库单
    /// </summary>
    [SugarTable("WarehouseReceipt")]
    public class WarehouseReceipt
    {
        /// <summary>
        /// 入库单id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "rECEIPT_ID")]
        public int ReceiptId { get; set; }

        /// <summary>
        /// 入库单编号 
        /// </summary>
        [SugarColumn(ColumnName = "rECEIPT_CODE")]
        public string ReceiptCode { get; set; }

        /// <summary>
        /// 入库时间 
        /// </summary>
        [SugarColumn(ColumnName = "sTORAGE_TIME")]
        public string StorageTime { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "cREATION_TIME")]
        public string CreationTime { get; set; }

        /// <summary>
        /// 创建人 
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 修改时间 
        /// </summary>
        [SugarColumn(ColumnName = "cHANGE_TIME")]
        public string ChangeTime { get; set; }

        /// <summary>
        /// 修改人 
        /// </summary>
        [SugarColumn(ColumnName = "mODIFIED_BY")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// State 
        /// </summary>
        public string State { get; set; }
        
        public int? SupplierId { get; set; }
       
        /// <summary>
        /// 发票
        /// </summary>
        public string InvoiceNumber { get; set; }
        
    }
}