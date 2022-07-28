using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBII.Models
{
    [Keyless]
    [NotMapped]
    public class ViewModel
    {
        //public UserRoleVM vUserRole { get; set; }
        public UserRoleVM vUserRole { get; set; }

        public List<SelectListItem>? vListPerfil { get; set; }
    }
}
