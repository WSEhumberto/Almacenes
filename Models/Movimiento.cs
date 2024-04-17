using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacenes.Models
{
    public class Movimiento
    {
        public int MovimientoId { get; set; }
        public DateOnly MovDate { get; set; }
        [ForeignKey("Almacen")]
        public int MovAlmId { get; set; }
        public Almacen Almacen { get; set; }

        [ForeignKey("Material")]
        public int MovMatId { get; set; }
        public Material Material { get; set; }

        public decimal MovQuantity { get; set; }

        public decimal MovUnitPrice { get; set; }



    }
    
}
