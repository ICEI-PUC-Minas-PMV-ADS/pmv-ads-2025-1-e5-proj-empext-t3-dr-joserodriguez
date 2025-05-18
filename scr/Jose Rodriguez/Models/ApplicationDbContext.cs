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

        // DbSet para a entidade User
        public DbSet<User> Users { get; set; }

        // ✅ DbSet para a entidade Dentista
        public DbSet<Dentista> Dentistas { get; set; } // Adicionando o DbSet para Dentista

        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Inserindo dados iniciais para a tabela User (Exemplo)
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    NameUser = "Dr. José Rodriguez",
                    Email = "Consultoriodontovip@gmail.com",
                    Password = "odontovipJR294"
                }
            );

            // Inserindo dados iniciais para a tabela Dentista (Exemplo)
            modelBuilder.Entity<Dentista>().HasData(
                new Dentista
                {
                    Id = 1,
                    Nome = "Dr. Maria Silva",
                    Cedula = "123456",
                    Telefone = "(11) 98765-4321",
                    Email = "maria.silva@odontovip.com"
                }
            );
        }
    }
}

