using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WEBII
{
    public class Prerequisito
    {
        public int Id { get; set; }
        public Disciplina DisciplinaRequerida { get; set; }
        public Disciplina PrerequisitoDisciplina { get; set; }
    }
}
