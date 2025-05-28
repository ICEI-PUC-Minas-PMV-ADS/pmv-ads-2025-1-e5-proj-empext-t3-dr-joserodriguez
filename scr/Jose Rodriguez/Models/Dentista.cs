using System.ComponentModel.DataAnnotations;

namespace LoginCadastroMVC.Models
{
    public class Dentista
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter até 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [StringLength(100, ErrorMessage = "O email deve ter até 100 caracteres")]
        public string Email { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O telefone deve ter até 20 caracteres")]
        public string Telefone { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "A célula deve ter até 50 caracteres")]
        public string Cedula { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O CRO deve ter até 20 caracteres")]
        public string? CRO { get; set; }

        [StringLength(100, ErrorMessage = "A especialidade deve ter até 100 caracteres")]
        public string? Especialidade { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}