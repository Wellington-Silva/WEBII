using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBII.Models
{
    [Table("aspnetusers")]
    public class UsuarioVM
    {
        [Display(Name = "id")]
        [Column("Id")]
        public string? Id { get; set; }

        [Display(Name = "Nome")]
        [Column("UserName")]
        public string? Nome { get; set; }
        [Display(Name = "Email")]
        [Column("Email")]
        public string? Email { get; set; }
    }
}
