using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEBII.Models;

namespace WEBII.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Disciplina>? Disciplina { get; set; }

        public DbSet<PreRequisito>? PreRequisito { get; set; }

        public DbSet<categoria>? categoria { get; set; }

        public DbSet<WEBII.Models.PerfilVM>? Perfil { get; set; }

        public DbSet<WEBII.Models.UsuarioVM>? UsuarioVM { get; set; }

        public DbSet<WEBII.Models.UserRoleVM>? UserRoleVM { get; set; }
        public DbSet<WEBII.Models.ViewModel>? ViewModel { get; set; }
    }
}