using System.ComponentModel.DataAnnotations;

namespace Jose_Rodriguez.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        public string Mensagem { get; set; }
    }
}
