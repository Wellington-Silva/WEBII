using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBII.Models
{

    [Table("aspnetuserroles")]
    
    public class UserRoleVM
    {
        [Key]
        [Display(Name = "id User")]
        [Column("UserId")]
        public string? IdUser { get; set; }

        [Display(Name = "Nome")]
        [Column("RoleId")]
        public string? IdRole { get; set; }

    }

}
