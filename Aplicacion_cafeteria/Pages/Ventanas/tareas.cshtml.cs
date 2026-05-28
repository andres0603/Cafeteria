
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class tareasModel : PageModel
    {
        private ItareasNegocio? ItareasNegocio;
        private IempleadosNegocio? IempleadosNegocio;
        [BindProperty] public List<tareas>? Lista { get; set; }
        [BindProperty] public List<empleados>? ListaEmpleados { get; set; }
        [BindProperty] public tareas? tarea { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public tareasModel()
        {
            ItareasNegocio = new TareasNegocio();
            IempleadosNegocio = new EmpleadosNegocio(); 
        }

        public void OnPostBtNuevo()
        {
            ListaEmpleados = IempleadosNegocio!.Consultar();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (ItareasNegocio == null)
                    return;
                Lista = ItareasNegocio.Consultar();
                tarea = null;
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
                tarea = Lista!.FirstOrDefault(x => x.id == data);
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

                if (tarea == null)
                    return;
                if (tarea.id == 0)
                    tarea = ItareasNegocio!.Guardar(tarea!);
                else
                    tarea = ItareasNegocio!.Modificar(tarea!);
                if (tarea.id == 0)
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
                if (tarea == null)
                    return;
                tarea = ItareasNegocio!.Borrar(tarea!);
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
                tarea = Lista!.FirstOrDefault(x => x.id == data);
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