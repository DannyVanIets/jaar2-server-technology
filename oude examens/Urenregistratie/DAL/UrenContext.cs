using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urenregistratie.Models;

namespace Urenregistratie.DAL
{
    public class UrenContext : DbContext
    {
        public UrenContext(DbContextOptions<UrenContext> options) : base(options) { }

        public DbSet<MedewerkerModel> Medewerker { get; set; }
        public DbSet<RegistratieModel> Registratie { get; set; }
    }
}
