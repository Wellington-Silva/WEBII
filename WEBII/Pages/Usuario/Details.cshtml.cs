using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBII.Data;
using WEBII.Models;

namespace WEBII.Pages.Usuario
{
    public class DetailsModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public DetailsModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public UsuarioVM UsuarioVM { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.UsuarioVM == null)
            {
                return NotFound();
            }

            var usuariovm = await _context.UsuarioVM.FirstOrDefaultAsync(m => m.Id == id);
            if (usuariovm == null)
            {
                return NotFound();
            }
            else 
            {
                UsuarioVM = usuariovm;
            }
            return Page();
        }
    }
}
