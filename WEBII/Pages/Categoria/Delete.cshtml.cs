using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBII;
using WEBII.Data;

namespace WEBII.Pages.Categoria
{
    [Authorize(Roles = "admin,coordenador")]
    public class DeleteModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public DeleteModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CategoriaVM categoria { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.categoria.FirstOrDefaultAsync(m => m.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }
            else 
            {
                categoria = categoria;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }
            var categoria = await _context.categoria.FindAsync(id);

            if (categoria != null)
            {
                categoria = categoria;
                _context.categoria.Remove(categoria);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
