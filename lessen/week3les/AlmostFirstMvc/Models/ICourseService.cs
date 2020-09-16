using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WerkenMetRazorPages.Model
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        Course GetCourse(int id);
        void AddCourse(Course course);
        bool UpdateCourse(Course course);
        bool DeleteCourse(Course course);
    }
}
