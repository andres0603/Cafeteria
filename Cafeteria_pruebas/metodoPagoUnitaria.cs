using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cafeteria_pruebas;

[TestClass]
public class metodoPagoUnitaria
{
    private IConexion? iConexion;
    private metodoPago? metodoPagos;

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
        var lista = iConexion.metodoPago!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.metodoPagos = new metodoPago()
        {
            metodo = "UT-" + DateTime.Now.ToString(),
            comisionPorcentual = 10.0m,
            requiereCodigo = false,
            referenciaAprobacion = "N/A",
            activo=true
             
        };
        this.iConexion.metodoPago!.Add(this.metodoPagos!);
        this.iConexion.SaveChanges();

        if (this.metodoPagos.id != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


        var entry = this.iConexion!.Entry<metodoPago>(this.metodoPagos!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (metodoPagos!.id != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.metodoPago!.Remove(this.metodoPagos!);
        this.iConexion.SaveChanges();
    }
}
