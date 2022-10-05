using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestorRH.App.Dominio;
using GestorRH.App.Persistencia;

namespace GestorRH.App.Frontend.Pages
{
    public class EditorCargosModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        private readonly IRepositorioCargo _repoCargos;
        [BindProperty]
        public Cargo cargos { get; set; }
        public Logging logging { get; set; }

        public EditorCargosModel()
        {
            this._repoCargos = new RepositorioCargo(new Persistencia.AppContext());
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? cargosId,int? Super)
        {
            if(cargosId.HasValue){
                cargos = _repoCargos.GetCargo(cargosId.Value);
            }
            if (Super.HasValue)
            {
                logging = _repoLogging.GetLogging(Super.Value);
                return Page();
            }else{
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public IActionResult OnPost(Cargo cargos, int Super)
        {
            if (ModelState.IsValid)
            {
                logging = _repoLogging.GetLogging(Super);
                cargos = _repoCargos.UpdateCargo(cargos);                
                TempData["success"]="Cargo Editado Correctamente";
                return RedirectToPage("./EditarCargos", new { Super = logging.Id});
            }
            else {
                return Page();
            }

        }
    }
}
