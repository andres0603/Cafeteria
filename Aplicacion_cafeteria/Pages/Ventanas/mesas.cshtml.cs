
using lib_cafeteria.modelos;
using Lib_presentaciones.Implementaciones;
using Lib_presentaciones.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion_cafeteria.Pages
{
    public class mesasModel : PageModel
    {
        private ImesasNegocio? ImesasNegocio;
        private IestadoMesaNegocio? IestadoMesaNegocio;
        private IsedesNegocio? IsedesNegocio;
        [BindProperty] public List<mesas>? Lista { get; set; }
        [BindProperty] public List<estadosMesa>? ListaEstadosMesa { get; set; }
        [BindProperty] public List<sedes>? ListaSedes { get; set; }
        [BindProperty] public mesas? mesa { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public mesasModel()
        {
            ImesasNegocio = new MesasNegocio();
            IestadoMesaNegocio = new EstadoMesaNegocio();
            IsedesNegocio = new SedesNegocio();
        }

        public void OnPostBtNuevo()
        {
            var usuario = HttpContext.Session.GetString("Usuario");
            ListaEstadosMesa = IestadoMesaNegocio!.Consultar(usuario!);
            ListaSedes = IsedesNegocio!.Consultar(usuario!);
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
                if (ImesasNegocio == null)
                    return;
                Lista = ImesasNegocio.Consultar(usuario!);
                mesa = null;
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
                mesa = Lista!.FirstOrDefault(x => x.id == data);
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
                if (mesa == null)
                    return;
                if (mesa.id == 0)
                    mesa = ImesasNegocio!.Guardar(mesa!, usuario!);
                else
                    mesa = ImesasNegocio!.Modificar(mesa!, usuario!);
                if (mesa.id == 0)
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
                var usuario = HttpContext.Session.GetString("Usuario");
                if (mesa == null)
                    return;
                mesa = ImesasNegocio!.Borrar(mesa!,usuario!);
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
                mesa = Lista!.FirstOrDefault(x => x.id == data);
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