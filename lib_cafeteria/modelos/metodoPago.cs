

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace lib_cafeteria.modelos
{
    public class metodoPago
    {
        public int id { get; set; }
        public string? metodo { get; set; }
        public decimal comisionPorcentual { get; set; }
        public bool requiereCodigo { get; set; }
        public string? referenciaAprobacion { get; set; }
        public bool activo { get; set; }
        public List<pagos>? pagos { get; set; }
    }
  

}
