

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejercicio__crud.Models
{
    public class docentes
    {
        [Key]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int cedula { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? nombres { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? apellidos { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? titulo { get; set; }

        [ForeignKey("facultad")]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int numero { get; set; }
    }
}
