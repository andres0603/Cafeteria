
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class historial_login
    {
        public int id {  get; set; }
        public DateTime fecha_ingreso { get; set; }= DateTime.Now;
        public string? resultado { get; set; }
        public int id_usuario { get; set; }
        [ForeignKey("id_usuario")]
        public usuarios? _usuario { get; set; }

    }
}
