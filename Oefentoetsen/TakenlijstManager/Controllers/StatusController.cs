using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TakenlijstManager.DAL;
using TakenlijstManager.Models;

namespace TakenlijstManager.Controllers
{
    public class StatusController : Controller
    {
        private readonly TaakContext _context;

        public StatusController(TaakContext context) => _context = context;

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Status.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(status);
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Details(int id)
        {
            var status = _context.Status.Find(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var status = _context.Status.Find(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Update(status);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(status);
        }

        public IActionResult Delete(int id)
        {
            var status = _context.Status.FirstOrDefault(m => m.StatusId == id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        [HttpPost, ActionName("Delete")] //Kan maar een methode met de naam Delete hebben en dezelfde signatuur
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var status = _context.Status.Find(id);
            _context.Status.Remove(status);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}