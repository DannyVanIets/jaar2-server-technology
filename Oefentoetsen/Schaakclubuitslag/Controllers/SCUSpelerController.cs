using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schaakclubuitslag.DAL;
using Schaakclubuitslag.Models;

namespace Schaakclubuitslag.Controllers
{
    public class SCUSpelerController : Controller
    {
        private readonly SCUSpelerContext _context;

        public SCUSpelerController(SCUSpelerContext context) => _context = context;

        [HttpGet]
        public IActionResult Index() => View(_context.SCUSpeler.ToList());

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SCUSpelerModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult CreatePartij(int id)
        {
            var SCUSpeler = _context.SCUSpeler.Find(id);
            if (SCUSpeler == null) return NotFound();
            var partij = new PartijModel();
            partij.SCUSpeler = SCUSpeler;
            partij.SCUSpelerId = SCUSpeler.SCUSpelerId;
            return View(partij);
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePartij([Bind("PartijId,Dag,Uitslag,SCUSpelerId")] PartijModel partij)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partij);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "SCUSpeler");
            }
            return View(partij);
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _context.SCUSpeler.Find(id);
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
            var model = _context.SCUSpeler.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SCUSpelerModel model)
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
            var model = _context.SCUSpeler.FirstOrDefault(m => m.SCUSpelerId == id);
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
            var model = _context.SCUSpeler.Find(id);
            _context.SCUSpeler.Remove(model);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}