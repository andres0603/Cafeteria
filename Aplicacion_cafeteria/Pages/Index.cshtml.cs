
using lib_cafeteria.implementaciones;
using lib_cafeteria.interfaces;
using lib_cafeteria.modelos;
using lib_cafeteria.nucleo;
using Lib_presentaciones.Configuraciones;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

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
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        public void OnPostBtEnter()
        {
            // 1. Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Contraseña))
            {
                ModelState.AddModelError(string.Empty, "Por favor ingresa usuario y contraseña.");
                return;
            }

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            try
            {
                // 2. Buscar el usuario en la BD
                var usuarioBD = this.iConexion!.usuarios!
                    .FirstOrDefault(u => u.nombre == Usuario);

                // 3. Validar que existe Y que la contraseña es correcta
                if (usuarioBD == null || usuarioBD.contraseña != Contraseña)
                {
                    ModelState.AddModelError(string.Empty, "Credenciales incorrectas.");
                    return;
                }

                // 4. Validar que tenga rol asignado
                var usuarioRol = this.iConexion.usuario_roles!
                    .FirstOrDefault(ur => ur.id_usuario == usuarioBD.id);

                if (usuarioRol == null)
                {
                    ModelState.AddModelError(string.Empty, "El usuario no tiene un rol asignado.");
                    return;
                }

                // 5. Todo correcto — guardar sesión
                var sesion = new sesiones
                {
                    id_usuario = usuarioBD.id,
                    fecha_sesion = DateTime.Now,
                    estado = true
                };
                this.IsesionesNegocio!.Guardar(sesion, Usuario!);

                HttpContext.Session.SetString("Usuario", Usuario!);
                HttpContext.Session.SetInt32("Rol", usuarioRol.id_rol);
                EstaLogueado = true;
                OnPostBtClean();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error inesperado: {ex.Message}");
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
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }
    }
}

    

