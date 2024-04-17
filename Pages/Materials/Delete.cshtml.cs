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
    public class DeleteModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public DeleteModel(AlmacenesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Material Material { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiales.FirstOrDefaultAsync(m => m.MaterialId == id);

            if (material == null)
            {
                return NotFound();
            }
            else
            {
                Material = material;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materiales.FindAsync(id);
            if (material != null)
            {
                Material = material;
                _context.Materiales.Remove(Material);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
