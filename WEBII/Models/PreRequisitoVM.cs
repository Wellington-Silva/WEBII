using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBII
{
    [Table("prerequisitos")]
    public class PreRequisitoVM
    {
        [Display(Name = "Requisito ID")]
        [Column("requisitos_id")]
        public int Id { get; set; }

        [Display(Name = "Disicplina ID")]
        [Column("disciplina_id")]
        public int Disciplina_Id { get; set; }

        [Display(Name = "Nome Disciplina")]
        [Column("disciplina_nome")]
        public String? Disciplina_Nome { get; set; }

        [Display(Name = "Requisitos")]
        [Column("requisitos_disciplina")]
        public String? Requisitos { get; set; }

        [Display(Name = "Creditos")]
        [Column("requisitos_creditos")]
        public int Creditos { get; set; }

        [Display(Name = "Periodo")]
        [Column("requisitos_periodo")]
        public int Periodo { get; set; }

    }
}
