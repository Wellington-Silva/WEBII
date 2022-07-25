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

namespace WEBII.Pages.Disciplinas
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public DeleteModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Disciplina Disciplina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Disciplina == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina.FirstOrDefaultAsync(m => m.Id == id);

            if (disciplina == null)
            {
                return NotFound();
            }
            else 
            {
                Disciplina = disciplina;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Disciplina == null)
            {
                return NotFound();
            }
            var disciplina = await _context.Disciplina.FindAsync(id);

            if (disciplina != null)
            {
                Disciplina = disciplina;
                _context.Disciplina.Remove(Disciplina);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
