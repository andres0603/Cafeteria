
using lib_cafeteria.modelos;
using Lib_presentaciones.implementaciones;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class productosModel : PageModel
    {
        private IproductosNegocio? IproductosNegocio;
        private IcategoriasNegocio? IcategoriasNegocio;
        private readonly IWebHostEnvironment _env;
        public string? imagenUrl { get; set; }
        [BindProperty] public List<productos>? Lista { get; set; }
        [BindProperty] public List<categorias>? ListaCategorias { get; set; }
        [BindProperty] public productos? producto { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public IFormFile? ImagenArchivo { get; set; }


        public productosModel(IWebHostEnvironment env)
        {
            IproductosNegocio = new ProductosNegocio();
            IcategoriasNegocio = new CategoriasNegocio();
            _env = env;
        }

        public void OnPostBtNuevo()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            ListaCategorias = IcategoriasNegocio!.Consultar(usuario!);
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IproductosNegocio == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                Lista = IproductosNegocio.Consultar(usuario!);
                producto = null;
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
                producto = Lista!.FirstOrDefault(x => x.id == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public async Task OnPostBtGuardar()
        {
            try
            {
                if (ImagenArchivo != null &&
                    ImagenArchivo.Length > 0 &&
                    !string.IsNullOrEmpty(ImagenArchivo.FileName))
                {
                    var carpeta = Path.Combine(_env.WebRootPath, "Imagenes");

                    // Crear carpeta si no existe
                    if (!Directory.Exists(carpeta))
                    {
                        Directory.CreateDirectory(carpeta);
                    }

                    var extension = Path.GetExtension(ImagenArchivo.FileName);
                    var nombreArchivo = $"{Guid.NewGuid()}{extension}";
                    var rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                    using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                    {
                        await ImagenArchivo.CopyToAsync(stream);
                    }

                    producto!.imageUrl = "/Imagenes/" + nombreArchivo;
                }

                var usuario = HttpContext.Session.GetString("Usuario");

                if (producto == null)
                    return;

                if (producto.id == 0)
                    producto = IproductosNegocio!.Guardar(producto, usuario!);
                else
                    producto = IproductosNegocio!.Modificar(producto, usuario!);

                if (producto.id == 0)
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
                if (producto == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                producto = IproductosNegocio!.Borrar(producto!,usuario!);
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
                producto = Lista!.FirstOrDefault(x => x.id == data);
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