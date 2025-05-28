using Microsoft.EntityFrameworkCore;
using LoginCadastroMVC.Models;

namespace SeuProjeto.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Agendamento> Agendamentos { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Dentista> Dentistas { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações para Patient
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Phone).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Address).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Complaint).HasMaxLength(500);
                entity.Property(e => e.SpecialtiesString).HasMaxLength(200);
            });

            // Configurações para Agendamento
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Telefone).HasMaxLength(20).IsRequired();
                entity.Property(e => e.Especialidade).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Hora).HasMaxLength(5).IsRequired();
                entity.Property(e => e.Mensagem).HasMaxLength(500);
                entity.Property(e => e.DataCriacao).HasDefaultValueSql("GETDATE()");
            });

            // Configurações para User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Telefone).HasMaxLength(20);
                entity.Property(e => e.Cedula).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(100).IsRequired();
            });

            // Configurações para Dentista
            modelBuilder.Entity<Dentista>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Telefone).HasMaxLength(20);
                entity.Property(e => e.Cedula).HasMaxLength(50);
                entity.Property(e => e.CRO).HasMaxLength(20);
                entity.Property(e => e.Especialidade).HasMaxLength(100);
            });
        }
    }
}