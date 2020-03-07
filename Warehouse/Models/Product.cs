using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }        
        public string Manufacturer { get; set; }        
        public string Name { get; set; }
        public string StorageConditions { get; set; }
        public string Pack { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime ExpirationDate { get; set; }
        public int TypeOfProductId { get; set; }
        public TypeOfProduct TypeOfProduct { get; set; }
    }
}
