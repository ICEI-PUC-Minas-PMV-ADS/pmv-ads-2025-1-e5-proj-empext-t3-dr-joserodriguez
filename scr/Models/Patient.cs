using System.ComponentModel.DataAnnotations;

namespace LoginCadastroMVC.Models
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Complaint { get; set; } // Queixa odontológica
    }
}
