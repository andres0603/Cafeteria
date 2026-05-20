namespace lib_cafeteria.nucleo
{
    public class Configuraciones
    {
        public static string obtener(string clave)
        {
            try
            {
                return "server=localhost;database=db_cafeteria;Integrated Security=True;TrustServerCertificate=true;";
            }
            catch {
                throw new Exception("No se encontro la base de datos");
            }
        }
    }
}