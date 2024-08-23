using Almacenes.Data;

namespace Almacenes.Interfaces
{
    public interface IMaterialBalance
    {
        public decimal Balance(AlmacenesContext context,  int i);

        public decimal Balance(AlmacenesContext context, int i, int v);
    }

}
