using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class producto_ExtraUnitaria
{
    private IConexion? iConexion;
    private producto_Extra? producto_Extras;

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
        var lista = iConexion.producto_Extra!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.producto_Extras = new producto_Extra()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            cantidad = 20,
            precioAdicional = 2500,
            activo = true
        };
        this.iConexion.producto_Extra!.Add(this.producto_Extras!);
        this.iConexion.SaveChanges();

        if (this.producto_Extras.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<producto_Extra>(this.producto_Extras!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (producto_Extras!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.producto_Extra!.Remove(this.producto_Extras!);
        this.iConexion.SaveChanges();
    }
}
