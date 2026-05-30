

namespace lib_cafeteria.modelos
{
    public class historicos
    {
        public int id { get; set; }
        public string? usuario { get; set; }
        public string? nombreTabla { get; set; }
        public string? accion { get; set; }
        public DateTime? fechaCambio { get; set; }
    }
}
