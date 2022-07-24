using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}