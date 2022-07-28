using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WEBII
{
    [Table("prerequisitos")]
    public class PreRequisitoVM
    {
        public int Id { get; set; }
        public DisciplinaVM DisciplinaRequerida { get; set; }
        public DisciplinaVM PrerequisitoDisciplina { get; set; }
    }
}
