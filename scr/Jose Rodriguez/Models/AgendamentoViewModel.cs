using System;
using System.ComponentModel.DataAnnotations;

namespace SeuProjeto.Models
{
    public class AgendamentoViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        public string Especialidade { get; set; }

        // Para compatibilidade com o código existente que usa SpecialtiesString
        public string SpecialtiesString
        {
            get { return Especialidade; }
            set { Especialidade = value; }
        }

        [Required(ErrorMessage = "A data e hora são obrigatórias.")]
        [DataType(DataType.DateTime, ErrorMessage = "Data e hora inválidas.")]
        public string DataHora { get; set; }

        // Propriedades derivadas para uso no email
        public DateTime DataConsulta
        {
            get
            {
                if (string.IsNullOrEmpty(DataHora)) return DateTime.Now;

                // Formato esperado: "DD/MM/YYYY - HH:MM"
                string[] parts = DataHora.Split('-');
                if (parts.Length < 1) return DateTime.Now;

                string dateStr = parts[0].Trim();
                if (DateTime.TryParse(dateStr, out DateTime result))
                    return result;

                return DateTime.Now; // Retorna o valor atual caso a data não seja válida
            }
        }

        public string AppointmentTime
        {
            get
            {
                if (string.IsNullOrEmpty(DataHora)) return string.Empty;

                // Formato esperado: "DD/MM/YYYY - HH:MM"
                string[] parts = DataHora.Split('-');
                if (parts.Length < 2) return string.Empty;

                return parts[1].Trim(); // Retorna apenas a parte da hora
            }
        }

        [StringLength(500, ErrorMessage = "A mensagem não pode exceder 500 caracteres.")]
        public string Mensagem { get; set; }
    }
}
