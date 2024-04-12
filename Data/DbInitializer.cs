using Almacenes.Models;

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
                new Almacen{AlmName = "106"},
                new Almacen{AlmName = "Rancho Grande"},
            };

            context.Almacenes.AddRange(almacenes);
            context.SaveChanges();
        }
    }
}
