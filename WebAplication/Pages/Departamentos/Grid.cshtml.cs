using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebAplication.Pages.Departamentos
{
    public class GridModel : PageModel
    {
        private readonly IDepartamentosService departamentoService;

        public GridModel(IDepartamentosService departamentoService)
        {
            this.departamentoService = departamentoService;
        }


        public IEnumerable<DepartamentosEntity> GridList { get; set; } = new List<DepartamentosEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await departamentoService.Get();

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

                var result = await departamentoService.Delete(new()
                {

                    Id_Departamento = id
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

