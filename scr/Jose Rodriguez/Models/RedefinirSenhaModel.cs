using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class RedefinirSenhaViewModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string? Email { get; set; }
    }
}