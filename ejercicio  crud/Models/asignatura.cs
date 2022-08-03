using System.ComponentModel.DataAnnotations;

namespace ejercicio__crud.Models
{
    public class asignatura
    {
        [Key]
        [Required(ErrorMessage = "este campo es obligatorio")]
        public int codigo { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public string? nombre { get; set; }

        [Required(ErrorMessage = "este campo es obligatorio")]
        public int Nro_creditos { get; set; }
    }
}
