using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBII;
using WEBII.Data;

namespace WEBII.Pages.Disciplinas
{
    public class EditModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public EditModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DisciplinaViewModel DisciplinaVM { get; set; } = new DisciplinaViewModel();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Disciplina == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina.Include("Categoria")
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }
            DisciplinaVM.vDisciplina = disciplina;
            var prerequisitosDisciplina = _context.Prerequisito.Where(p => p.DisciplinaRequerida.Id == id);

            DisciplinaVM.vListCategoria = popularListaCategorias();
            DisciplinaVM.vListPreRequisito = popularListaPrerequisitos(disciplina.Id,
                                            prerequisitosDisciplina
                                            .Select(p => p.PrerequisitoDisciplina.Id)
                                                    .ToList());

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] prerequisitosSelecionados)
        {
            if (!ModelState.IsValid)
            {
                DisciplinaVM.vListCategoria = popularListaCategorias();
                DisciplinaVM.vListPreRequisito = popularListaPrerequisitos(DisciplinaVM.vDisciplina.Id,
                                                    prerequisitosSelecionados.Select(p => int.Parse(p))
                                                        .ToList());

                return Page();
            }

            _context.Attach(DisciplinaVM.vDisciplina).State = EntityState.Modified;
            atualizarPrerequisitos(DisciplinaVM.vDisciplina, prerequisitosSelecionados);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(DisciplinaVM.vDisciplina.Id))
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

        private bool DisciplinaExists(int id)
        {
            return (_context.Disciplina?.Any(e => e.Id == id)).GetValueOrDefault();
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

        private List<SelectListItem> popularListaPrerequisitos(int id, List<int> prerequisitosSelecionados)
        {
            return _context.Disciplina
                                    .Where(p => p.Id != id)
                                    .Select(p => new SelectListItem()
                                    {
                                        Value = p.Id.ToString(),
                                        Text = p.Nome,
                                        Selected = prerequisitosSelecionados.Contains(p.Id)
                                    }).ToList();
        }

        private void atualizarPrerequisitos(Disciplina disciplina, string[] prerequisitosSelecionados)
        {
            List<Disciplina> disciplinasPrerequisito = _context.Disciplina.Where(p => p.Id != disciplina.Id).ToList();
            List<Prerequisito> prerequisitosDisciplina = _context.Prerequisito.Where(p => p.DisciplinaRequerida.Id == disciplina.Id).ToList();

            if (prerequisitosSelecionados.Count() == 0)
            {
                _context.Prerequisito.RemoveRange(prerequisitosDisciplina);
                return;
            }

            foreach (var disciplinaPrerequisito in disciplinasPrerequisito)
            {
                if (prerequisitosSelecionados.Contains(disciplinaPrerequisito.Id.ToString()))
                {
                    if (!prerequisitosDisciplina
                            .Any(p => p.PrerequisitoDisciplina.Id == disciplinaPrerequisito.Id))
                    {
                        _context.Prerequisito.Add(new Prerequisito()
                        {
                            DisciplinaRequerida = disciplina,
                            PrerequisitoDisciplina = disciplinaPrerequisito
                        });
                    }
                }
                else
                {
                    if (prerequisitosDisciplina
                            .Any(p => p.PrerequisitoDisciplina.Id == disciplinaPrerequisito.Id))
                    {
                        _context.Prerequisito.Remove(
                            (prerequisitosDisciplina
                                .SingleOrDefault
                                (
                                    p => p.DisciplinaRequerida.Id == disciplina.Id
                                    &&
                                    p.PrerequisitoDisciplina.Id == disciplinaPrerequisito.Id
                                )
                            )
                        );
                    }
                }
            }
        }
    }
}
