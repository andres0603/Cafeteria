using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class producto_proveedorUnitaria
{
    private IConexion? iConexion;
    private producto_proveedor? producto_proveedores;

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
        var lista = iConexion.producto_proveedor!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.producto_proveedores = new producto_proveedor()
        {
            codigoProveedor = "UT-" + DateTime.Now.ToString(),
            idProducto = 1,
            idProveedor = 1,
            precio = 45000
        };
        this.iConexion.producto_proveedor!.Add(this.producto_proveedores!);
        this.iConexion.SaveChanges();

        if (this.producto_proveedores.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<producto_proveedor>(this.producto_proveedores!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (producto_proveedores!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.producto_proveedor!.Remove(this.producto_proveedores!);
        this.iConexion.SaveChanges();
    }
}
