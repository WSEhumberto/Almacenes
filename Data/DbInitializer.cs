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
                new Movimiento{MovDate = DateOnly.FromDateTime(DateTime.Today).AddDays(1), MovAlmId = 1, MovMatId = 1, MovQuantity = 10m, MovUnitPrice = 0.15m, Estantes = Movimiento.EstantesEnum.A, Niveles = Movimiento.NivelesEnum.N0, Cajas = Movimiento.BoxEnum.B0, MovType = Movimiento.MovTypeEnum.Entrada },
                new Movimiento{MovDate = DateOnly.FromDateTime(DateTime.Today).AddDays(2), MovAlmId = 1, MovMatId = 2, MovQuantity = 15m, MovUnitPrice = 1.15m, Estantes = Movimiento.EstantesEnum.B, Niveles = Movimiento.NivelesEnum.N1, Cajas = Movimiento.BoxEnum.B3, MovType = Movimiento.MovTypeEnum.Entrada}, 
                new Movimiento{MovDate = DateOnly.FromDateTime(DateTime.Today).AddDays(3), MovAlmId = 2, MovMatId = 1, MovQuantity = -5m, MovUnitPrice = 0.15m, Estantes = Movimiento.EstantesEnum.C, Niveles = Movimiento.NivelesEnum.N2, Cajas = Movimiento.BoxEnum.B8, MovType = Movimiento.MovTypeEnum.Salida },
                new Movimiento{MovDate = DateOnly.FromDateTime(DateTime.Today).AddDays(4), MovAlmId = 2, MovMatId = 2, MovQuantity = 7m, MovUnitPrice = 1.15m, Estantes = Movimiento.EstantesEnum.E, Niveles = Movimiento.NivelesEnum.N6, Cajas = Movimiento.BoxEnum.B6, MovType = Movimiento.MovTypeEnum.Entrada},
                new Movimiento{MovDate = DateOnly.FromDateTime(DateTime.Today).AddDays(5), MovAlmId = 1, MovMatId = 1, MovQuantity = 9m, MovUnitPrice = 0.15m, Estantes = Movimiento.EstantesEnum.A, Niveles = Movimiento.NivelesEnum.N5, Cajas = Movimiento.BoxEnum.B6, MovType = Movimiento.MovTypeEnum.Entrada},
                new Movimiento{MovDate = DateOnly.FromDateTime(DateTime.Today).AddDays(6), MovAlmId = 1, MovMatId = 2, MovQuantity = -1m, MovUnitPrice = 1.15m, Estantes = Movimiento.EstantesEnum.G, Niveles = Movimiento.NivelesEnum.N4, Cajas = Movimiento.BoxEnum.B1, MovType = Movimiento.MovTypeEnum.Salida},
                new Movimiento{MovDate = DateOnly.FromDateTime(DateTime.Today).AddDays(7), MovAlmId = 2, MovMatId = 1, MovQuantity = 13m, MovUnitPrice = 0.15m, Estantes = Movimiento.EstantesEnum.K, Niveles = Movimiento.NivelesEnum.N6, Cajas = Movimiento.BoxEnum.B1, MovType = Movimiento.MovTypeEnum.Entrada},
                new Movimiento{MovDate = DateOnly.FromDateTime(DateTime.Today).AddDays(8), MovAlmId = 2, MovMatId = 2, MovQuantity = 15m, MovUnitPrice = 1.15m, Estantes = Movimiento.EstantesEnum.L, Niveles = Movimiento.NivelesEnum.N0, Cajas = Movimiento.BoxEnum.B2, MovType = Movimiento.MovTypeEnum.Entrada}
            };

            context.Movimientos.AddRange(movimientos);
            context.SaveChanges();


        }
    }
}
