using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Supplier Supplier { get; set; }
        public SuppliersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Supplier = new Supplier();
            if (id == null)
            {
                //create
                return View(Supplier);
            }
            //update
            Supplier = _db.Suppliers.FirstOrDefault(u => u.Id == id);
            if (Supplier == null)
            {
                return NotFound();
            }
            return View(Supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Supplier.Id == 0)
                {
                    //create
                    _db.Suppliers.Add(Supplier);
                }
                else
                {
                    _db.Suppliers.Update(Supplier);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Supplier);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Suppliers.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var supplierFromDb = await _db.Suppliers.FirstOrDefaultAsync(u => u.Id == id);
            if (supplierFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Suppliers.Remove(supplierFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}