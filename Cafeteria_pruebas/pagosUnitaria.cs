using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class pagosUnitaria
{
    private IConexion? iConexion;
    private pagos? pago;

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
        var lista = iConexion.pagos!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.pago = new pagos()
        {
            montoPagado = 30000,
            propina = 5000,
            metodoPago = 1,
            pedido = 1,
            devuelta = 18000
        };
        this.iConexion.pagos!.Add(this.pago!);
        this.iConexion.SaveChanges();

        if (this.pago.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<pagos>(this.pago!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (pago!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.pagos!.Remove(this.pago!);
        this.iConexion.SaveChanges();
    }
}
