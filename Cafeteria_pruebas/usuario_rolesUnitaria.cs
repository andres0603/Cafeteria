using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class usuario_rolesUnitaria
{
    private IConexion? iConexion;
    private usuario_roles? usuario_rol;

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
        var lista = iConexion.usuario_roles!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.usuario_rol = new usuario_roles()
        {
             id_usuario=1,
             id_rol=1,
             activo=true,
             fechaAsignacion=DateTime.Now
        };
        this.iConexion.usuario_roles!.Add(this.usuario_rol!);
        this.iConexion.SaveChanges();

        if (this.usuario_rol.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<usuario_roles>(this.usuario_rol!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (usuario_rol!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.usuario_roles!.Remove(this.usuario_rol!);
        this.iConexion.SaveChanges();
    }
}
