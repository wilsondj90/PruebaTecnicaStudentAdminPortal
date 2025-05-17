using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortal.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "Solo es permitido letras.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo es permitido Números.")]
        public int Credits { get; set; }
    }
}
