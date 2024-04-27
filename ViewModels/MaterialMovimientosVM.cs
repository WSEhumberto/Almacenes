using Almacenes.Models;

namespace Almacenes.ViewModels
{
    public class MaterialMovimientosVM
    {
        public int MatId { get; set; }
        public string MatName { get; set; }
        public string MatUM { get; set; }

        public int AlmId { get; set; }

        public decimal MatBalance { get; set; }

        public string AlmName { get; set; }

        public decimal AlmQ { get; set; }

        //IEnumerable<IGrouping<int, Movimiento>> NestedGroup {get; set;}
    }
}
