using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly IClienteService cliente;
        public EditModel(IClienteService cliente)
        {
            this.cliente = cliente;
        }

        public IClienteService Servicio { get; }
       

        [BindProperty(SupportsGet = true)] //para que no se filtre los ids en los url y evitar robo
        public int? id { get; set; }  //el signo es par que el campo permita nulos en el caso que se vaya a hacer un insert

        [BindProperty] //protege todo
        public ClienteEntity Entity { get; set; } = new ClienteEntity(); //prop para guardar los datos de la entidad
        public IEnumerable<ClienteEntity> ClienteLista { get; set; } = new List<ClienteEntity>();
        //metodo edit
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await cliente.GETBYID(new()
                    {
                        IdCliente = id
                    });

                }

                ClienteLista = await cliente.GETLISTA();

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //metodo update insert
        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                //update
                if (Entity.IdCliente.HasValue) //si el idContacto tiene un valor (true) el metodo actuliza
                {
                    result = await cliente.UPDATE(Entity);



                }
                else //Si el idContacto no tiene valor (false) el metodo inserta
                {
                    result = await cliente.CREATE(Entity);
                    


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