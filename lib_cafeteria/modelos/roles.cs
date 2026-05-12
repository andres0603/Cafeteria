

namespace lib_cafeteria.modelos
{
    public class roles
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public decimal salarioBase { get; set; }
        public decimal? valor_dia { get; set; }
        public string? descripcion { get; set; }
        public bool activo { get; set; }
        public List<empleados>? empleados { get; set; }
    }
}
