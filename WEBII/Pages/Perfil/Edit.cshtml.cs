using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBII.Data;
using WEBII.Models;

namespace WEBII.Pages.Perfil
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public EditModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PerfilVM PerfilVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Perfil == null)
            {
                return NotFound();
            }

            var perfilvm =  await _context.Perfil.FirstOrDefaultAsync(m => m.Id == id);
            if (perfilvm == null)
            {
                return NotFound();
            }
            PerfilVM = perfilvm;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PerfilVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilVMExists(PerfilVM.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PerfilVMExists(string id)
        {
          return (_context.Perfil?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
