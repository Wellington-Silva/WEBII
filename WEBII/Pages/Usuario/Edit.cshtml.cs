using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBII.Data;
using WEBII.Models;

namespace WEBII.Pages.Usuario
{
    public class EditModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public EditModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UsuarioVM UsuarioVM { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.UsuarioVM == null)
            {
                return NotFound();
            }

            var usuariovm =  await _context.UsuarioVM.FirstOrDefaultAsync(m => m.Id == id);
            if (usuariovm == null)
            {
                return NotFound();
            }
            UsuarioVM = usuariovm;
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

            _context.Attach(UsuarioVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioVMExists(UsuarioVM.Id))
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

        private bool UsuarioVMExists(string id)
        {
          return (_context.UsuarioVM?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
