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
    public class CreateModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public CreateModel(AlmacenesContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Movimiento Movimiento { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        //[EnumDataType(typeof(Movimiento.MovTypeEnum))]
        public MovTypeEnum MovTyp { get; set; }
        public enum MovTypeEnum
        {
            Entrada = 1,
            Salida = 2
        }

        public IList<SelectListItem> MaterialesList { get; set; } = default!;
        public string SelectedMaterial { get; set; }

        public List<SelectListItem> AlmacenesList { get; set; } = default!;
        public string SelectedAlmacen { get; set; }





        public IActionResult OnGet()
        {
            ViewData["MovAlmId"] = new SelectList(_context.Almacenes, "Id", "Id");
            ViewData["MovMatId"] = new SelectList(_context.Materiales, "MaterialId", "MaterialId");
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
                    .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.AlmName })
                    .ToList();
            SelectedAlmacen = AlmacenesList.First().Value.ToString();

            MaterialesList =
                _context.Materiales
                    .Select(s => new SelectListItem { Value = s.MaterialId.ToString(), Text = s.MatName })
                    .ToList();
            SelectedMaterial = MaterialesList.First().Value.ToString();


            if ((int)Movimiento.MovType == 1)
            {
                _context.Movimientos.Add(Movimiento);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");


            }
            else
            {
                Movimiento.MovQuantity = -Movimiento.MovQuantity;
                _context.Movimientos.Add(Movimiento);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");

            };
        }
    }
}
