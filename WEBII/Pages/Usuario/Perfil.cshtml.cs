using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBII.Data;
using WEBII.Models;

namespace WEBII.Pages.Usuario
{
    [Authorize(Roles = "admin")]
    public class RoleModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleModel(WEBII.Data.ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [BindProperty]
        public ViewModel ViewModel { get; set; } = new ViewModel();
        public string idU;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            idU = id;
            var UserM = await _userManager.FindByIdAsync(id);
            ViewModel.vListPerfil = popularListaPerfil();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string idU)
        {

            if (!ModelState.IsValid || _context.UserRoleVM == null || ViewModel.vUserRole == null)
            {
                ViewModel.vListPerfil = popularListaPerfil();

                return Page();
            }
            var User = await _userManager.FindByIdAsync(idU);

            var role = _roleManager.FindByIdAsync(ViewModel.vUserRole.IdRole).Result;

            var resultado = await _userManager.AddToRoleAsync(User, role.Name);
            //ViewModel.vUserRole.IdUser = idU;
            //var User = _userManager.FindByIdAsync(idU).Result;
            //var userIdentity = new IdentityUser { UserName = User.Email, Email = User.Email};

            //var role = _roleManager.FindByIdAsync(ViewModel.vUserRole.IdRole).Result;

            ////await _userManager.AddToRoleAsync(userIdentity, role.Name);
            //ViewModel.vUserRole.IdUser = idU;
            //_context.UserRoleVM.Add(ViewModel.vUserRole);
            //await _context.SaveChangesAsync();

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
