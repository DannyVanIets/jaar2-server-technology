using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WerkenMetRazorPages.Model;

namespace WerkenMetRazorPages
{
    public class ShowCourseServiceModel : PageModel
    {
        private ICourseService service;
        [BindProperty]
        public List<Course> Courses { get; set; }

        public ShowCourseServiceModel(ICourseService service)
        {
            this.service = service;
        }

        public void OnGet()
        {
            Courses = service.GetCourses();
        }
    }
}