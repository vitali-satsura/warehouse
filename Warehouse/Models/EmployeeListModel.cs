using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class EmployeeListModel
    {
        public IEnumerable<EmployeesModel> Assets { get; set; }
    }
}
