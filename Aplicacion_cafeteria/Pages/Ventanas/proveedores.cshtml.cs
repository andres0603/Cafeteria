
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class proveedoresModel : PageModel
    {
        private IproveedoresNegocio? IproveedoresNegocio;
        [BindProperty] public List<proveedores>? Lista { get; set; }
        [BindProperty] public proveedores? proveedor { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public proveedoresModel()
        {
            IproveedoresNegocio = new ProveedoresNegocio();
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
                if (IproveedoresNegocio == null)
                    return;
                Lista = IproveedoresNegocio.Consultar();
                proveedor = null;
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
                proveedor = Lista!.FirstOrDefault(x => x.id == data);
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

                if (proveedor == null)
                    return;
                if (proveedor.id == 0)
                    proveedor = IproveedoresNegocio!.Guardar(proveedor!);
                else
                    proveedor = IproveedoresNegocio!.Modificar(proveedor!);
                if (proveedor.id == 0)
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
                if (proveedor == null)
                    return;
                proveedor = IproveedoresNegocio!.Borrar(proveedor!);
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
                proveedor = Lista!.FirstOrDefault(x => x.id == data);
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