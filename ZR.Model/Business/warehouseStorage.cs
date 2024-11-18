using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Model.Business
{
    public class MedItem
    {
        public string Drug_Id { get; set; }
        public string Qty { get; set; }
        public string Batch_No { get; set; }
        public string Indate { get; set; }
        public string Prod_Date { get; set; }
        public string Manufacturer_Id { get; set; }
        public string Price { get; set; }
        public string Approval_No { get; set; }
        public string Drug_Trace_Code { get; set; }

    }

    public class WarehouseStorageRequest
    {
        public string Warehouse_Code { get; set; }
        public string Org_Id { get; set; }
        public string Supplier_Id { get; set; }
        public List<MedItem> Med_List { get; set; }
        public int ReceiptId { get; set; }

    }

    public class AllList
    {
        public int WarehouseId { get; set; }
        public string Warehousecode { get; set; }
        public string? org_id { get; set; }
        public List<int> ReceiptIds { get; set; }
    }

}
