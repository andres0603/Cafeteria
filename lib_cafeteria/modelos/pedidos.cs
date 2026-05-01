

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class pedidos
    {
        public int id { get; set; }
        public decimal total { get; set; }
        public string? notasParaCocina { get; set; }
        public int clientes { get; set; }
        public int estadosPedido { get; set; }
        [ForeignKey("clientes")]
        public clientes? _clientes { get; set; }
        [ForeignKey("estadosPedido")]
        public estadosPedido? _estadosPedido { get; set; }
        public List<detallesPedido> detalles { get; set; } = new List<detallesPedido>();
        public List<pagos>? pagos { get; set; }
    }
}
