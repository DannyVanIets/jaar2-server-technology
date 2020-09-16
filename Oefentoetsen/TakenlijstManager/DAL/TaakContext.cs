using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakenlijstManager.Models;

namespace TakenlijstManager.DAL
{
    public class TaakContext : DbContext
    {
        public TaakContext(DbContextOptions<TaakContext> options) : base(options) { }

        public DbSet<Taak> Taak { get; set; }
        public DbSet<Status> Status { get; set; }
    }
}
