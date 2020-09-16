using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Urenregistratie.DAL;
using Urenregistratie.Models;

namespace Urenregistratie.Controllers
{
    public class MedewerkerController : Controller
    {
        private readonly UrenContext _context;

        public MedewerkerController(UrenContext context) => _context = context;

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.week = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            ViewBag.jaar = DateTime.Now.Year;
            var medewerkers = _context.Medewerker.Include(m => m.Registraties).ToList().OrderBy(m => m.Achternaam);
            ViewBag.language = Request.Headers["Accept-Language"];
            return View(medewerkers);
        }

        [HttpGet]
        public IActionResult Vorige(int id)
        {
            var medewerkers = _context.Medewerker.Include(m => m.Registraties).ToList().OrderBy(m => m.Achternaam);
            ViewBag.language = Request.Headers["Accept-Language"];
            if (id > 2 && id < 54)
            {
                ViewBag.week = id - 1;
            }
            else if (id <= 2)
            {
                ViewBag.week = 1;
            }
            else if (id > 53)
            {
                ViewBag.week = 52;
            }
            return View(medewerkers);
        }

        [HttpGet]
        public IActionResult Volgende(int id)
        {
            var medewerkers = _context.Medewerker.Include(m => m.Registraties).ToList().OrderBy(m => m.Achternaam);
            ViewBag.language = Request.Headers["Accept-Language"];
            if (id > 1 && id < 51)
            {
                ViewBag.week = id + 1;
            }
            else if(id <= 1)
            {
                ViewBag.week = 1;
            }
            else if (id >= 51)
            {
                ViewBag.week = 52;
            }
            return View(medewerkers);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedewerkerModel model)
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
            var model = _context.Medewerker.Find(id);
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
            var model = _context.Medewerker.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MedewerkerModel model)
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
            var model = _context.Medewerker.FirstOrDefault(m => m.MedewerkerId == id);
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
            var model = _context.Medewerker.Find(id);
            _context.Medewerker.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}