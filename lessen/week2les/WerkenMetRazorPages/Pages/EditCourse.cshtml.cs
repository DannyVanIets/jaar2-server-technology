using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WerkenMetRazorPages.Model;

namespace WerkenMetRazorPages
{
    public class EditCourseModel : PageModel
    {
        private ICourseService service;
        [BindProperty]
        public Course Course { get; set; }

        public EditCourseModel(ICourseService service)
        {
            this.service = service;
        }

        public IActionResult OnGet(int id)
        {
            Course = service.GetCourse(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            service.UpdateCourse(Course);
            return RedirectToPage("./ShowCourseService");
        }
    }
}