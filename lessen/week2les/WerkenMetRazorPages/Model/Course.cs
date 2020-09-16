using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WerkenMetRazorPages.Model
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public Course(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }

        public Course()
        {

        }
    }
}
