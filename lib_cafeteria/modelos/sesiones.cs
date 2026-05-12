

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class sesiones
    {
        public int id {  get; set; }
        public DateTime fecha_sesion {  get; set; }
        public bool estado {  get; set; }
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public usuarios? _usuario { get; set; }
    }
}
