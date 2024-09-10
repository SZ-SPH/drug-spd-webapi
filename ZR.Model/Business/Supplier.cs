namespace ZR.Model.Business
{
    /// <summary>
    /// 供应商基础功能
    /// </summary>
    [SugarTable("SUPPLIER")]
    public class Supplier
    {
        /// <summary>
        /// id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 供应商名称 
        /// </summary>
        [SugarColumn(ColumnName = "sUPPLIER_NAME")]
        public string SupplierName { get; set; }

        /// <summary>
        /// 社会信用代码 
        /// </summary>
        [SugarColumn(ColumnName = "sOCIAL_CREDIT_CODE")]
        public string SocialCreditCode { get; set; }

        /// <summary>
        /// 企业地址 
        /// </summary>
        [SugarColumn(ColumnName = "eNTERPRISE_ADDRESS")]
        public string EnterpriseAddress { get; set; }

        /// <summary>
        /// 企业电话 
        /// </summary>
        [SugarColumn(ColumnName = "eNTERPRISE_PHONE")]
        public string EnterprisePhone { get; set; }

    }
}
