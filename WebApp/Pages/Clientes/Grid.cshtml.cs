using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Clientes
{
    public class GridModel : PageModel
    {
        private readonly IClienteService cliente;
        public GridModel(IClienteService cliente)
        {
            this.cliente = cliente;
        }
        public IEnumerable<ClienteEntity> GridList { get; set; } = new List<ClienteEntity>();

        public string Mensaje { get; set; } = "";
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await cliente.GET();

                if (TempData.ContainsKey("Msg"))
                {
                    Mensaje = TempData["Msg"] as string;
                }

                TempData.Clear();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await cliente.DELETE(new()
                { IdCliente = id });

                if (result.CodError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El cliente fue eliminado satisfactoriamente";

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
