using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;
namespace WebApp.Pages.Servicios
{
    public class EditModel : PageModel
    {
        private readonly IServicioService servicio;

        public EditModel(IServicioService servicio)
        {
            
            this.servicio = servicio;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public ServicioEntity Entity { get; set; } = new ServicioEntity();
        public IServicioService Servicio { get; }

        public async Task<IActionResult> OnGet()
        {

            try
            {
                if (id.HasValue)
                {

                    Entity = await servicio.GETBYID(new()
                    {
                        IdServicio = id
                    });
                }


                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Entity.IdServicio.HasValue)
                {
                    var result = await servicio.UPDATE(Entity);

                    if (result.CodError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se actualizó correctamente";
                }
                else //Insertar}
                {
                    var result = await servicio.CREATE(Entity);

                    if (result.CodError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se agregó correctamente";

                }


                return RedirectToPage("Grid");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }


    }
}
