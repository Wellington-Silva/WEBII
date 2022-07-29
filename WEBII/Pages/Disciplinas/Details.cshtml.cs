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
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public DetailsModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public DisciplinaViewModel DisciplinaVM { get; set; } = new DisciplinaViewModel();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Disciplina == null)
            {
                return NotFound();
            }

            var disciplina = await _context.Disciplina.Include("Categoria").FirstOrDefaultAsync(m => m.Id == id);
            if (disciplina == null)
            {
                return NotFound();
            }
            else
            {
                DisciplinaVM.vDisciplina = disciplina;
                DisciplinaVM.Prerequisitos = _context.PreRequisito.Include("PrerequisitoDisciplina").Where(p => p.DisciplinaRequerida.Id == id).ToList();
            }
            return Page();
        }

    }
}
