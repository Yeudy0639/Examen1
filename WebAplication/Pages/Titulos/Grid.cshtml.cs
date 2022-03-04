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
    public class GridModel : PageModel
    {
        private readonly ITitulosService tituloService;

        public GridModel(ITitulosService tituloService)
        {
            this.tituloService = tituloService;
        }


        public IEnumerable<TitulosEntity> GridList { get; set; } = new List<TitulosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await tituloService.Get();

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

        public async Task<IActionResult> OnGetELiminar(int id)
        {
            try
            {

                var result = await tituloService.Delete(new()
                {

                    Id_Titulo = id
                });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El registro ha sido eliminado";

                return Redirect("Grid");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }

    }
}

