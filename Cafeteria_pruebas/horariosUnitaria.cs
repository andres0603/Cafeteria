using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class horariosUnitaria
{
    private IConexion? iConexion;
    private horarios? horario;

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
        var lista = iConexion.horarios!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.horario = new horarios()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            Capacidad = 253,
            Motor = "9000cc",
            Marca = "Airbus",
            Modelo = "S526",
            Estado = true,
        };
        this.iConexion.horarios!.Add(this.horario!);
        this.iConexion.SaveChanges();

        if (this.horario.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<horarios>(this.horario!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (horario!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.horarios!.Remove(this.horario!);
        this.iConexion.SaveChanges();
    }
}
