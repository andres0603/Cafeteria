

namespace lib_cafeteria.modelos
{
    public class estadoReserva
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public List<reservas>? reservas { get; set; }
    }
}
