using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Product Product { get; set; }
        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Product = new Product();
            if (id == null)
            {
                //create
                return View(Product);
            }
            //update
            Product = _db.Products.FirstOrDefault(u => u.Id == id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Product.Id == 0)
                {
                    //create
                    _db.Products.Add(Product);
                }
                else
                {
                    _db.Products.Update(Product);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Products.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var productFromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (productFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Products.Remove(productFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}