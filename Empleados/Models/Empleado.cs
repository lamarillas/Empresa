using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleados.Models
{
    public class Empleado
    {
        [Key]
        public int Empleado_Id { get; set; }

        [Required, MaxLength(30)]
        public string Nombre { get; set; }

        [Required, MaxLength(30)]
        public string Apellido_Paterno { get; set; }

        [Required, MaxLength(30)]
        public string Apellido_Materno { get; set; }

        [Required, Column(TypeName = "Date")]
        public DateTime Fecha_Nacimiento { get; set; }

        public int Estatus_Id { get; set; }

        [ForeignKey("Estatus_Id")]
        public Estatus Estatus { get; set; }
    }
}
