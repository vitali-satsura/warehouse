using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ProductsInStorageModel
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }        
        public string StorageConditions { get; set; }
        public string Pack { get; set; }        
        public DateTime ExpirationDate { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierPhone { get; set; }
    }
}
