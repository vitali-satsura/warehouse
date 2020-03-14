using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class OrdersModel
    {
        public string Product { get; set; }        
        public DateTime OrderDate { get; set; }        
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }        
        public DateTime DepartureDate { get; set; }
        public string DeliveryMethod { get; set; }
        public string Volume { get; set; }
        public int Price { get; set; }        
    }
}
