using Microsoft.EntityFrameworkCore;
using Schaakclubuitslag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schaakclubuitslag.DAL
{
    public class SCUSpelerContext : DbContext
    {
        public SCUSpelerContext(DbContextOptions<SCUSpelerContext> options) : base(options) { }

        public DbSet<SCUSpelerModel> SCUSpeler { get; set; }
        public DbSet<PartijModel> Partij { get; set; }
    }
}
