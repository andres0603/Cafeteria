

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class empleados:personas
    {
        public decimal salario { get; set; }
        public int rol { get; set; }
        public int horarios { get; set; }
        public DateTime fechaIngreso { get; set; }
        [ForeignKey("rol")]
        public roles? _rol { get; set; }
        [ForeignKey("horarios")]
        public horarios? _horarios { get; set; }
        public List<tareas>? tareas { get; set; }
    }
}
