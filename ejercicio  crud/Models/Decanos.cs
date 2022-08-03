using System.ComponentModel.DataAnnotations;

namespace ejercicio__crud.Models
{
    public class Decanos
    {
        [Key]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int cedula { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? nombres { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? apellidos { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public int celular { get; set; }
    }
}
