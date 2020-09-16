using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Urenregistratie.DAL;
using Urenregistratie.Models;

namespace Urenregistratie.Controllers
{
    public class RegistratieController : Controller
    {
        private readonly UrenContext _context;

        public RegistratieController(UrenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() => View(_context.Registratie.Include(r => r.Medewerker).OrderBy(r => r.Medewerker).ThenBy(r => r.Week).ToList());

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MedewerkerId = new SelectList(_context.Medewerker, "MedewerkerId", "Achternaam");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistratieModel model)
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
            var model = _context.Registratie.Find(id);
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
            var model = _context.Registratie.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewBag.MedewerkerId = new SelectList(_context.Medewerker, "MedewerkerId", "Achternaam");
            return View(model);
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RegistratieModel model)
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
            var model = _context.Registratie.FirstOrDefault(r => r.RegistratieId == id);
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
            var model = _context.Registratie.Find(id);
            _context.Registratie.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult RegistreerUrenMedewerker(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medewerker = _context.Medewerker.FirstOrDefault(m => m.MedewerkerId == id);

            if (medewerker == null)
            {
                return NotFound();
            }

            var registratie = _context.Registratie.Include(r => r.Medewerker).Where(r => r.Week == 24).FirstOrDefault();

            ViewData["Medewerker"] = $"{medewerker.Voornaam}, {medewerker.Achternaam}";

            return View(registratie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegistreerUrenMedewerker(int id, RegistratieModel model)
        {
            if (ModelState.IsValid)
            {
                var reservering = _context.Registratie.Find(id);
                if (reservering != null)
                {
                    _context.Update(model);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Medewerker");
        }
    }
}