using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheaterReservering.DAL;
using TheaterReservering.Models;

namespace TheaterReservering.Controllers
{
    public class ReserveringController : Controller
    {
        private readonly TheaterContext _context;

        public ReserveringController(TheaterContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index() => View(_context.Reservering.Include(r => r.Klant).OrderBy(r => r.Naam).ToList());

        [HttpGet]
        public IActionResult Create() {
            ViewData["KlantId"] = new SelectList(_context.Klant, "KlantId", "Naam");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReserveringModel model)
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
            var model = _context.Reservering.Find(id);
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
            var model = _context.Reservering.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ReserveringModel model)
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
            var model = _context.Reservering.FirstOrDefault(m => m.ReserveringId == id);
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
            var model = _context.Reservering.Find(id);
            _context.Reservering.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        /*[HttpGet]
        public IActionResult EditWithKlantId(int id)
        {
            var klant = _context.Klant.Find(id);
            List<ReserveringModel> reserveringenA = _context.Reservering.OrderBy(r => r.Naam).Where(r => r.Naam.StartsWith("A")).ToList();
            List<ReserveringModel> reserveringenB = _context.Reservering.OrderBy(r => r.Naam).Where(r => r.Naam.StartsWith("B")).ToList();
            List<ReserveringModel> reserveringenC = _context.Reservering.OrderBy(r => r.Naam).Where(r => r.Naam.StartsWith("C")).ToList();
            List<ReserveringModel> reserveringenD = _context.Reservering.OrderBy(r => r.Naam).Where(r => r.Naam.StartsWith("D")).ToList();
            List<ReserveringModel> reserveringenE = _context.Reservering.OrderBy(r => r.Naam).Where(r => r.Naam.StartsWith("E")).ToList();
            if (klant == null || reserveringenA == null || reserveringenB == null || reserveringenC == null || reserveringenD == null || reserveringenE == null)
            {
                return NotFound();
            }
            return View(new KlantEnReserveringen { Klant = klant, ReserveringenA = reserveringenA, ReserveringenB = reserveringenB, ReserveringenC = reserveringenC, ReserveringenD = reserveringenD, ReserveringenE = reserveringenE, });
        }*/

        [HttpGet]
        public IActionResult EditWithKlantId(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = _context.Klant.FirstOrDefault(k => k.KlantId == id);

            if (klant == null)
            {
                return NotFound();
            }

            var reserveringen = _context.Reservering.Include(r => r.Klant).OrderBy(r => r.Naam);

            ViewData["Klant"] = $"{klant.Naam}, {klant.Email}, {klant.Woonplaats}";
            ViewData["KlantId"] = klant.KlantId;

            return View(reserveringen.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWithKlantId(int id, int[] reserveringsIds)
        {
            if (ModelState.IsValid)
            {
                // verwijder eerst alle reserveringen van klantid
                var reserveringen = _context.Reservering.Where(r => r.KlantId == id).ToList();
                foreach (var r in reserveringen)
                {
                    r.KlantId = null;
                    r.bezet = false;
                    _context.Update(r);
                    _context.SaveChanges();
                }

                // voeg nu de aangevinkte reserveringen toe
                foreach (int rid in reserveringsIds)
                {
                    var reservering = _context.Reservering.Find(rid);
                    if (reservering != null)
                    {
                        reservering.KlantId = id;
                        reservering.bezet = true;
                        _context.Update(reservering);
                        _context.SaveChanges();
                    }
                }
                return RedirectToAction(nameof(Index), "Klant");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}