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
    }
}
