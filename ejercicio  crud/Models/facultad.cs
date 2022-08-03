using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejercicio__crud.Models
{
    public class facultad
    {
        [Key]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int numero { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? nombre { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? ubicacion { get; set; }

        [ForeignKey("Decanos")]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int cedula { get; set; }
    }
}
