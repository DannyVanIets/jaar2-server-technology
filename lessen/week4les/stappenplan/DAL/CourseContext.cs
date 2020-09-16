using Microsoft.EntityFrameworkCore;
using stappenplan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stappenplan.DAL
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

        public DbSet<CourseModel> Course { get; set; }
    }
}
