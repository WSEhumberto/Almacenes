using Almacenes.Models;
using Microsoft.SqlServer.Server;
using Microsoft.NET.StringTools;

namespace Almacenes.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AlmacenesContext context) {
            // Look for any students.
            if (context.Almacenes.Any())
            {
                return;   // DB has been seeded
            }

            var almacenes = new Almacen[]
            {
                new Almacen{AlmName = "La 106"},
                new Almacen{AlmName = "Rancho Grande"},
            };

            context.Almacenes.AddRange(almacenes);
            context.SaveChanges();

            var materiales = new Material[]
            {
                new Material{MatName = "PVC Bushing 3/4", MatUM = "ea" },
                new Material{MatName = "PVC Bushing 1", MatUM = "ea" }
            };

            context.Materiales.AddRange(materiales);
            context.SaveChanges();

            var movimientos = new Movimiento[]
            {
                new Movimiento{MovDate = DateOnly.MaxValue, MovAlmId = 1, MovMatId = 1, MovQuantity = 1m, MovUnitPrice = 0.15m},
                new Movimiento{MovDate = DateOnly.MaxValue, MovAlmId = 1, MovMatId = 2, MovQuantity = 3m, MovUnitPrice = 1.15m},
                new Movimiento{MovDate = DateOnly.MaxValue, MovAlmId = 2, MovMatId = 1, MovQuantity = 5m, MovUnitPrice = 0.15m},
                new Movimiento{MovDate = DateOnly.MaxValue, MovAlmId = 2, MovMatId = 2, MovQuantity = 7m, MovUnitPrice = 1.15m},
                new Movimiento{MovDate = DateOnly.MaxValue, MovAlmId = 1, MovMatId = 1, MovQuantity = 9m, MovUnitPrice = 0.15m},
                new Movimiento{MovDate = DateOnly.MaxValue, MovAlmId = 1, MovMatId = 2, MovQuantity = 11m, MovUnitPrice = 1.15m},
                new Movimiento{MovDate = DateOnly.MaxValue, MovAlmId = 2, MovMatId = 1, MovQuantity = 13m, MovUnitPrice = 0.15m},
                new Movimiento{MovDate = DateOnly.MaxValue, MovAlmId = 2, MovMatId = 2, MovQuantity = 15m, MovUnitPrice = 1.15m}
            };

            context.Movimientos.AddRange(movimientos);
            context.SaveChanges();


        }
    }
}
