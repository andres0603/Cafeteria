

namespace lib_cafeteria.modelos
{
    public class usuarios
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? correo { get; set; }
        public string? contraseña { get; set; }
        public bool activo { get; set; }
    }
}