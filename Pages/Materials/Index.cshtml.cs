using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Almacenes.Data;
using Almacenes.Models;
using System.Drawing.Text;
using Microsoft.Identity.Client;
using Almacenes.Interfaces;

namespace Almacenes.Pages.Materials
{
    public class IndexModel : PageModel
    {
        private readonly AlmacenesContext _context;
        private readonly IMaterialBalance _balance;

        public IndexModel(AlmacenesContext context, IMaterialBalance balance)
        {
            _context = context;
            _balance = balance;
        }

        public IList<Material> Material { get;set; } = default!;
        public IList<Movimiento> Movimientos { get;set; } = default!;
        public async Task OnGetAsync()
        {
            var materials = from r in _context.Materiales
                            .Include(m => m.Movimientos).ThenInclude(a => a.Almacen)
                select new Material
                {
                    MaterialId = r.MaterialId,
                    MatName = r.MatName, 
                    MatUM = r.MatUM,
                    Existencia = _balance.Balance(r.MaterialId)

                };
            Material = await materials.ToListAsync();
        }
    }
}
