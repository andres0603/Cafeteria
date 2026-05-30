
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aplicacion_cafeteria.Pages
{
    public class producto_proveedorModel : PageModel
    {
        private Iproducto_proveedorNegocio? Iproducto_proveedorNegocio;
        private IproveedoresNegocio? IproveedoresNegocio;
        private IproductosNegocio? IproductosNegocio;
        [BindProperty] public List<producto_proveedor>? Lista { get; set; }
        [BindProperty] public List<productos>? ListaProductos { get; set; }
        [BindProperty] public List<proveedores>? ListaProveedores { get; set; }
        [BindProperty] public producto_proveedor? producto_proveedor { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public producto_proveedorModel()
        {
            Iproducto_proveedorNegocio = new Producto_proveedorNegocio();
            IproductosNegocio = new ProductosNegocio();
            IproveedoresNegocio = new ProveedoresNegocio();
        }

        public void OnPostBtNuevo()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            ListaProveedores = IproveedoresNegocio!.Consultar(usuario!);
            ListaProductos = IproductosNegocio!.Consultar(usuario!);
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
                if (Iproducto_proveedorNegocio == null)
                    return;
                Lista = Iproducto_proveedorNegocio.Consultar(usuario!);
                producto_proveedor = null;
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
                producto_proveedor = Lista!.FirstOrDefault(x => x.id == data);
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
                if (producto_proveedor == null)
                    return;
                if (producto_proveedor.id == 0)
                    producto_proveedor = Iproducto_proveedorNegocio!.Guardar(producto_proveedor!, usuario!);
                else
                    producto_proveedor = Iproducto_proveedorNegocio!.Modificar(producto_proveedor!,usuario!);
                if (producto_proveedor.id == 0)
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
                if (producto_proveedor == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");
                producto_proveedor = Iproducto_proveedorNegocio!.Borrar(producto_proveedor!, usuario!);
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
                producto_proveedor = Lista!.FirstOrDefault(x => x.id == data);
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