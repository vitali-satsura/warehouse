using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ProductInStorageListModel
    {
        public IEnumerable<ProductsInStorageModel> Assets { get; set; }
    }
}
