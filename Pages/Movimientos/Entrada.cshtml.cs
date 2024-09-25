using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Almacenes.Data;
using Almacenes.Models;
using System.Collections.Immutable;
using Almacenes.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Almacenes.Pages.Movimientos
{
    public class EntradaModel : PageModel
    {
        private readonly AlmacenesContext _context;
        private readonly IMaterialBalance _balance;

        public EntradaModel(AlmacenesContext context, IMaterialBalance balance)
        {
            _context = context;
            _balance = balance;
        }

        [BindProperty]
        public Movimiento Movimiento { get; set; } = default!;
        public List<SelectListItem> AlmacenesList { get; set; } = default!;
        public string SelectedAlmacen { get; set; }
        //[BindProperty]
        public IList<SelectListItem> MaterialesList { get; set; } = default!;

        public string SelectedMaterial { get; set; }

        public decimal Availability { get; set; }


        public IActionResult OnGet()
        {
            AlmacenesList =
                _context.Almacenes
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.AlmName })
                    .ToList();
            SelectedAlmacen = AlmacenesList.First().Value.ToString();
                
            MaterialesList =
                _context.Materiales
                    .Select(s => new SelectListItem { Value = s.MaterialId.ToString(), Text = s.MatName })
                    .ToList();
            SelectedMaterial = MaterialesList.First().Value.ToString();

            ViewData["Availability1"] = ViewData["Availability"];

            Availability = _balance.Balance(_context, int.Parse(SelectedMaterial), int.Parse(SelectedAlmacen));

            

            return Page();
        }

        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            AlmacenesList =
                _context.Almacenes
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.AlmName }).ToList();
                SelectedAlmacen = AlmacenesList.First().Value.ToString();

            MaterialesList =
                _context.Materiales
                    .Select(s => new SelectListItem { Value = s.MaterialId.ToString(), Text = s.MatName }).ToList();
            SelectedMaterial = MaterialesList.First().Value.ToString();


            var Availability =
                _balance.Balance(_context, Movimiento.MovMatId, Movimiento.MovAlmId);

            var mov =
                _context.Movimientos
                    .Where(w => w.MovMatId == Movimiento.MovMatId && w.MovAlmId == Movimiento.MovAlmId)
                    .Include(i => i.Almacen)
                    .Include(i => i.Material)
                    //.Select(s => new { a = s.Material.MatName, b = s.Almacen.AlmName })
                    .FirstOrDefault();

            if(Movimiento.MovQuantity <= 0)
            {
                ViewData["Availability"] = "Only Quantities greater then Zero allowed! Note: There are" + Availability + " ea -" + mov.Material.MatName + " In Bodega -" + mov.Almacen.AlmName + " in existence";
                ViewData["Movimiento"] = Movimiento;
                return Page();
                //return RedirectToPage("./Index");
            }

            //Movimiento.MovQuantity = -Movimiento.MovQuantity;

            //Movimiento.MovTypeEnum movTypeEnum = new Movimiento.MovTypeEnum();
            //movTypeEnum = Movimiento.MovTypeEnum.Entrada;

            Movimiento.MovType = Movimiento.MovTypeEnum.Entrada;    

            _context.Movimientos.Add(Movimiento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
