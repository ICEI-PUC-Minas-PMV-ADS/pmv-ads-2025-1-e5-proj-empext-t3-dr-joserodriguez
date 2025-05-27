using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class NovaSenhaViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string? ConfirmacaoSenha { get; set; }
    }
}