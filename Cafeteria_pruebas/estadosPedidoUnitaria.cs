using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class estadosPedidoUnitaria
{
    private IConexion? iConexion;
    private estadosPedido? estadoPedido;

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
        var lista = iConexion.estadosPedido!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.estadoPedido = new estadosPedido()
        {
            nombre = "UT-" + DateTime.Now.ToString(),
            Capacidad = 253,
            Motor = "9000cc",
            Marca = "Airbus",
            Modelo = "S526",
            Estado = true,
        };
        this.iConexion.estadosPedido!.Add(this.estadoPedido!);
        this.iConexion.SaveChanges();

        if (this.estadoPedido.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<estadosPedido>(this.estadoPedido!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (estadoPedido!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.estadosPedido!.Remove(this.estadoPedido!);
        this.iConexion.SaveChanges();
    }
}
