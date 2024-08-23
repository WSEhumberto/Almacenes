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
        public AlmacenesContext(DbContextOptions<AlmacenesContext> options)
            : base(options)
        {
        }

        public DbSet<Almacen> Almacenes { get; set; } = default!;
        public DbSet<Material> Materiales { get; set; } = default!;
        public DbSet<Movimiento> Movimientos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Almacen>().ToTable("Almacen");
        }
    }
}
