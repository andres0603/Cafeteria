
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class pagos
    {
        public int id { get; set; }
        public int pedido { get; set; }
        public int metodoPago { get; set; }
        public decimal montoPagado { get; set; }
        public decimal devuelta { get; set; }
        public decimal propina { get; set; }
        [ForeignKey("pedido")]
        public pedidos? _pedido { get; set; }
        [ForeignKey("metodoPago")]
        public metodoPago? _metodoPago { get; set; }
    }
}
