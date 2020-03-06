using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class PositionsController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Position Position { get; set; }
        public PositionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Position = new Position();
            if (id == null)
            {
                //create
                return View(Position);
            }
            //update
            Position = _db.Positions.FirstOrDefault(u => u.Id == id);
            if (Position == null)
            {
                return NotFound();
            }
            return View(Position);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert()
        {
            if (ModelState.IsValid)
            {
                if (Position.Id == 0)
                {
                    //create
                    _db.Positions.Add(Position);
                }
                else
                {
                    _db.Positions.Update(Position);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Position);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Positions.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var positionFromDb = await _db.Positions.FirstOrDefaultAsync(u => u.Id == id);
            if (positionFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Positions.Remove(positionFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}