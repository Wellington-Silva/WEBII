using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBII.Data;
using WEBII.Models;

namespace WEBII.Pages.Usuario
{
    public class CreateModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public CreateModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UsuarioVM UsuarioVM { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.UsuarioVM == null || UsuarioVM == null)
            {
                return Page();
            }

            _context.UsuarioVM.Add(UsuarioVM);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
