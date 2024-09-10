using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 溯源信息查询对象
    /// </summary>
    public class ChesViewQueryDto : PagerInfo
    {
        public int? Receiptid { get; set; }
        public int? DrugId { get; set; }
        public string Code { get; set; }
        public string RefEntId { get; set; }
        public string EntName { get; set; }
    }

    /// <summary>
    /// 溯源信息输入输出对象
    /// </summary>
    public class ChesViewDto
    {

        //[Required(ErrorMessage = "入库单id不能为空")]
        //public int ReceiptId { get; set; }

        public string ReceiptCode { get; set; }

        public string StorageTime { get; set; }

        public string CreationTime { get; set; }

        public string Creator { get; set; }

        public string ChangeTime { get; set; }

        public string ModifiedBy { get; set; }

        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        public int? Receiptid { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public int? DrugId { get; set; }

        [ExcelColumn(Name = "追溯码")]
        [ExcelColumnName("追溯码")]
        public string Code { get; set; }

        [ExcelColumn(Name = "药品类型描述")]
        [ExcelColumnName("药品类型描述")]
        public string PhysicTypeDesc { get; set; }

        [ExcelColumn(Name = "企业id")]
        [ExcelColumnName("企业id")]
        public string RefEntId { get; set; }

        [ExcelColumn(Name = "企业名称")]
        [ExcelColumnName("企业名称")]
        public string EntName { get; set; }

        [ExcelColumn(Name = "码等级")]
        [ExcelColumnName("码等级")]
        public string PackageLevel { get; set; }

        [ExcelColumn(Name = "有效期")]
        [ExcelColumnName("有效期")]
        public string PhysicName { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public string Exprie { get; set; }

        [ExcelColumn(Name = "批准文号")]
        [ExcelColumnName("批准文号")]
        public string DrugEntBaseInfoId { get; set; }

        [ExcelColumn(Name = "包装规格")]
        [ExcelColumnName("包装规格")]
        public string ApprovalLicenceNo { get; set; }

        [ExcelColumn(Name = "制剂规格")]
        [ExcelColumnName("制剂规格")]
        public string PkgSpecCrit { get; set; }

        [ExcelColumn(Name = "剂型描述")]
        [ExcelColumnName("剂型描述")]
        public string PrepnSpec { get; set; }

        [ExcelColumn(Name = "生产日期")]
        [ExcelColumnName("生产日期")]
        public string PrepnTypeDesc { get; set; }

        [ExcelColumn(Name = "剂型描述")]
        [ExcelColumnName("剂型描述")]
        public string ProduceDateStr { get; set; }

        [ExcelColumn(Name = "最小包装数量")]
        [ExcelColumnName("最小包装数量")]
        public string PkgAmount { get; set; }

        [ExcelColumn(Name = "有效期至")]
        [ExcelColumnName("有效期至")]
        public string ExpireDate { get; set; }

        [ExcelColumn(Name = "批次号")]
        [ExcelColumnName("批次号")]
        public string BatchNo { get; set; }

        public string DRUG_NAME { get; set; }
        public string DRUG_CODE { get; set; }

              /// <summary>
        /// 药品编码 
        /// </summary>
        public string DrugCode { get; set; }

        /// <summary>
        /// 药品溯源码 
        /// </summary>
        public string TracingSourceCode { get; set; }

        /// <summary>
        /// 药品批号 
        /// </summary>
        public string BatchNumber { get; set; }

        /// <summary>
        /// 药品入库数量 
        /// </summary>
        public string InventoryQuantity { get; set; }

        /// <summary>
        /// 药品规格 
        /// </summary>
        public string DrugSpecifications { get; set; }

        public string State { get; set; }

        public int? SupplierId { get; set; }
        public string dcode { get; set; }
        public int? InWarehouseId { get; set; }

    }
}
