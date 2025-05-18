using System;
using System.ComponentModel.DataAnnotations;

namespace LoginCadastroMVC.Models
{
    // Modelo para armazenar no banco de dados
    public class Agendamento
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Especialidade { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string Hora { get; set; }

        public string Mensagem { get; set; }

        public bool Confirmado { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}