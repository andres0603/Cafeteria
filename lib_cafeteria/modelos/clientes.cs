

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class clientes : personas
    {
        public DateTime fechaRegistro { get; set; } = DateTime.Now;
        public int sedes { get; set; }
        [ForeignKey("sedes")]
        public sedes? _sedes { get; set; }
        public List<pedidos>? pedidos { get; set; }
        public List<reservas>? reservas { get; set; }
    }
}
