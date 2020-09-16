using challange1tomany.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challange1tomany.DAL
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

        public DbSet<CourseModel> Course { get; set; }
        public DbSet<TestModel> Test { get; set; }
    }
}
