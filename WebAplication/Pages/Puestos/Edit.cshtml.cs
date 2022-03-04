using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebAplication.Pages.Puestos
{
    public class EditModel : PageModel
    {
        private readonly IPuestosService puestoService;
        public EditModel(IPuestosService puestoService)
        {
            this.puestoService = puestoService;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public PuestosEntity Entity { get; set; } = new PuestosEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await puestoService.GetById(new() { Id_Puesto = id });
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
                if (Entity.Id_Puesto.HasValue)
                {
                    //Actualizar
                    var result = await puestoService.Update(Entity);

                    if (result.CodeError != 0)
                    {
                        throw new Exception(result.MsgError);
                    }

                    TempData["Msg"] = "El registro ha sido actualizado";
                }
                else
                {
                    //Nuevo Registro
                    var result = await puestoService.Create(Entity);

                    if (result.CodeError != 0)
                    {
                        throw new Exception(result.MsgError);
                    }

                    TempData["Msg"] = "El registro ha sido ingresado";

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

