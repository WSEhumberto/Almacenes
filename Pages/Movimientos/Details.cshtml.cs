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
    public class DetailsModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public DetailsModel(AlmacenesContext context)
        {
            _context = context;
        }

        public List<Movimiento> Movimientos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientos = await _context.Movimientos.Where(w => w.MovimientoId == id).Include(i => i.Almacen).ToListAsync();
            if (movimientos == null)
            {
                return NotFound();
            }
            else
            {
                Movimientos = movimientos;
            }
            return Page();
        }
    }
}
