

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class productos
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public decimal precio { get; set; }
        public string? descripcion { get; set; }
        public int categoria { get; set; }
        public int cantidad { get; set; }
        [ForeignKey("categoria")]
        public categorias? _categorias { get; set; }
        public List<detallesPedido>? detallesPedidos { get; set; }
        public List<producto_proveedor>? productoProveedores { get; set; }
    }
}
