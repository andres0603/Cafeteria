using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class proveedoresUnitaria
{
    private IConexion? iConexion;
    private proveedores? proveedor;

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
        var lista = iConexion.proveedores!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.proveedor = new proveedores()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            nit = "800.123.456-1",
            direccion = "Vereda La Palma, Quindío",
            telefono = "3104445566",
            activo = true
        };
        this.iConexion.proveedores!.Add(this.proveedor!);
        this.iConexion.SaveChanges();

        if (this.proveedor.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<proveedores>(this.proveedor!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (proveedor!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.proveedores!.Remove(this.proveedor!);
        this.iConexion.SaveChanges();
    }
}
