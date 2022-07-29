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
    [Authorize(Roles = "admin,coordenador")]
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
            DisciplinaVM.vListPreRequisito = popularListaPrerequisitos();

            return Page();
        }

        [BindProperty]
        public DisciplinaViewModel DisciplinaVM { get; set; } = new DisciplinaViewModel();

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] prerequisitos)
        {
            if (!ModelState.IsValid || _context.Disciplina == null || DisciplinaVM.vDisciplina == null)
            {
                DisciplinaVM.vListCategoria = popularListaCategorias();
                DisciplinaVM.vListPreRequisito = popularListaPrerequisitos();

                foreach (var prerequisito in DisciplinaVM.vListPreRequisito)
                {
                    prerequisito.Selected = prerequisitos.Contains(prerequisito.Value.ToString());
                }

                return Page();
            }

            _context.Disciplina.Add(DisciplinaVM.vDisciplina);

            List<DisciplinaVM> disciplinasPrerequisitos = _context.Disciplina.Where(d => prerequisitos.Contains(d.Id.ToString())).ToList();

            foreach (var prerequisito in disciplinasPrerequisitos)
            {
                _context.PreRequisito.Add(new PreRequisitoVM()
                {
                    DisciplinaRequerida = DisciplinaVM.vDisciplina,
                    PrerequisitoDisciplina = prerequisito
                });
            }

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

        private List<SelectListItem> popularListaPrerequisitos()
        {
            return _context.Disciplina
                                    .Select(a => new SelectListItem()
                                    {
                                        Value = a.Id.ToString(),
                                        Text = a.Nome
                                    }).ToList();
        }
    }
}
