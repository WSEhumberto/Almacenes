using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Almacenes.Data;
using Almacenes.Models;

namespace Almacenes.Pages.Movimientos
{
    public class EditModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public EditModel(AlmacenesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movimiento Movimiento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento =  await _context.Movimientos.FirstOrDefaultAsync(m => m.MovimientoId == id);
            if (movimiento == null)
            {
                return NotFound();
            }
            Movimiento = movimiento;
           ViewData["MovAlmId"] = new SelectList(_context.Almacenes, "Id", "Id");
           ViewData["MovMatId"] = new SelectList(_context.Materiales, "MaterialId", "MaterialId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Movimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExists(Movimiento.MovimientoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovimientoExists(int id)
        {
            return _context.Movimientos.Any(e => e.MovimientoId == id);
        }
    }
}
