

namespace lib_cafeteria.modelos
{
    public class producto_Extra
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public decimal precioAdicional { get; set; }
        public bool activo { get; set; }
        public int cantidad { get; set; }
        public List<detallesPedido>? detallesPedidos { get; set; }
    }
}
