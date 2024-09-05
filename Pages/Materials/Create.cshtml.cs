using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Almacenes.Data;
using Almacenes.Models;

namespace Almacenes.Pages.Materials
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
            return Page();
        }

        [BindProperty(SupportsGet = true)]
        public Material Material { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Materiales.Add(Material);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
