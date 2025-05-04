using System;
using System.ComponentModel.DataAnnotations;

namespace LoginCadastroMVC.Models
{
    public class AgendamentoViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Selecione uma especialidade")]
        [Display(Name = "Especialidade")]
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "Selecione data e hora")]
        [Display(Name = "Data e Hora")]
        public string DataHora { get; set; }

        [Display(Name = "Mensagem")]
        public string Mensagem { get; set; }
    }
}