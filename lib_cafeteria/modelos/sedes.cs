

namespace lib_cafeteria.modelos
{
    public class sedes
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public DateTime fecha_fundacion { get; set; }
        public string? direccion { get; set; }
        public bool activo { get; set; }
        public List<mesas>? mesas { get; set; }
        public List<clientes>? clientes { get; set; }
    }
}
