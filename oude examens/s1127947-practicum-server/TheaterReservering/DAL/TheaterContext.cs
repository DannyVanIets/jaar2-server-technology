using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheaterReservering.Models;

namespace TheaterReservering.DAL
{
    public class TheaterContext : DbContext
    {
        public TheaterContext(DbContextOptions<TheaterContext> options) : base(options) { }

        public DbSet<KlantModel> Klant { get; set; }
        public DbSet<ReserveringModel> Reservering { get; set; }
    }
}
