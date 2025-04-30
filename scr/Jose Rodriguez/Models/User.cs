using System.ComponentModel.DataAnnotations;

namespace LoginCadastroMVC.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? NameUser { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
