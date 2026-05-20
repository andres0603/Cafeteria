using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class usuariosUnitaria
{
    private IConexion? iConexion;
    private usuarios? usuario;

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
        var lista = iConexion.usuarios!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.usuario = new usuarios()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            correo="andres455",
            contraseña="andres603",
            activo= true
        };
        this.iConexion.usuarios!.Add(this.usuario!);
        this.iConexion.SaveChanges();

        if (this.usuario.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<usuarios>(this.usuario!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (usuario!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.usuarios!.Remove(this.usuario!);
        this.iConexion.SaveChanges();
    }
}
