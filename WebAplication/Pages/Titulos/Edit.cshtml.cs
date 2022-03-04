using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebAplication.Pages.Titulos
{
    public class EditModel : PageModel
    {
        private readonly ITitulosService tituloService;
        public EditModel(ITitulosService tituloService)
        {
            this.tituloService = tituloService;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public TitulosEntity Entity { get; set; } = new TitulosEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await tituloService.GetById(new() { Id_Titulo = id });
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
                if (Entity.Id_Titulo.HasValue)
                {
                    //Actualizar
                    var result = await tituloService.Update(Entity);

                    if (result.CodeError != 0)
                    {
                        throw new Exception(result.MsgError);
                    }

                    TempData["Msg"] = "El registro ha sido actualizado";
                }
                else
                {
                    //Nuevo Registro
                    var result = await tituloService.Create(Entity);

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


   