using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class productosUnitaria
{
    private IConexion? iConexion;
    private productos? producto;

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
        var lista = iConexion.productos!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.producto = new productos()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            precio = 4500,
            descripcion = "Café negro intenso",
            cantidad = 50,
            categoria = 5

        };
        this.iConexion.productos!.Add(this.producto!);
        this.iConexion.SaveChanges();

        if (this.producto.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<productos>(this.producto!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (producto!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.productos!.Remove(this.producto!);
        this.iConexion.SaveChanges();
    }
}
