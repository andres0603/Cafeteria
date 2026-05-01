

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class tareas
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public DateTime fechaAsignacion { get; set; }
        public string? observaciones { get; set; }
        public bool activo { get; set; }
        public int empleados { get; set; }
        [ForeignKey("empleados")]
        public empleados? _empleados { get; set; }
    }
}
