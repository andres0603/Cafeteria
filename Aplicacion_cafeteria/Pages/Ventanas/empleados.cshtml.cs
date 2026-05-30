
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
            var usuario = HttpContext.Session.GetString("Usuario");
            ListaRoles = IrolesNegocio!.Consultar(usuario!);
            ListaHorarios = IhorariosNegocio!.Consultar(usuario!)
                            .Select(x => new {
                            id = x.id,
                            dia = $"{x.dia} {x.horaEntrada} - {x.horaSalida}"
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
                var usuario = HttpContext.Session.GetString("Usuario");
                if (IempleadosNegocio == null)
                    return;
                Lista = IempleadosNegocio.Consultar(usuario!);
                ListaRoles = IrolesNegocio!.Consultar(usuario!);
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
                OnPostBtNuevo();
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
                var usuario = HttpContext.Session.GetString("Usuario");
                if (empleado == null)
                    return;
                if (empleado.id == 0)
                    empleado = IempleadosNegocio!.Guardar(empleado!, usuario!);
                else
                    empleado = IempleadosNegocio!.Modificar(empleado!, usuario!);
                if (empleado.id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (empleado == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                empleado = IempleadosNegocio!.Borrar(empleado!, usuario!);
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