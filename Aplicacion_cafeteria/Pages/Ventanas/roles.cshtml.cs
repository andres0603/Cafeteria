
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class rolesModel : PageModel
    {
        private IrolesNegocio? IrolesNegocio;
        [BindProperty] public List<roles>? Lista { get; set; }
        [BindProperty] public roles? rol { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public rolesModel()
        {
            IrolesNegocio = new RolesNegocio();
        }

        public void OnPostBtNuevo()
        {
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IrolesNegocio == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                Lista = IrolesNegocio.Consultar(usuario!);
                rol = null;
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
                rol = Lista!.FirstOrDefault(x => x.id == data);
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
                if (rol == null)
                    return;
                if (rol.id == 0)
                    rol = IrolesNegocio!.Guardar(rol!, usuario!);
                else
                    rol = IrolesNegocio!.Modificar(rol!, usuario!);
                if (rol.id == 0)
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
                if (rol == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                rol = IrolesNegocio!.Borrar(rol!, usuario!);
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
                rol = Lista!.FirstOrDefault(x => x.id == data);
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