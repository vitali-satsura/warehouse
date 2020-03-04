using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }      
        public DateTime ReceiptDate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DeliveryMethod { get; set; }
        public string Volume { get; set; }
        public int Price { get; set; }
    }
}
