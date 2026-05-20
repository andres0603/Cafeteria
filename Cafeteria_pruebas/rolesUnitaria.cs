using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class rolesUnitaria
{
    private IConexion? iConexion;
    private roles? rol;

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
        var lista = iConexion.roles!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.rol = new roles()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            descripcion = "Responsable de la operación global y gestión de inventarios.",
            salarioBase = 2500000m,
            activo = true
        };
        this.iConexion.roles!.Add(this.rol!);
        this.iConexion.SaveChanges();

        if (this.rol.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<roles>(this.rol!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (rol!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.roles!.Remove(this.rol!);
        this.iConexion.SaveChanges();
    }
}
