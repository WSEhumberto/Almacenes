using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Almacenes.Models
{
    public class Movimiento
    {
        public int MovimientoId { get; set; }
        public DateOnly MovDate { get; set; }
        [ForeignKey("Almacen")]
        public int MovAlmId { get; set; }
        public Almacen? Almacen { get; set; }

        [ForeignKey("Material")]
        public int MovMatId { get; set; }
        public Material? Material { get; set; }

        public decimal MovQuantity { get; set; }

        public decimal MovUnitPrice { get; set; }

        public EstantesEnum Estantes { get; set; }

        public MovTypeEnum MovType { get; set; }

        public enum EstantesEnum
        {
            [Display(Name = "Piso")]
            NoEstantes = 0,
            [Display(Name = "Estante A")] 
            A = 1,
            [Display(Name = "Estante B")]
            B = 2,
            [Display(Name = "Estante C")]
            C = 3,
            [Display(Name = "Estante D")]
            D = 4,
            [Display(Name = "Estante E")]
            E = 5,
            [Display(Name = "Estante F")]
            F  = 6,
            [Display(Name = "Estante G")]
            G   = 7,
            [Display(Name = "Estante H")]
            H   = 8,
            [Display(Name = "Estante I")]
            I = 9,
            [Display(Name = "Estante J")]
            J = 10,
            [Display(Name = "Estante K")]
            K = 11,
            [Display(Name = "Estante L")]
            L  = 12
        }

        public NivelesEnum Niveles { get; set; }
        public enum NivelesEnum
        {
            [Display(Name = "Nivel Zero")]
            N0 = 0,
            [Display(Name = "Nivel 1")]
            N1 = 1,
            [Display(Name = "Nivel 2")]
            N2 = 2,
            [Display(Name = "Nivel 3")]
            N3 = 3,
            [Display(Name = "Nivel 4")]
            N4 = 4,
            [Display(Name = "Nivel 5")]
            N5 = 5,
            [Display(Name = "Nivel 6")]
            N6 = 6,
        }

        public BoxEnum Cajas { get; set; }
        public enum BoxEnum 
        {
            [Display(Name = "Sin Caja")]
            B0 = 0,
            [Display(Name = "Caja 1")]
            B1 = 1,
            [Display(Name = "Caja 2")]
            B2 = 2,
            [Display(Name = "Caja 3")]
            B3 = 3,
            [Display(Name = "Caja 4")]
            B4 = 4,
            [Display(Name = "Caja 5")]
            B5 = 5,
            [Display(Name = "Caja 6")]
            B6 = 6,
            [Display(Name = "Caja 7")]
            B7 = 7,
            [Display(Name = "Caja 8")]
            B8 = 8,
            [Display(Name = "Caja 9")]
            B9 = 9,
            [Display(Name = "Caja 10")]
            B10 = 10,
            [Display(Name = "Caja 11")]
            B11 = 11,
            [Display(Name = "Caja 12")]
            B12 = 12,
        }

        public enum MovTypeEnum
        {
            Entrada = 1,
            Salida = 2
        }
    }
}
