

namespace lib_cafeteria.modelos
{
    public class categorias
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public List<producto_Extra>? productoExtra { get; set; }
        public List<productos>? productos { get; set; }
    }
}
