using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WerkenMetRazorPages.Model
{
    public class CourseService : ICourseService
    {
        string ConnetionString = @"Data source=(localdb)\MSSQLLocalDB; Initial Catalog=CourseDatabase; Integrated Security=True";

        private List<Course> courses;

        public CourseService()
        {
            courses = new List<Course>();
            /*courses.Add(new Course(1, "DW", "Discrete Wiskunde"));
            courses.Add(new Course(2, "C#", "C-sharp"));
            courses.Add(new Course(3, "ISEC", "Inleiding security"));*/
        }

        public Course GetCourse(int id)
        {
            return courses.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Course> GetCourses()
        {
            courses.Clear();
            string sqlQuery = "SELECT Id, Code, Name FROM Course";
            using (SqlConnection sqlCon = new SqlConnection(ConnetionString))
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand(sqlQuery, sqlCon);
                SqlDataReader rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    var course = new Course();
                    course.Id = Convert.ToInt32(rdr["Id"]);
                    course.Code = rdr["Code"].ToString();
                    course.Name = rdr["Name"].ToString();
                    courses.Add(course);
                }

                sqlCon.Close();
            }
            return courses.ToList();
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public bool UpdateCourse(Course course)
        {
            string query = "UPDATE Course SET Code=@Code, Name=@Name WHERE Id=@Id";

            var x = courses.Where(x => x.Id == course.Id).FirstOrDefault();
            if (x != null)
            {
                x.Name = course.Name;
                x.Code = course.Code;

                int result;

                using (SqlConnection sqlCon = new SqlConnection(ConnetionString))
                {
                    sqlCon.Open();

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@Code", x.Code);
                    sqlCmd.Parameters.AddWithValue("@Name", x.Name);
                    sqlCmd.Parameters.AddWithValue("@Id", x.Id);
                    result = sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                return result == 1;
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
