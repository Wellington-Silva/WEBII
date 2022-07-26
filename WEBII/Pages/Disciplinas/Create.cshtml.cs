using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBII;
using WEBII.Data;

namespace WEBII.Pages.Disciplinas
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public CreateModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            DisciplinaVM.vListCategoria = popularListaCategorias();

            return Page();
        }

        [BindProperty]
        public DisciplinaViewModel DisciplinaVM { get; set; } = new DisciplinaViewModel();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Disciplina == null || DisciplinaVM.vDisciplina == null)
            {
                DisciplinaVM.vListCategoria = popularListaCategorias();

                return Page();
            }

            DisciplinaVM.vDisciplina.Categoria.Categoria_Nome =
                _context.categoria.
                FirstOrDefault(a => a.Id == DisciplinaVM.vDisciplina.Categoria.Id).
                Categoria_Nome;

            _context.Disciplina.Add(DisciplinaVM.vDisciplina);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private List<SelectListItem> popularListaCategorias()
        {
            return _context.categoria
                                      .Select(a => new SelectListItem()
                                      {
                                          Value = a.Id.ToString(),
                                          Text = a.Categoria_Nome
                                      }).ToList();
        }
    }
}
