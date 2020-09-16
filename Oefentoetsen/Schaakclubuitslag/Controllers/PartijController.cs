using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schaakclubuitslag.DAL;
using Schaakclubuitslag.Models;

namespace Schaakclubuitslag.Controllers
{
    public class PartijController : Controller
    {
        private readonly SCUSpelerContext _context;

        public PartijController(SCUSpelerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Partij.ToList());
        }

        public IActionResult Create()
        {
            //Maakt niet uit of het ViewBag of ViewData bij deze is!
            ViewData["SCUSpelerId"] = new SelectList(_context.SCUSpeler, "SCUSpelerId", "Naam");
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PartijId,Dag,Uitslag,SCUSpelerId")] PartijModel partij)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partij);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(partij);
        }
    }
}