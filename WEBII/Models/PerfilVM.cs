using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WEBII.Models
{
    [Table("aspnetroles")]
    public class PerfilVM
    {
        [Display(Name = "id")]
        [Column("Id")]
        public string? Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Name")]
        public string? Nome { get; set; }
        [Display(Name = "Nome Normalizado")]
        [Column("NormalizedName")]
        public string? NomeNormalizado { get; set; }
    }
}