using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Almacenes.Data;
using Almacenes.Models;

namespace Almacenes.Pages.Almacenes
{
    public class IndexModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public IndexModel(AlmacenesContext context)
        {
            _context = context;
        }

        public IList<Almacen> Almacen { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Almacen = await _context.Almacenes.ToListAsync();
        }
    }
}
