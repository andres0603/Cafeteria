

namespace lib_cafeteria.modelos
{
    public class estadosPedido
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public List<pedidos>? pedidos { get; set; }
    }
}
