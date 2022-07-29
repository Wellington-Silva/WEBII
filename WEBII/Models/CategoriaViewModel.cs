using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBII.Models
{
    public class CategoriaViewModel
    {
        public CategoriaVM Categoria { get; set; }

        public List<DisciplinaVM>? Disciplinas { get; set; }
    }
}
