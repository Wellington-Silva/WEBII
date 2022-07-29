using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBII.Data;
using WEBII.Models;

namespace WEBII.Pages.Perfil
{
    [Authorize(Roles = "admin")]
    public class DetailsModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public DetailsModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public PerfilVM PerfilVM { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Perfil == null)
            {
                return NotFound();
            }

            var perfilvm = await _context.Perfil.FirstOrDefaultAsync(m => m.Id == id);
            if (perfilvm == null)
            {
                return NotFound();
            }
            else 
            {
                PerfilVM = perfilvm;
            }
            return Page();
        }
    }
}
