

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class mesas
    {
        public int id { get; set; }
        public int nro_mesa { get; set; }
        public int capacidad { get; set; }
        public bool activo { get; set; }
        public int estadoMesa { get; set; }
        public int sedes { get; set; }
        [ForeignKey("estadoMesa")]
        public estadosMesa? _estadoMesa { get; set; }
        [ForeignKey("sedes")]
        public sedes? _sedes { get; set; }
    }
}
