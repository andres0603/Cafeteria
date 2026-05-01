

namespace lib_cafeteria.modelos
{
    public class proveedores
    {
        public int id { get; set; }
        public string? nit { get; set; }
        public string? nombre { get; set; }
        public string? telefono { get; set; }
        public string? direccion { get; set; }
        public bool activo { get; set; }
        public List<producto_proveedor>? producto_Proveedores { get; set; }
    }
}
