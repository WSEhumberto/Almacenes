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
    public class DetailsModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public DetailsModel(AlmacenesContext context)
        {
            _context = context;
        }

        public Almacen Almacen { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacen = await _context.Almacenes.FirstOrDefaultAsync(m => m.Id == id);
            if (almacen == null)
            {
                return NotFound();
            }
            else
            {
                Almacen = almacen;
            }
            return Page();
        }
    }
}
