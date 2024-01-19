using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empleados.Models
{
    [Table("Estatus")]
    public class Estatus
    {
        [Key]
        public int Estatus_Id { get; set; }

        [Required, MaxLength(50)]
        public string Descripcion { get; set; }

    }
}
