using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Model.Business
{

    /// <summary>
    /// 库存
    /// </summary>
    [SugarTable("SourceTracing")]
    public class SourceTracing
    {
        /// <summary>
        /// Id 
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string BillCode { get; set; }
        public string Codes { get; set; }
        [SugarColumn(ColumnName = "createTime", InsertServerTime = true)]
        public DateTime CreateTime { get; set; }

    }
}
