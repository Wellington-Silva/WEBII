using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEBII;
using WEBII.Data;

namespace WEBII.Pages.Categoria
{
    public class DetailsModel : PageModel
    {
        private readonly WEBII.Data.ApplicationDbContext _context;

        public DetailsModel(WEBII.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public CategoriaViewModel CategoriaVM { get; set; } = new CategoriaViewModel();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.categoria.FirstOrDefaultAsync(m => m.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            else 
            {
                var disciplinas = await _context.Disciplina.Where(m => m.categoriaId == categoria.Id).ToListAsync();
                CategoriaVM.Categoria = categoria;
                CategoriaVM.Disciplinas = disciplinas;
            }
            return Page();
        }
    }
}
