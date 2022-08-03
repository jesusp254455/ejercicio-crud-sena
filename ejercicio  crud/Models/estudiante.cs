using System.ComponentModel.DataAnnotations;

namespace ejercicio__crud.Models
{
    public class estudiante
    {
        [Key]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int Nro_id { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? nombres { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? apellido { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? direccion { get; set; }
    }
}
