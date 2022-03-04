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
    public class EditModel : PageModel
    {
        private readonly IDepartamentosService departamentoService;
        public EditModel(IDepartamentosService departamentoService)
        {
            this.departamentoService = departamentoService;
        }


        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        public DepartamentosEntity Entity { get; set; } = new DepartamentosEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await departamentoService.GetById(new() { Id_Departamento = id });
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
                if (Entity.Id_Departamento.HasValue)
                {
                    //Actualizar
                    var result = await departamentoService.Update(Entity);

                    if (result.CodeError != 0)
                    {
                        throw new Exception(result.MsgError);
                    }

                    TempData["Msg"] = "El registro ha sido actualizado";
                }
                else
                {
                    //Nuevo Registro
                    var result = await departamentoService.Create(Entity);

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

