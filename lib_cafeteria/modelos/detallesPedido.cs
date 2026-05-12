

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class detallesPedido
    {
        public int id { get; set; }
        public int producto { get; set; }
        public int? producto_Extra { get; set; }
        public int pedidos { get; set; }
        public int cantidad { get; set; }
        public int cantidadExtra { get; set; }
        public string? descripcion { get; set; }
        public decimal subtotal { get; set; }
        [ForeignKey("producto")]
        public productos? _producto { get; set; }
        [ForeignKey("pedidos")]
        public pedidos? _pedidos { get; set; }
        [ForeignKey("producto_Extra")]
        public producto_Extra? _productoExtra { get; set; }
    }
}
