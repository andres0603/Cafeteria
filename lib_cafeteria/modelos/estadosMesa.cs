

namespace lib_cafeteria.modelos
{
    public class estadosMesa
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public bool PermiteAsignarPedido { get; set; }
        public bool activo { get; set; }
        public List<mesas>? mesas { get; set; }
    }
}
