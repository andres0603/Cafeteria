using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class tareasUnitaria
{
    private IConexion? iConexion;
    private tareas? tarea;

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
        var lista = iConexion.tareas!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.tarea = new tareas()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            Capacidad = 253,
            Motor = "9000cc",
            Marca = "Airbus",
            Modelo = "S526",
            Estado = true,
        };
        this.iConexion.tareas!.Add(this.tarea!);
        this.iConexion.SaveChanges();

        if (this.tarea.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<tareas>(this.tarea!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (tarea!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.tareas!.Remove(this.tarea!);
        this.iConexion.SaveChanges();
    }
}
