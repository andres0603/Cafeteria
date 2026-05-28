
using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Lib_presentaciones.Configuraciones;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aplicacion_cafeteria.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Usuario { get; set; }
        [BindProperty] public string? Contraseña { get; set; }
        private IConexion? iConexion;
        private IsesionesNegocio? IsesionesNegocio;

        public IndexModel()
        {
            this.IsesionesNegocio = new SesionesNegocio();
        }
        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
            else
            {
                var sesionesActivas = this.iConexion!.sesiones!
            .Where(s => s.estado == true)
            .ToList();

                foreach (var sesion in sesionesActivas)
                {
                    sesion.estado = false;
                }

                this.iConexion.SaveChanges();
            }
        }

        public void OnPostBtClean()
        {
            try
            {
                Usuario = string.Empty;
                Contraseña = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void OnPostBtEnter()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            try
            {
                if (string.IsNullOrEmpty(Usuario) &&
                    string.IsNullOrEmpty(Contraseña))
                {
                    OnPostBtClean();
                    return;
                }

                // Llamar al API
                ViewData["Logged"] = true;
                HttpContext.Session.SetString("Usuario", Usuario!);
                EstaLogueado = true;
                var usuarioBD = this.iConexion!.usuarios!
                .FirstOrDefault(u => u.nombre == Usuario);

                if (usuarioBD == null)
                {
                    EstaLogueado=false;
                    return;
                }
                var sesion = new sesiones
                {
                    id_usuario = usuarioBD.id,
                    fecha_sesion = DateTime.Now,
                    estado = true
                };
                this.IsesionesNegocio!.Guardar(sesion);


            // ---- AGREGA ESTO ----
            var usuarioRol = this.iConexion.usuario_roles!
                .FirstOrDefault(ur => ur.id_usuario == usuarioBD.id);

            if (usuarioRol == null)
            {
                EstaLogueado = false;
                return;
            }

            HttpContext.Session.SetInt32("Rol", usuarioRol.id_rol);

            switch (usuarioRol.id_rol)
            {
                case Roles.Administrador:
                    Response.Redirect("/Ventanas/pedidos");
                    break;
                case Roles.Cajero:
                    Response.Redirect("/Ventanas/pedidos");
                    break;
                case Roles.Cliente:
                    Response.Redirect("/Ventanas/productos");
                    break;
            }

            OnPostBtClean();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

    

