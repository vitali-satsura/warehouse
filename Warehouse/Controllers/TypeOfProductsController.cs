using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    public class TypeOfProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}