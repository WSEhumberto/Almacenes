using Almacenes.Data;
using Microsoft.EntityFrameworkCore;

namespace Almacenes.Interfaces
{
    public class MaterialBalance : IMaterialBalance
    {
        private readonly AlmacenesContext context1;
        public MaterialBalance(AlmacenesContext _context)
        {
            context1 = _context;
        }

        public decimal Balance(AlmacenesContext context1,  int i) 
        {
            //var balance = 0m;

            var balance =
                from b in context1.Movimientos.AsNoTracking().ToList()
                where b.MovMatId == i
                select b;

            decimal c = 0m;

            foreach (var mov in balance)
            {
                c += mov.MovQuantity;
            }
            return c;
        }

        public decimal Balance(AlmacenesContext context1, int i, int v )
        {
            var balance1 =
                context1.Movimientos
                    .Where(w => w.MovMatId == i && w.MovAlmId == v).AsNoTracking().ToList();
                    
            var b = 0m;
            foreach (var mov in balance1)
            {
                b += mov.MovQuantity;
            }
            return b;
        }



    }
}
