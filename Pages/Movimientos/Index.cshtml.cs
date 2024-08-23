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
    public class IndexModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public IndexModel(AlmacenesContext context)
        {
            _context = context;
        }

        public IList<Movimiento> Movimiento { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movimiento = await _context.Movimientos
                .Include(m => m.Almacen)
                .Include(m => m.Material)
                .OrderBy(m => m.MovMatId).ThenBy(m => m.MovAlmId)
                .ToListAsync();
        }
    }
}
