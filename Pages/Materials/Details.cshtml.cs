using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Almacenes.Data;
using Almacenes.Models;

namespace Almacenes.Pages.Materials
{
    public class DetailsModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public DetailsModel(AlmacenesContext context)
        {
            _context = context;
        }

        public Material Material { get; set; } = default!;

        public List<Movimiento> Movimientos { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? almId)
        {
            if (id == null)
            {
                return NotFound();
            }


            var movimientos = await _context.Movimientos.Where(w => w.MovMatId == id && w.MovAlmId == almId).Include(i => i.Almacen).Include(m => m.Material).ToListAsync();
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
