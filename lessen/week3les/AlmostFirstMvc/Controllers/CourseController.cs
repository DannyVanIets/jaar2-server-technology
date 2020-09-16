using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WerkenMetRazorPages.Model;

namespace AlmostFirstMvc.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService service;

        public CourseController(ICourseService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetCourses());
        }

        //Get variant, HttpGet is optioneel
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = service.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return View();
        }

        //Post variant
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Code, Name")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            service.UpdateCourse(course);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, [Bind("Id, Code, Name")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            service.AddCourse(course);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var course = service.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = service.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            service.DeleteCourse(course);
            return RedirectToAction(nameof(Index));
        }
    }
}