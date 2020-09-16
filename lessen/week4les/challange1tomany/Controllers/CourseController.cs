using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challange1tomany.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace challange1tomany.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseContext _context;

        public CourseController(CourseContext context) => _context = context;

        [HttpGet]
        public IActionResult Index() => View(_context.Course.ToList());

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var course = _context.Course
                .Include(c => c.Tests)
                .FirstOrDefault(o => o.CourseId == id);

            if(course == null) 
            {
                return NotFound();
            }

            return View(course);
        }
    }
}