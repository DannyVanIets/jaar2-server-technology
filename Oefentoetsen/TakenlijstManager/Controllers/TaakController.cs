using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TakenlijstManager.DAL;
using TakenlijstManager.Models;

namespace TakenlijstManager.Controllers
{
    public class TaakController : Controller
    {
        private readonly TaakContext _context;

        public TaakController(TaakContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.AlleTakenCount = _context.Taak.ToList().Count;
            return View(await _context.Taak.Include(t => t.TaakStatus).ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Taak taak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taak);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(taak);
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Details(int id)
        {
            var taak = _context.Taak.Find(id);
            if (taak == null)
            {
                return NotFound();
            }
            return View(taak);
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taak = _context.Taak.Find(id);
            if (taak == null)
            {
                return NotFound();
            }
            return View(taak);
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Taak taak)
        {
            if (ModelState.IsValid)
            {
                _context.Update(taak);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(taak);
        }

        public IActionResult Delete(int id)
        {
            var taak = _context.Taak.FirstOrDefault(m => m.TaakId == id);
            if (taak == null)
            {
                return NotFound();
            }
            return View(taak);
        }

        [HttpPost, ActionName("Delete")] //Kan maar een methode met de naam Delete hebben en dezelfde signatuur
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var spelerModel = _context.Taak.Find(id);
            _context.Taak.Remove(spelerModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
