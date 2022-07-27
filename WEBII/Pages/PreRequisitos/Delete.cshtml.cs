using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBII;
using WEBII.Data;

namespace WEBII.Pages.PreRequisitos
{
    public class DeleteModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public DeleteModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PreRequisito PreRequisito { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PreRequisito == null)
            {
                return NotFound();
            }

            var prerequisito = await _context.PreRequisito.FirstOrDefaultAsync(m => m.Id == id);

            if (prerequisito == null)
            {
                return NotFound();
            }
            else 
            {
                PreRequisito = prerequisito;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PreRequisito == null)
            {
                return NotFound();
            }
            var prerequisito = await _context.PreRequisito.FindAsync(id);

            if (prerequisito != null)
            {
                PreRequisito = prerequisito;
                _context.PreRequisito.Remove(PreRequisito);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
