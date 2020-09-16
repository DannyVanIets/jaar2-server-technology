
using Server_wk4_les8_1_veel.DAL;
using Server_wk4_les8_1_veel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMetEF.DAL
{
    public static class SeedData
    {
        public static void Initialize(CourseContext context)
        {
            context.Database.EnsureCreated();

            AddCourse(context, "DW", "Discrete Wiskunde");
            AddCourse(context, "GP", "Games Programming");
            AddCourse(context, "ANA1", "Analyse 1");
            AddCourse(context, "ANA2", "Analyse 2");
            AddCourse(context, "C#", "C-sharp");
            AddCourse(context, "GESP", "Gesprekken in Organisaties");
            AddCourse(context, "WP", "Web programmeren");
            AddCourse(context, "PYT", "Python");
            AddCourse(context, "JAV", "Java programmeren");
            AddCourse(context, "ISEC", "Inleiding Security");
            context.SaveChanges();

            AddTest(context, "Practicum Games", "GP");
            AddTest(context, "Demo Game", "GP");
            AddTest(context, "Presenteren analyse", "ANA1");
            AddTest(context, "Schriftelijke toets", "ANA1");
            AddTest(context, "Schriftelijke toets", "ISEC");
            AddTest(context, "Practicum Python", "PYT");
            AddTest(context, "Practicum Java", "JAV");
            AddTest(context, "Practicum C#", "C#");
            AddTest(context, "Eindopdracht GESP", "GESP");
            AddTest(context, "Assessment WP", "WP");

            context.SaveChanges();
        }

        private static void AddCourse(CourseContext context, string code, string name)
        {   // we voegen alleen een course toe als het nog niet bestaat.
            Course course = context.Course.FirstOrDefault(c => c.Code.Equals(code) || c.Name.Equals(name));
            if (course == null) context.Course.Add(new Course { Code = code, Name = name });
        }

        private static void AddTest(CourseContext context, string name, string coursecode)
        {   // we voegen alleen een Toets toe als het nog niet bestaat.
            var course = context.Course.FirstOrDefault(c => c.Code.Equals(coursecode));
            if (course != null)
            {
                var test = context.Test.FirstOrDefault(t => t.Name.Equals(name) && t.CourseId == course.Id); 
                if (test == null) context.Test.Add(new Test { Name = name, CourseId = course.Id });
            }
        }
    }
}
