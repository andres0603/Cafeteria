
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class clientesModel : PageModel
    {
        private IclientesNegocio? IclientesNegocio;
        private IsedesNegocio? IsedesNegocio;
        [BindProperty] public List<clientes>? Lista { get; set; }
        [BindProperty] public List<sedes>? ListaSedes { get; set; }
        [BindProperty] public clientes? cliente { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public clientesModel()
        {
            IclientesNegocio = new ClientesNegocio();
            IsedesNegocio = new SedesNegocio();
        }

        public void OnPostBtNuevo()
        {
            ListaSedes = IsedesNegocio!.Consultar();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IclientesNegocio == null)
                    return;
                Lista = IclientesNegocio.Consultar();
                cliente = null;
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
                cliente = Lista!.FirstOrDefault(x => x.id == data);
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

                if (cliente == null)
                    return;
                if (cliente.id == 0)
                    cliente = IclientesNegocio!.Guardar(cliente!);
                else
                    cliente = IclientesNegocio!.Modificar(cliente!);
                if (cliente.id == 0)
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
                if(cliente==null) 
                    return;
                cliente = IclientesNegocio!.Borrar(cliente!);
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
                cliente = Lista!.FirstOrDefault(x => x.id == data);
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