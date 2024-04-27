using Almacenes.Data;

namespace Almacenes.Interfaces
{
    public class MaterialBalance : IMaterialBalance
    {
        private AlmacenesContext context;
        public MaterialBalance(AlmacenesContext _context)
        {
            context = _context;
        }

        public decimal Balance(int i) {
            var balance = 0m;
            foreach (var mov in context.Movimientos.Where(w => w.MovMatId == i).ToList())
            {
                balance += mov.MovQuantity;
            }
            return balance;

        }

        public decimal Balance(int i, int v )
        {
            var balance = 0m;
            foreach (var mov in context.Movimientos.Where(w => w.MovMatId == i && w.MovAlmId == v).ToList())
            {
                balance += mov.MovQuantity;
            }
            return balance;

        }



    }
}
