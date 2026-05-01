

using System.ComponentModel.DataAnnotations.Schema;

namespace lib_cafeteria.modelos
{
    public class reservas
    {
        public int id { get; set; }
        public DateTime fechaHoraReserva { get; set; }
        public int numeroPersonas { get; set; }
        public int estadoReserva { get; set; }
        public string? requerimientosEspeciales { get; set; }
        public int clientes { get; set; }
        [ForeignKey("estadoReserva")]
        public estadoReserva? _estadoReserva { get; set; }
        [ForeignKey("clientes")]
        public clientes? _clientes { get; set; }
    }
}
