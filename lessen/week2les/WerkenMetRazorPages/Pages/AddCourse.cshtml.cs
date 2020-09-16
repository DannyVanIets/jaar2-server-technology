using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WerkenMetRazorPages.Model;

namespace WerkenMetRazorPages
{
    public class AddCourseModel : PageModel
    {
        private ICourseService service;
        [BindProperty]
        public Course Course { get; set; }

        public AddCourseModel(ICourseService service)
        {
            this.service = service;
        }

        public void OnGet()
        {
            Course = new Course();
        }

        public IActionResult OnPost()
        {
            service.AddCourse(Course);
            return RedirectToPage("./ShowCourseService");
        }
    }
}