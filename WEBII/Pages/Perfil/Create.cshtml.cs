using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlConnector;
using WEBII.Data;
using WEBII.Models;

namespace WEBII.Pages.Perfil
{
    [Authorize(Roles = "admin")]
    public class CreateModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateModel(WEBII.Data.ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PerfilVM PerfilVM { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string Nome)
        {
            string idcategoria="";
          if (!ModelState.IsValid || _context.Perfil == null || PerfilVM == null)
            {
                return Page();
            }
            Random random = new Random();
            string idCategoria = random.Next(1000000, 9999999).ToString();
            PerfilVM.Id = idCategoria;
            PerfilVM.NomeNormalizado = PerfilVM.Nome.ToUpper();
            _context.Perfil.Add(PerfilVM);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
