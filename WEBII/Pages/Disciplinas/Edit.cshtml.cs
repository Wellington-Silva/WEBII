using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBII;
using WEBII.Data;

namespace WEBII.Pages.Disciplinas
{
    [Authorize(Roles = "admin,coordenador")]
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

            var disciplina =  await _context.Disciplina.Include("Categoria").FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }
            DisciplinaVM.vDisciplina = disciplina;
            DisciplinaVM.vListCategoria = popularListaCategorias();

            ViewData["UfId"] = new SelectList(_context.categoria, "Id", "Initials");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DisciplinaVM.vDisciplina).State = EntityState.Modified;

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
    }
}
