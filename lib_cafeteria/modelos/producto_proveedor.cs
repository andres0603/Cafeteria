

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class producto_proveedor
    {
        public int id { get; set; }
        public int idProducto { get; set; }
        public int idProveedor { get; set; }
        public string? codigoProveedor { get; set; }
        public decimal precio { get; set; }
        [ForeignKey("idProducto")]
        public producto_Extra? _producto { get; set; }
        [ForeignKey("idProveedor")]
        public proveedores? _proveedor { get; set; }
    }
}
