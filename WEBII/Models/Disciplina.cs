using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBII
{
    [Table("disciplinas")]
    public class Disciplina
    {
        [Display(Name = "id")]
        [Column("disciplina_id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("disciplina_nome")]
        public string Nome { get; set; }

        [Display(Name = "Periodo")]
        [Column("disciplina_periodo")]
        public int Periodo { get; set; }

        public int categoriaId { get; set; }
        [Display(Name = "Categoria")]
        [Column("disciplina_categoria")]
        public categoria? Categoria { get; set; }

        [Display(Name = "Dificuldade")]
        [Column("disciplina_dificuldade")]
        public double Dificuldade { get; set; }

        [Display(Name = "Creditos")]
        [Column("disciplina_creditos")]
        public int Creditos { get; set; }

        [Display(Name = "Hora Aula")]
        [Column("disciplina_horaAula")]
        public int HoraAula { get; set; }

        [Display(Name = "Hora Relogio")]
        [Column("disciplina_horaRelogio")]
        public int HoraRelogio { get; set; }

        [Display(Name = "Quantidade Teoricas")]
        [Column("disciplina_qtdTeorica")]
        public int qtdTeorica { get; set; }

        [Display(Name = "Quantidade Pratica")]
        [Column("disciplina_qtdPratica")]
        public int qtdPratica { get; set; }

        [Display(Name = "Ementa")]
        [Column("disciplina_ementa")]
        public String? Ementa { get; set; }

    }
}
