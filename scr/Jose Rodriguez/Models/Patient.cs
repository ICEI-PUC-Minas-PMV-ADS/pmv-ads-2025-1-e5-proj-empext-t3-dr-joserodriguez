using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LoginCadastroMVC.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome deve ter até 100 caracteres")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [StringLength(200, ErrorMessage = "O endereço deve ter até 200 caracteres")]
        [Display(Name = "Endereço")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "Telefone inválido")]
        [Display(Name = "Telefone")]
        public string? Phone { get; set; }

        [StringLength(500, ErrorMessage = "A queixa deve ter até 500 caracteres")]
        [Display(Name = "Queixa Principal")]
        public string? Complaint { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data da Consulta")]
        public DateTime? AppointmentDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Hora da Consulta")]
        public TimeSpan? AppointmentTime { get; set; }

        [NotMapped]
        [Display(Name = "Especialidades")]
        public List<SpecialtyEnum> Specialties { get; set; } = new List<SpecialtyEnum>();

        [Display(Name = "Especialidades")]
        public string SpecialtiesString
        {
            get => string.Join(",", Specialties ?? new List<SpecialtyEnum>());
            set
            {
                Specialties = string.IsNullOrEmpty(value)
                    ? new List<SpecialtyEnum>()
                    : value.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(e => Enum.Parse<SpecialtyEnum>(e))
                          .ToList();
            }
        }
    }

    public enum SpecialtyEnum
    {
        Ortodontia,
        Endodontia,
        Periodontia,
        Implantodontia,
        Odontopediatria,
        CirurgiaBucomaxilofacial,
        ProteseDentaria,
        DentisticaEstetica,
        RadiologiaOdontologica,
        Odontogeriatria
    }
}