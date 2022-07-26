using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBII
{
    public class DisciplinaViewModel
    {
        // public int CategoriaSelecionada { get; set; }

        public Disciplina vDisciplina { get; set; }

        public List<SelectListItem>? vListCategoria { get; set; }

        // public PreRequisito vPreRequisito { get; set; } 
    }
}
