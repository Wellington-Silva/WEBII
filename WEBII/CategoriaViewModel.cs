using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBII
{
    public class CategoriaViewModel
    {
        public categoria Categoria { get; set; }

        public List<Disciplina>? Disciplinas { get; set; }
    }
}
