using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class personasUnitaria
{
    private IConexion? iConexion;
    private personas? persona;

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
        var lista = iConexion.personas!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.persona = new personas()
        {
            nombre = "UT-" + DateTime.Now,
            telefono = "3001234567",
            correo = "juan.perez@email.com",
            direccion = "Calle 100 # 15-20",
            cedula = "10203040",
            activo = true,

        };
        this.iConexion.personas!.Add(this.persona!);
        this.iConexion.SaveChanges();

        if (this.persona.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<personas>(this.persona!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (persona!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.personas!.Remove(this.persona!);
        this.iConexion.SaveChanges();
    }
}
