using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class OrdersListModel
    {
        public IEnumerable<OrdersModel> Assets { get; set; }
        public double AveragePrice { get; set; }
    }
}
