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
    public class GridModel : PageModel
    {
        private readonly IPuestosService puestoService;

        public GridModel(IPuestosService puestoService)
        {
            this.puestoService = puestoService;
        }


        public IEnumerable<PuestosEntity> GridList { get; set; } = new List<PuestosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await puestoService.Get();

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

                var result = await puestoService.Delete(new()
                {

                    Id_Puesto = id
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

