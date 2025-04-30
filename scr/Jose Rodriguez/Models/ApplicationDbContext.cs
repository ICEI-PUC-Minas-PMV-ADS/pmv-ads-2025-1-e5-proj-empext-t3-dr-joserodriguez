using Microsoft.EntityFrameworkCore;
using LoginCadastroMVC.Models; // Altere para o namespace correto

namespace SeuProjeto.Models // Altere para o namespace correto
{
    public class ApplicationDbContext : DbContext
    {
        // Construtor que configura a string de conexão
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para a entidade Patient
        public DbSet<Patient> Patients { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Email = "Consultoriodontovip@gmail.com",
                    Password = "odontovipJR294"
                }
            );
        }
    }
}
