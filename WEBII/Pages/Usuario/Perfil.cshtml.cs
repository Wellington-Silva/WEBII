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
    public class RoleModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public RoleModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ViewModel ViewModel { get; set; } = new ViewModel();
        string idU;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            idU = id;
            ViewModel.vListPerfil = popularListaPerfil();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.UserRoleVM == null || ViewModel.vUserRole == null)
            {
                ViewModel.vListPerfil = popularListaPerfil();

                return Page();
            }
            ViewModel.vUserRole.IdUser = idU;
            _context.UserRoleVM.Add(ViewModel.vUserRole);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private List<SelectListItem> popularListaPerfil()
        {
            return _context.Perfil
                                      .Select(a => new SelectListItem()
                                      {
                                          Value = a.Id,
                                          Text = a.Nome
                                      }).ToList();
        }
    }
}
