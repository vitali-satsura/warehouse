using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetEmployeesByPosition(string posName)
        {
            var searchPos = _db.Positions.FirstOrDefault(position => position.Name == posName);
            var employes = _db.Employees.Where(employee => employee.PositionId == searchPos.Id);
            var listingResult = employes
                .Select(a => new EmployeesModel
                {
                    Name = a.Name,
                    Age = a.Age,
                    Gender = a.Gender,
                    Address = a.Address,
                    Phone = a.Phone,
                    PassportData = a.PassportData,
                    PositionName = searchPos.Name
                }).ToList();
            var model = new EmployeeListModel
            {
                Assets = listingResult
            };
            return View(model);
        }
    }
}
