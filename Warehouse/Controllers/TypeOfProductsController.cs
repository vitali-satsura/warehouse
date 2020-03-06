using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class TypeOfProductsController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public TypeOfProduct TypeOfProduct { get; set; }
        public TypeOfProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            TypeOfProduct = new TypeOfProduct();
            if (id == null)
            {
                //create
                return View(TypeOfProduct);
            }
            //update
            TypeOfProduct = _db.TypeOfProducts.FirstOrDefault(u => u.Id == id);
            if (TypeOfProduct == null)
            {
                return NotFound();
            }
            return View(TypeOfProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (TypeOfProduct.Id == 0)
                {
                    //create
                    _db.TypeOfProducts.Add(TypeOfProduct);
                }
                else
                {
                    _db.TypeOfProducts.Update(TypeOfProduct);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(TypeOfProduct);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.TypeOfProducts.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var typeOfProductFromDb = await _db.TypeOfProducts.FirstOrDefaultAsync(u => u.Id == id);
            if (typeOfProductFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.TypeOfProducts.Remove(typeOfProductFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}