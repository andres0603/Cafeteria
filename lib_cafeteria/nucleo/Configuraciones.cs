namespace lib_cafeteria.nucleo
{
    public class Configuraciones
    {
        public static string obtener(string clave)
        {
            return "server=localhost;database=db_cafeteria;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}