using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Responsibility { get; set; }
        public string Address { get; set; }
        public string Requirements { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
