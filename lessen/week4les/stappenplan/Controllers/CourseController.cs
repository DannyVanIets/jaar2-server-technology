using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stappenplan.DAL;
using stappenplan.Models;

namespace stappenplanCourse.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseContext _context;

        public CourseController(CourseContext context) => _context = context;

        [HttpGet]
        public IActionResult Index() => View(_context.Course.ToList());

        [HttpPost]
        public IActionResult Index(string searchString, string SortOrder)
        {
            ViewData["SearchString"] = searchString;
            ViewData["SortOrder"] = String.IsNullOrEmpty(SortOrder) ? "" : "name_desc";
            IQueryable<CourseModel> courses = from c in _context.Course select c; //Kan beter in list en method syntax.
            
            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(c => c.CourseName.Contains(searchString));
            }

            switch (SortOrder)
            {
                case "name_desc":
                    courses = courses.OrderByDescending(c => c.CourseName);
                    break;
                default:
                    courses = courses.OrderBy(c => c.CourseName);
                    break;
            }

            return View(courses.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(courseModel);
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var courseModel = _context.Course.Find(id);
            if (courseModel == null)
            {
                return NotFound();
            }
            return View(courseModel);
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(courseModel);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(courseModel);
        }

        public IActionResult Delete(int id)
        {
            var courseModel = _context.Course.FirstOrDefault(m => m.CourseId == id);
            if (courseModel == null)
            {
                return NotFound();
            }
            return View(courseModel);
        }

        [HttpPost, ActionName("Delete")] //Kan maar een methode met de naam Delete hebben en dezelfde signatuur
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var courseModel = _context.Course.Find(id);
            _context.Course.Remove(courseModel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}