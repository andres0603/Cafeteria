
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
        [BindProperty] public List<productos>? Lista { get; set; }
        [BindProperty] public List<categorias>? ListaCategorias { get; set; }
        [BindProperty] public productos? producto { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public productosModel()
        {
            IproductosNegocio = new ProductosNegocio();
            IcategoriasNegocio = new CategoriasNegocio();
        }

        public void OnPostBtNuevo()
        {
            ListaCategorias = IcategoriasNegocio!.Consultar();
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
                Lista = IproductosNegocio.Consultar();
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

        public void OnPostBtGuardar()
        {
            try
            {

                if (producto == null)
                    return;
                if (producto.id == 0)
                    producto = IproductosNegocio!.Guardar(producto!);
                else
                    producto = IproductosNegocio!.Modificar(producto!);
                if (producto.id == 0)
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
                if (producto == null)
                    return;
                producto = IproductosNegocio!.Borrar(producto!);
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