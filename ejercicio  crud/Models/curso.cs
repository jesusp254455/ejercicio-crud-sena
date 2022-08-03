using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejercicio__crud.Models
{
    public class curso
    {
        [Key]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int Nro_id { get; set; }

        [ForeignKey("docentes")]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int cedula { get; set; }

        [ForeignKey("asignatura")]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int codigo { get; set; }
    }
}
