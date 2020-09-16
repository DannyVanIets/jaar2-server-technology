using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Schaakclubuitslag.Models;
using Schaakclubuitslag.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Schaakclubuitslag.Controllers
{
    public class HomeController : Controller
    {
        private readonly SCUSpelerContext _context;
        private const string sessionKey = "SchaakSessie";

        public HomeController(SCUSpelerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var stringOfDagen = new List<string>();
            foreach (string dag in Enum.GetNames(typeof(Dagen)))
            {
                stringOfDagen.Add(dag);
            }
            ViewBag.Dagen = stringOfDagen;

            List<int> spelers = GetSpelersFromSession();
            ViewBag.SpelersIds = spelers;

            return View(_context.SCUSpeler.Include(c => c.Partijen).ToList());
        }

        public List<int> GetSpelersFromSession()
        {
            var value = HttpContext.Session.GetString(sessionKey);
            var aangemaaktespelers = new List<int>();
            if (!string.IsNullOrEmpty(value))
            {
                aangemaaktespelers = JsonConvert.DeserializeObject<List<int>>(value);
            }
            return aangemaaktespelers;
        }

        public IActionResult Stop()
        {
            HttpContext.Session.Remove(sessionKey);
            return View();
        }

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
                AddSpelerToSession(model.SCUSpelerId);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public void AddSpelerToSession(int SCUSpelerId)
        {
            var value = HttpContext.Session.GetString(sessionKey);
            var aangemaaktespelers = new List<int>();
            if (string.IsNullOrEmpty(value))
            {
                aangemaaktespelers.Add(SCUSpelerId);
                HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(aangemaaktespelers));
            }
            else
            {
                aangemaaktespelers = JsonConvert.DeserializeObject<List<int>>(value);
                aangemaaktespelers.Add(SCUSpelerId);
                HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(aangemaaktespelers));
            }
        }

        public IActionResult CreatePartij(int id, Dagen dag)
        {
            var SCUSpeler = _context.SCUSpeler.Find(id);
            if (SCUSpeler == null) return NotFound();
            var partij = new PartijModel();
            partij.SCUSpeler = SCUSpeler;
            partij.Dag = dag;
            partij.SCUSpelerId = SCUSpeler.SCUSpelerId;
            return View(partij);
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePartij([Bind("Dag,Uitslag,SCUSpelerId")] PartijModel partij) //PartijId niet bij de bind zetten, anders kan het gaan verwarren met de andere ID
        {
            if (ModelState.IsValid)
            {
                _context.Add(partij);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(partij);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
