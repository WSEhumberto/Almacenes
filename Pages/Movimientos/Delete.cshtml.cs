using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Almacenes.Data;
using Almacenes.Models;

namespace Almacenes.Pages.Movimientos
{
    public class DeleteModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public DeleteModel(AlmacenesContext context)
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

            var movimiento = await _context.Movimientos.FirstOrDefaultAsync(m => m.MovimientoId == id);

            if (movimiento == null)
            {
                return NotFound();
            }
            else
            {
                Movimiento = movimiento;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento != null)
            {
                Movimiento = movimiento;
                _context.Movimientos.Remove(Movimiento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
