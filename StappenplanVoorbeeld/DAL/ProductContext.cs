using Microsoft.EntityFrameworkCore;
using StappenplanVoorbeeld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StappenplanVoorbeeld.DAL
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<ProductModel> Product { get; set; }
    }
}
