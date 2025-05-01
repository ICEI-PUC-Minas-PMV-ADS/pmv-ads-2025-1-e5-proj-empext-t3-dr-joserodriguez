using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models // Altere para o namespace correto
{
    public class Dentista
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Cédula Profissional")]
        public string Cedula { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
