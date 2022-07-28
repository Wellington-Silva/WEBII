using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBII.Data;
using WEBII.Models;

namespace WEBII.Pages.Perfil
{
    public class IndexModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public IndexModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PerfilVM> PerfilVM { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Perfil != null)
            {
                PerfilVM = await _context.Perfil.ToListAsync();
            }
        }
    }
}
