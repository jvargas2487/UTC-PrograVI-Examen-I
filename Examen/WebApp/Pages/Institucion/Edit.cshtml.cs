using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Institucion
{
    public class EditModel : PageModel
    {
        public string Mensaje { get; set; } = string.Empty;
        public string TitlePage { get; set; } = string.Empty;
        public bool IsEdit { get; set; } = false;

        private readonly IInstitucionService institucion;
        public InstitucionEntity InstitucionEntity { get; set; } = new InstitucionEntity();

        public EditModel(IInstitucionService institucion)
        {
            this.institucion = institucion;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            try
            {
                IsEdit = id != null;
                TitlePage = id == null ? "Crear Institución" : "Editar Institución";

                if (id != null) 
                { 
                    InstitucionEntity = await institucion.GetById(new InstitucionEntity { Id_Institucion = id });
                    if (InstitucionEntity == null) return Redirect("Grid");
                }

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

        public async Task<IActionResult> OnPostAsync(int? id, InstitucionEntity institucionEntity)
        {
            try
            {
                DBEntity result;

                if (id == null) { result = await institucion.Create(institucionEntity); }
                else
                {
                    institucionEntity.Id_Institucion = id;
                    result = await institucion.Update(institucionEntity);
                }

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData["Msg"] = "El registro fue guardado correctamente";

                return Redirect($"Edit?id={id}");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
