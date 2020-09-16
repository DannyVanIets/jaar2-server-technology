using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WerkenMetRazorPages.Model
{
    public class CourseService : ICourseService
    {
        private List<Course> courses;

        public CourseService()
        {
            courses = new List<Course>();
            courses.Add(new Course(1, "DW", "Discrete Wiskunde"));
            courses.Add(new Course(2, "C#", "C-sharp"));
            courses.Add(new Course(3, "ISEC", "Inleiding security"));
        }

        public Course GetCourse(int id)
        {
            return courses.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Course> GetCourses()
        {
            return courses.ToList();
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public bool UpdateCourse(Course course)
        {
            var x = courses.Where(x => x.Id == course.Id).FirstOrDefault();
            if (x != null)
            {
                x.Name = course.Name;
                x.Code = course.Code;
                return true;
            }
            return false;
        }

        public bool DeleteCourse(Course course)
        {
            var x = courses.Where(x => x.Id == course.Id).FirstOrDefault();
            if (x != null)
            {
                courses.Remove(course);
                return true;
            }
            return false;
        }
    }
}
