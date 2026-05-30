
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class usuario_rolesModel : PageModel
    {
        private Iusuario_rolesNegocio? Iusuario_rolesNegocio;
        private IusuariosNegocio? IusuariosNegocio;
        private IrolesNegocio? IrolesNegocio;
        [BindProperty] public List<usuario_roles>? Lista { get; set; }
        [BindProperty] public List<roles>? ListaRoles { get; set; }
        [BindProperty] public List<usuarios>? ListaUsuarios { get; set; }
        [BindProperty] public usuario_roles? usuario_rol { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public usuario_rolesModel()
        {
            Iusuario_rolesNegocio = new Usuario_rolesNegocio();
            IrolesNegocio = new RolesNegocio();
            IusuariosNegocio = new UsuariosNegocio();
        }

        public void OnPostBtNuevo()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            ListaRoles = IrolesNegocio!.Consultar(usuario!);
            ListaUsuarios = IusuariosNegocio!.Consultar(usuario!);
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
                if (Iusuario_rolesNegocio == null)
                    return;
                Lista = Iusuario_rolesNegocio.Consultar(usuario!);
                ListaRoles = IrolesNegocio!.Consultar(usuario!);
                usuario_rol = null;
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
                usuario_rol = Lista!.FirstOrDefault(x => x.id == data);
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
                if (usuario_rol == null)
                    return;
                if (usuario_rol.id == 0)
                    usuario_rol = Iusuario_rolesNegocio!.Guardar(usuario_rol!,usuario!);
                else
                    usuario_rol = Iusuario_rolesNegocio!.Modificar(usuario_rol!,usuario!);
                if (usuario_rol.id == 0)
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
                usuario_rol = Lista!.FirstOrDefault(x => x.id == data);
                if (usuario_rol == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                usuario_rol = Iusuario_rolesNegocio!.Borrar(usuario_rol!,usuario!);
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
                usuario_rol = Lista!.FirstOrDefault(x => x.id == data);
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