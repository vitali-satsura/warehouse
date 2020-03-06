using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class StoragesController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Storage Storage { get; set; }
        public StoragesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Storage = new Storage();
            if (id == null)
            {
                //create
                return View(Storage);
            }
            //update
            Storage = _db.Storages.FirstOrDefault(u => u.Id == id);
            if (Storage == null)
            {
                return NotFound();
            }
            return View(Storage);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Storage.Id == 0)
                {
                    //create
                    _db.Storages.Add(Storage);
                }
                else
                {
                    _db.Storages.Update(Storage);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Storage);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Storages.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var storageFromDb = await _db.Storages.FirstOrDefaultAsync(u => u.Id == id);
            if (storageFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Storages.Remove(storageFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}