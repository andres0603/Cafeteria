using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class sesionesUnitaria
{
    private IConexion? iConexion;
    private sesiones? sesion;

    [TestMethod]
    public void Ejecutar()
    {
        Guardar();
        Listart();
        Modificar();
        Borrar();
    }

    private void Listart()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
        var lista = iConexion.sesiones!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.sesion = new sesiones()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            Capacidad = 253,
            Motor = "9000cc",
            Marca = "Airbus",
            Modelo = "S526",
            Estado = true,
        };
        this.iConexion.sesiones!.Add(this.sesion!);
        this.iConexion.SaveChanges();

        if (this.sesion.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<sesiones>(this.sesion!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (sesion!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.sesiones!.Remove(this.sesion!);
        this.iConexion.SaveChanges();
    }
}
