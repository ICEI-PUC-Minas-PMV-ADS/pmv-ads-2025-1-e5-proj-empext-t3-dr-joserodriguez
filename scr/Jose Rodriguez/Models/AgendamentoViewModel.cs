using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class AgendamentoViewModel
    {
        [Required(ErrorMessage = "Por favor, insira seu nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insira um e-mail válido.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Escolha uma data.")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "Escreva uma mensagem.")]
        public string Mensagem { get; set; }

        [Required(ErrorMessage = "Escolha um horário.")]
        public string AppointmentTime { get; set; }

        [Required(ErrorMessage = "Selecione uma especialidade.")]
        public string SelectedSpecialty { get; set; }
    }
}
