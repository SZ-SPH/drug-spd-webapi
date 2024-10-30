
namespace ZR.Model.Business
{
    /// <summary>
    /// 码信息
    /// </summary>
    [SugarTable("CodeDetails")]
    public class CodeDetails
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 入库单id 
        /// </summary>
        public int? Receiptid { get; set; }
        /// <summary>
        /// 医嘱
        /// </summary>
        public int? MedicalAdviceId { get; set; }
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
        /// 药品名称 
        /// </summary>
        [SugarColumn(ColumnName = "physic_Name")]
        public string PhysicName { get; set; }

        /// <summary>
        /// 有效期 
        /// </summary>
        public string Exprie { get; set; }

        /// <summary>
        /// 药品id
        /// </summary>
        [SugarColumn(ColumnName = "drug_Ent_Base_Info_Id")]
        public string DrugEntBaseInfoId { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        [SugarColumn(ColumnName = "approval_Licence_No")]
        public string ApprovalLicenceNo { get; set; }

        /// <summary>
        /// 包装规格
        /// </summary>
        [SugarColumn(ColumnName = "pkg_Spec_Crit")]
        public string PkgSpecCrit { get; set; }

        /// <summary>
        /// 剂型描述 
        /// </summary>
        [SugarColumn(ColumnName = "prepn_Spec")]
        public string PrepnSpec { get; set; }

        /// <summary>
        /// 生产日期 
        /// </summary>
        [SugarColumn(ColumnName = "prepn_Type_Desc")]
        public string PrepnTypeDesc { get; set; }

        /// <summary>
        /// 剂型描述 
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

        public int InWarehouseId { get; set; }

        /// <summary>
        /// 发票号 
        /// </summary>
        [SugarColumn(ColumnName = "invoiceCode")]
        public string InvoiceCode { get; set; }
    }
}