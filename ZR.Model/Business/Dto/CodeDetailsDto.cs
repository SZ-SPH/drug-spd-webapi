
namespace ZR.Model.Business.Dto
{
    /// <summary>
    /// 码信息查询对象
    /// </summary>
    public class CodeDetailsQueryDto : PagerInfo 
    {
        public int? Receiptid { get; set; }
        public int? DrugId { get; set; }
        public string Code { get; set; }
        public string RefEntId { get; set; }
        public string EntName { get; set; }
        public int? InWarehouseId { get; set; }

        
    }

    /// <summary>
    /// 码信息输入输出对象
    /// </summary>
    public class CodeDetailsDto
    {
        [Required(ErrorMessage = "Id不能为空")]
        [ExcelColumn(Name = "Id")]
        [ExcelColumnName("Id")]
        public int Id { get; set; }

        [ExcelColumn(Name = "入库单id")]
        [ExcelColumnName("入库单id")]
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

        public int InWarehouseId { get; set; }
        
    }
}