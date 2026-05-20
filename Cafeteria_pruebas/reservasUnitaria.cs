using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria_pruebas;

[TestClass]
public class reservasUnitaria
{
    private IConexion? iConexion;
    private reservas? reserva;

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
        var lista = iConexion.reservas!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.reserva = new reservas()
        {
            fechaHoraReserva = new DateTime(2026, 03, 14, 19, 30, 00),
            numeroPersonas = 2,
            requerimientosEspeciales = "UT-" + DateTime.Now,
            estadoReserva = 1,
            clientes = 1
        };
        this.iConexion.reservas!.Add(this.reserva!);
        this.iConexion.SaveChanges();

        if (this.reserva.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<reservas>(this.reserva!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (reserva!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.reservas!.Remove(this.reserva!);
        this.iConexion.SaveChanges();
    }
}
