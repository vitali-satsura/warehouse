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
            if (searchPos == null)
            {
                return RedirectToAction("Index");
            }

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

        public IActionResult GetProductByType(string type)
        {
            var searchType = _db.TypeOfProducts.FirstOrDefault(t => t.Name == type);
            if (searchType == null)
            {
                return RedirectToAction("Index");
            }

            var products = _db.Products.Where(p => p.TypeOfProductId == searchType.Id);            
            var listingResult = products
                .Select(a => new ProductsModel
                {
                    Manufacturer = a.Manufacturer,
                    Name = a.Name,
                    StorageConditions = a.StorageConditions,
                    Pack = a.Pack,
                    ExpirationDate = a.ExpirationDate,
                    ProductType = searchType.Name
                }).ToList();

            var model = new ProductListModel
            {
                Assets = listingResult
            };

            return View(model);
        }

        public IActionResult GetOrdersByDate(string startDateString, string endDateString)
        {
            DateTime startDate = DateTime.Parse(startDateString);
            DateTime endDate = DateTime.Parse(endDateString);
            var orders = _db.Storages.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate);

            int priceSum = 0;
            int count = 0;
            foreach (var order in orders)
            {
                priceSum += order.Price;
                count++;
            }

            double averagePrice = 0;
            if (count != 0)
            {
                averagePrice = priceSum / count;
            }
                        
            var listingResult = orders
                .Select(a => new OrdersModel
                {
                    Product = a.Product.Name,
                    OrderDate = a.OrderDate,
                    CustomerName = a.Customer.Name,
                    CustomerAddress = a.Customer.Address,
                    CustomerPhone = a.Customer.Phone,
                    DepartureDate = a.DepartureDate,
                    DeliveryMethod = a.DeliveryMethod,
                    Volume = a.Volume,
                    Price = a.Price
                }).ToList();

            var model = new OrdersListModel
            {
                Assets = listingResult,
                AveragePrice = averagePrice
            };

            return View(model);
        }       

    }
}
