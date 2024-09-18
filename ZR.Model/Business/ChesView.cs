
namespace ZR.Model.Business
{
    /// <summary>
    /// 溯源信息
    /// </summary>
    [SugarTable("V_DRUG_CodeDetails")]
    public class ChesView
    {
        /// <summary>
        /// 入库单id 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        //public int ReceiptId { get; set; }

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
        /// Id 
        /// </summary>
        [SugarColumn(ColumnName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// 入库单id 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        
        public int? Receiptid { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_ID")]
        public int? DrugId { get; set; }

        /// <summary>
        /// 追溯码 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 药品类型描述 
        /// </summary>
        [SugarColumn(ColumnName = "physic_Type_Desc")]
        public string PhysicTypeDesc { get; set; }

        /// <summary>
        /// 企业id 
        /// </summary>
        [SugarColumn(ColumnName = "ref_Ent_Id")]
        public string RefEntId { get; set; }

        /// <summary>
        /// 企业名称 
        /// </summary>
        [SugarColumn(ColumnName = "ent_Name")]
        public string EntName { get; set; }

        /// <summary>
        /// 码等级 
        /// </summary>
        [SugarColumn(ColumnName = "package_Level")]
        public string PackageLevel { get; set; }

        /// <summary>
        /// 	平台药品名称 
        /// </summary>
        [SugarColumn(ColumnName = "physic_Name")]
        public string PhysicName { get; set; }

        /// <summary>
        /// 有效期 
        /// </summary>
        public string Exprie { get; set; }

        /// <summary>
        /// 平台药品id 
        /// </summary>
        [SugarColumn(ColumnName = "drug_Ent_Base_Info_Id")]
        public string DrugEntBaseInfoId { get; set; }

        /// <summary>
        /// 	批准文号 
        /// </summary>
        [SugarColumn(ColumnName = "approval_Licence_No")]
        public string ApprovalLicenceNo { get; set; }

        /// <summary>
        /// 包装规格 
        /// </summary>
        [SugarColumn(ColumnName = "pkg_Spec_Crit")]
        public string PkgSpecCrit { get; set; }

        /// <summary>
        /// 制剂规格 
        /// </summary>
        [SugarColumn(ColumnName = "prepn_Spec")]
        public string PrepnSpec { get; set; }

        /// <summary>
        /// 	剂型描述 
        /// </summary>
        [SugarColumn(ColumnName = "prepn_Type_Desc")]
        public string PrepnTypeDesc { get; set; }

        /// <summary>
        /// 	生产日期 
        /// </summary>
        [SugarColumn(ColumnName = "produce_Date_Str")]
        public string ProduceDateStr { get; set; }

        /// <summary>
        /// 最小包装数量 
        /// </summary>
        [SugarColumn(ColumnName = "pkg_Amount")]
        public string PkgAmount { get; set; }

        /// <summary>
        /// 有效期至 
        /// </summary>
        [SugarColumn(ColumnName = "expire_Date")]
        public string ExpireDate { get; set; }

        /// <summary>
        /// 批次号 
        /// </summary>
        [SugarColumn(ColumnName = "batch_No")]
        public string BatchNo { get; set; }


        /// <summary>
        /// 药品名称 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_NAME")]
        public string DRUG_NAME { get; set; }


        /// <summary>
        /// 药品编码 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_CODE")]
        public string DrugCode { get; set; }

        /// <summary>
        /// 药品溯源码 
        /// </summary>
        [SugarColumn(ColumnName = "tRACING_SOURCE_CODE")]
        public string TracingSourceCode { get; set; }

        /// <summary>
        /// 药品批号 
        /// </summary>
        [SugarColumn(ColumnName = "bATCH_NUMBER")]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 药品入库数量 
        /// </summary>
        [SugarColumn(ColumnName = "iNVENTORY_QUANTITY")]
        public string InventoryQuantity { get; set; }

        /// <summary>
        /// 药品规格 
        /// </summary>
        [SugarColumn(ColumnName = "dRUG_SPECIFICATIONS")]
        public string DrugSpecifications { get; set; }

        public string State { get; set; }

        public int? SupplierId { get; set; }
        public string dcode { get; set; }
        public int? InWarehouseId { get; set; }
    }
}