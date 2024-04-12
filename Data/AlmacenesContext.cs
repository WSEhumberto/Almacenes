using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Almacenes.Models;

namespace Almacenes.Data
{
    public class AlmacenesContext : DbContext
    {
        public AlmacenesContext (DbContextOptions<AlmacenesContext> options)
            : base(options)
        {
        }

        public DbSet<Almacenes.Models.Almacen> Almacenes { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>().ToTable("Almacen");
        }
    }
}
