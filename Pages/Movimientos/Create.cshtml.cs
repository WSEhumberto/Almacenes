using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Almacenes.Data;
using Almacenes.Models;

namespace Almacenes.Pages.Movimientos
{
    public class CreateModel : PageModel
    {
        private readonly AlmacenesContext _context;

        public CreateModel(AlmacenesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MovAlmId"] = new SelectList(_context.Almacenes, "Id", "Id");
        ViewData["MovMatId"] = new SelectList(_context.Materiales, "MaterialId", "MaterialId");
            return Page();
        }

        [BindProperty]
        public Movimiento Movimiento { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movimientos.Add(Movimiento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
