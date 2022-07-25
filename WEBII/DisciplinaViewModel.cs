using Microsoft.AspNetCore.Mvc.Rendering;

namespace WEBII
{
    public class DisciplinaViewModel
    {
        public categoria vCategoria { get; set; }

        public PreRequisito vPreRequisito { get; set; } 

        public Disciplina vDisciplina { get; set; }

        public List<SelectListItem> vListCategoria { get; set; }


        public List<SelectListItem> CarregarCategorias(int Id)
        {

           var lista = new List<SelectListItem>();


            return lista;
        }

    }
}
