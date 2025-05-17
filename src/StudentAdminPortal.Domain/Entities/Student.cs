using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortal.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Solo es permitido letras.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo es permitido Números.")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        public string Email { get; set; }

        // Agrega otras propiedades que tengas, si aplica
    }
}