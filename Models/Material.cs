using System.ComponentModel.DataAnnotations.Schema;
using Almacenes.Data;
using Almacenes.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Text;


namespace Almacenes.Models
{
    public class Material 
    {
        public int MaterialId { get; set; }
        public string MatName { get; set; }
        public string MatUM { get; set; }
        public List<Movimiento> Movimientos { get; set; } /*= new List<Movimiento>();*/


        //public Material(AlmacenesContext _context) { context = _context; }
        public decimal Existencia { get; set; }
        
        public void EntradaDeAlmacen(DateOnly date, int bodegaId, int materialId, decimal quantity, decimal price)
        {
            if(quantity <= 0 || price < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var entrada = new Movimiento()
                { MovDate = date, MovAlmId = bodegaId, MovMatId = materialId, MovQuantity = quantity, MovUnitPrice = price};

                Movimientos.Add(entrada);
            }
        }

        public void SalidaDeAlmacen(DateOnly date, int bodegaId, int materialId, decimal quantity)
        {
            if (quantity <= 0 )
            {
                throw new ArgumentOutOfRangeException();
            }
            else if(Existencia - quantity <0)
            {
                var salida = new Movimiento()
                { MovDate = date, MovAlmId = bodegaId, MovMatId = materialId, MovQuantity = -quantity };

                Movimientos.Add(salida);
            }
        }
    }
}
