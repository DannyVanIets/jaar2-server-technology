using Microsoft.EntityFrameworkCore;
using Server_wk4_les8_1_veel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_wk4_les8_1_veel.DAL
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

        public DbSet<Course> Course { get; set; }
        public DbSet<Test> Test { get; set; }
    }
}
