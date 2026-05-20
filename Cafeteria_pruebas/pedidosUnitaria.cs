using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class pedidosUnitaria
{
    private IConexion? iConexion;
    private pedidos? pedido;

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
        var lista = iConexion.pedidos!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.pedido = new pedidos()
        {
            notasParaCocina = "UT-" + DateTime.Now,
            clientes = 1,
            estadosPedido = 1,
            total = 7000m, 
        };
        this.iConexion.pedidos!.Add(this.pedido!);
        this.iConexion.SaveChanges();

        if (this.pedido.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<pedidos>(this.pedido!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (pedido!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.pedidos!.Remove(this.pedido!);
        this.iConexion.SaveChanges();
    }
}
