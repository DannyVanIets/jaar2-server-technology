using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheaterReservering.DAL;
using TheaterReservering.Models;

namespace TheaterReservering.Controllers
{
    public class KlantController : Controller
    {
        private readonly TheaterContext _context;

        public KlantController(TheaterContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var klanten = _context.Klant.Include(k => k.Reservingen).ToList().OrderBy(k => k.Naam);

            foreach (KlantModel k in klanten)
            {
                foreach (var r in k.Reservingen)
                {
                    k.Prijs = await APICaller.CallBerekenPrijsAsync(k.KlantId);
                }
            }
            return View(klanten);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KlantModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _context.Klant.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _context.Klant.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KlantModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = _context.Klant.FirstOrDefault(m => m.KlantId == id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")] //Kan maar een methode met de naam Delete hebben en dezelfde signatuur
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var model = _context.Klant.Find(id);
            _context.Klant.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}