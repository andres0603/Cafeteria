
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class empleadosModel : PageModel
    {
        private IempleadosNegocio? IempleadosNegocio;
        private IrolesNegocio? IrolesNegocio;
        private IhorariosNegocio? IhorariosNegocio;
        [BindProperty] public List<empleados>? Lista { get; set; }
        [BindProperty] public List<roles>? ListaRoles { get; set; }
        [BindProperty] public List<dynamic>? ListaHorarios { get; set; }
        [BindProperty] public empleados? empleado { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public empleadosModel()
        {
            IempleadosNegocio = new EmpleadosNegocio();
            IrolesNegocio = new RolesNegocio();
            IhorariosNegocio = new HorariosNegocio();
        }

        public void OnPostBtNuevo()
        {
            ListaRoles = IrolesNegocio!.Consultar();
            ListaHorarios = IhorariosNegocio!.Consultar()
                .Select(x => new { 
                id= x.id,
                dia= $"{x.dia} {x.horaEntrada} - {x.horaSalida}"
                })
                .ToList<dynamic>();
                
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IempleadosNegocio == null)
                    return;
                Lista = IempleadosNegocio.Consultar();
                empleado = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                empleado = Lista!.FirstOrDefault(x => x.id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {

                if (empleado == null)
                    return;
                if (empleado.id == 0)
                    empleado = IempleadosNegocio!.Guardar(empleado!);
                else
                    empleado = IempleadosNegocio!.Modificar(empleado!);
                if (empleado.id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar(int data)
        {
            try
            {
                empleado = Lista!.FirstOrDefault(x => x.id == data);
                if (empleado == null)
                    return;
                empleado = IempleadosNegocio!.Borrar(empleado!);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                empleado = Lista!.FirstOrDefault(x => x.id == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }

    }
}