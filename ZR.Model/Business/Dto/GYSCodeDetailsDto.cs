
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 送货单追溯码查询对象
    /// </summary>
    public class GYSCodeDetailsQueryDto : PagerInfo 
    {
        public int? Deliveryid { get; set; }
        public int? DrugId { get; set; }
        public string Code { get; set; }
        public string PhysicName { get; set; }
        public int? InDeliveryId { get; set; }
        public int? MedicalAdviceId { get; set; }
        public string InvoiceCode { get; set; }
        public string ParentCode { get; set; }
    }

    /// <summary>
    /// 送货单追溯码输入输出对象
    /// </summary>
    public class GYSCodeDetailsDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "送货单id")]
        [ExcelColumnName("送货单id")]
        public int? Deliveryid { get; set; }

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

        [ExcelColumn(Name = "药品名称")]
        [ExcelColumnName("药品名称")]
        public string PhysicName { get; set; }

        [ExcelColumn(Name = "有效期")]
        [ExcelColumnName("有效期")]
        public string Exprie { get; set; }

        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public string DrugEntBaseInfoId { get; set; }

        [ExcelColumn(Name = "批准文号")]
        [ExcelColumnName("批准文号")]
        public string ApprovalLicenceNo { get; set; }

        [ExcelColumn(Name = "包装规格")]
        [ExcelColumnName("包装规格")]
        public string PkgSpecCrit { get; set; }

        [ExcelColumn(Name = "制剂规格")]
        [ExcelColumnName("制剂规格")]
        public string PrepnSpec { get; set; }

        [ExcelColumn(Name = "剂型描述")]
        [ExcelColumnName("剂型描述")]
        public string PrepnTypeDesc { get; set; }

        [ExcelColumn(Name = "生产日期")]
        [ExcelColumnName("生产日期")]
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

        [ExcelColumn(Name = "扫码入库时间")]
        [ExcelColumnName("扫码入库时间")]
        public string StorageTime { get; set; }

        [ExcelColumn(Name = "送货药品")]
        [ExcelColumnName("送货药品")]
        public int? InDeliveryId { get; set; }

        [ExcelColumn(Name = "医嘱id")]
        [ExcelColumnName("医嘱id")]
        public int? MedicalAdviceId { get; set; }

        [ExcelColumn(Name = "发票号")]
        [ExcelColumnName("发票号")]
        public string InvoiceCode { get; set; }

        [ExcelColumn(Name = "父码")]
        [ExcelColumnName("父码")]
        public string ParentCode { get; set; }



    }
}