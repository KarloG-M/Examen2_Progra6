using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Solicitud
{
    public class EditModel : PageModel
    {
        private readonly ISolicitudService solicitud;
        private readonly IClienteService cliente;
        private readonly IServicioService servicio;

        public EditModel(ISolicitudService solicitud, IClienteService cliente, IServicioService servicio)
        {
            this.solicitud = solicitud;
            this.cliente = cliente;
            this.servicio = servicio;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public SolicitudEntity Entity { get; set; } = new SolicitudEntity();
        public IEnumerable<ClienteEntity> ClienteLista { get; set; } = new List<ClienteEntity>();
        public IEnumerable<ServicioEntity> ServicioLista { get; set; } = new List<ServicioEntity>();
        public IClienteService Cliente { get; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await solicitud.GETBYID(new()
                    {
                        IdSolicitud = id
                    });
                }
                    ClienteLista = await cliente.GETLISTA();
                    ServicioLista = await servicio.GETLISTA();
                

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                if (Entity.IdSolicitud.HasValue)
                {
                    result = await solicitud.UPDATE(Entity);

                 
                }
                else //Insertar
                {
                     result = await solicitud.CREATE(Entity);

                   

                }


                return new JsonResult(result);

            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodError = ex.HResult, MsgError = ex.Message });
            }

        }


    }
}
