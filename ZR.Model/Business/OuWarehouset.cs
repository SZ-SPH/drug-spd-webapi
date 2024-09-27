namespace ZR.Model.Business
{
    /// <summary>
    /// 出库
    /// </summary>
    [SugarTable("OuWarehouset")]
    public class OuWarehouset
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public int Id { get; set; }

        /// <summary>
        /// 药品 
        /// </summary>
        public int? DrugId { get; set; }

        /// <summary>
        /// 出库房 
        /// </summary>
        public int? OutWarehouseID { get; set; }

        /// <summary>
        /// 入药房 
        /// </summary>
        public int? InpharmacyId { get; set; }

        /// <summary>
        /// 数量 
        /// </summary>
        public decimal Qty { get; set; }

        /// <summary>
        /// 申请计划 
        /// </summary>
        public int? PharmacyId { get; set; }
        /// <summary>
        /// 出库单
        /// </summary>
        public int? OutorderID { get; set; }
        /// <summary>
        /// 时间 
        /// </summary>
        public DateTime? Times { get; set; }

        /// <summary>
        /// 药品名称 
        /// </summary>
        public string Drugname { get; set; }

        /// <summary>
        /// 规格 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_SPECIFICATIONS")]
        public string DrugSpecifications { get; set; }

        /// <summary>
        /// 最小单位 
        /// </summary>
        public string Minunit { get; set; }

        /// <summary>
        /// 购入价 
        /// </summary>
        public decimal Buyprice { get; set; }

        /// <summary>
        /// 购入金额 
        /// </summary>
        public decimal Allbuyprice { get; set; }

        /// <summary>
        /// 零售价 
        /// </summary>
        public decimal RetailPrice { get; set; }

        /// <summary>
        /// 售价金额 
        /// </summary>
        public decimal AllRetailPrice { get; set; }

        /// <summary>
        /// 生产厂家 
        /// </summary>
        public string ManufacturerName { get; set; }

        /// <summary>
        /// 批号 
        /// </summary>
        [SugarColumn(ColumnName = "bATCH_NUMBER")]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 有效期 
        /// </summary>
        public string Exprie { get; set; }

        /// <summary>
        /// 货位号 
        /// </summary>
        public string LocationNumber { get; set; }

    }
}