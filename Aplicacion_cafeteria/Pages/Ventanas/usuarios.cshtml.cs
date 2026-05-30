
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class usuariosModel : PageModel
    {
        private IusuariosNegocio? IusuariosNegocio;
        [BindProperty] public List<usuarios>? Lista { get; set; }
        [BindProperty] public usuarios? usuario { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public usuariosModel()
        {
            IusuariosNegocio = new UsuariosNegocio();
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
                if (IusuariosNegocio == null)
                    return;
                var usuarioI = HttpContext.Session.GetString("Usuario");
                Lista = IusuariosNegocio.Consultar(usuarioI!);
                usuario = null;
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
                usuario = Lista!.FirstOrDefault(x => x.id == data);
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
                var usuarioI = HttpContext.Session.GetString("Usuario");
                if (usuario == null)
                    return;
                if (usuario.id == 0)
                    usuario = IusuariosNegocio!.Guardar(usuario!, usuarioI!);
                else
                    usuario = IusuariosNegocio!.Modificar(usuario!, usuarioI!);
                if (usuario.id == 0)
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
                
                if (usuario == null)
                    return;
                var usuarioI = HttpContext.Session.GetString("Usuario");
                usuario = IusuariosNegocio!.Borrar(usuario!,usuarioI!);
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
                usuario = Lista!.FirstOrDefault(x => x.id == data);
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