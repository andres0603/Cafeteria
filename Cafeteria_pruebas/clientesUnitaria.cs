using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class clientesUnitaria
{
    private IConexion? iConexion;
    private clientes? cliente;

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
        var lista = iConexion.clientes!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.cliente = new clientes()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            cedula= "14565595",
            correo= "ut@gmail.com",
            direccion= "calle 10",
            fechaRegistro= DateTime.Now,
            telefono= "26565959",
            activo = true,
        };
        this.iConexion.clientes!.Add(this.cliente!);
        this.iConexion.SaveChanges();

        if (this.cliente.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<clientes>(this.cliente!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (cliente!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.clientes!.Remove(this.cliente!);
        this.iConexion.SaveChanges();
    }
}
