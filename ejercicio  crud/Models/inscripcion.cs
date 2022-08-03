using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejercicio__crud.Models
{
    public class inscripcion
    {
        [Key]
        [Required (ErrorMessage  = "este campo es obligatorio")]
        public int Nro_inscripcion { get; set; }

        [ForeignKey("asignatura")]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int codigo { get; set; }

        [ForeignKey("estudiante")]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int Nro_id { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public int periodo { get; set; }
    }
}
