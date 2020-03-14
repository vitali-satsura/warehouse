using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ProductsModel
    {
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string StorageConditions { get; set; }
        public string Pack { get; set; }        
        public DateTime ExpirationDate { get; set; }        
        public string ProductType { get; set; }
    }
}
