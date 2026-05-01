

namespace lib_cafeteria.modelos
{
    public class horarios
    {
        public int id { get; set; }
        public string? dia { get; set; }
        public string? horaEntrada { get; set; }
        public string? horaSalida { get; set; }
        public int minutosDescanso { get; set; }
        public bool activo { get; set; }
        public List<empleados>? empleados { get; set; }
    }
}
