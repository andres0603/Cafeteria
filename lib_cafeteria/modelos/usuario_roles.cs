
using System.ComponentModel.DataAnnotations.Schema;


namespace lib_cafeteria.modelos
{
    public class usuario_roles
    {
        public int id {  get; set; }
        public int id_usuario { get; set; }
        public int id_rol {  get; set; }
        public DateTime fechaAsignacion { get; set; }= DateTime.Now;
        public bool activo {  get; set; }
        [ForeignKey("id_usuario")]
        public usuarios? _usuario { get; set; }
        [ForeignKey("id_rol")]
        public roles? _rol { get; set; }

    }
}
