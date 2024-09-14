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
    public class InWarehousingDrugQueryDto : PagerInfo
    {
        public int? Receiptid { get; set; }
        public int? DRUGID { get; set; }
        public string DRUGCODE { get; set; }
        public string DrugName { get; set; }
        //public string EntName { get; set; }
    }

    /// <summary>
    /// 溯源信息输入输出对象
    /// </summary>
    public class  InWarehousingDrugDto
    {

        /// <summary>
        /// id 
        /// </summary>
        [ExcelColumn(Name = "id")]
        [ExcelColumnName("id")]
        //[SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 药品id 
        /// </summary>
        [ExcelColumn(Name = "药品id")]
        [ExcelColumnName("药品id")]
        public int? DrugId { get; set; }

        /// <summary>
        /// 药品编码 
        /// </summary>
        [ExcelColumn(Name = "药品编码")]
        [ExcelColumnName("药品编码")]
        public string DrugCode { get; set; }

        /// <summary>
        /// 药品溯源码 
        /// </summary>
        [ExcelColumn(Name = "药品溯源码")]
        [ExcelColumnName("药品溯源码")]
        public string TracingSourceCode { get; set; }

        /// <summary>
        /// 药品批号 
        /// </summary>
        [ExcelColumn(Name = "药品批号")]
        [ExcelColumnName("药品批号")]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 药品入库数量 
        /// </summary>
        [ExcelColumn(Name = "药品入库数量")]
        [ExcelColumnName("药品入库数量")]
        public string InventoryQuantity { get; set; }

        /// <summary>
        /// 药品规格 
        /// </summary>
        [ExcelColumn(Name = "药品规格")]
        [ExcelColumnName("药品规格")]
        public string DrugSpecifications { get; set; }
        /// <summary>
        /// 入库单据id 
        /// </summary>
        [ExcelColumn(Name = "入库单据id")]
        [ExcelColumnName("入库单据id")]
        public int? ReceiptId { get; set; }

        /// <summary>
        /// 药品名称 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        [ExcelColumn(Name = "药品名称")]
        [ExcelColumnName("药品名称")]
        public string DrugName { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        [ExcelColumn(Name = "入库数量")]
        [ExcelColumnName("入库数量")]
        public int? CodeCount { get; set; }

        /// <summary>
        /// 生产厂家 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public int? ManufacturerId { get; set; }
        /// <summary>
        /// 有效期 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string Exprie { get; set; }
        /// <summary>
        /// 价格 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public decimal? Price { get; set; }
        /// <summary>
        /// 货位号 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string LocationNumber { get; set; }
        /// <summary>
        /// 生产日期 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string DateOfManufacture { get; set; }
        /// 最小单位 
        /// </summary>
        //[SugarColumn(ColumnName = "rECEIPT_ID")]
        public string Minunit { get; set; }

    }
}
