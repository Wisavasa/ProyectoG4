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
    public class EditorTrabajadorModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        private readonly IRepositorioTrabajador _repoTrabajador;
        private readonly IRepositorioCargo _repoCargo;
        [BindProperty]
        public Trabajador trabajador { get; set; }
        public Cargo cargo { get; set; }
        public Logging logging { get; set; }
        public IEnumerable<Cargo> listaCargo { get; set; }

        public EditorTrabajadorModel()
        {
            this._repoTrabajador = new RepositorioTrabajador(new Persistencia.AppContext());
            this._repoCargo = new RepositorioCargo(new Persistencia.AppContext());
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? TrabajadorId,int? Super)
        {
            listaCargo = _repoCargo.GetAllCargos();
            if(TrabajadorId.HasValue){
                trabajador = _repoTrabajador.GetTrabajador(TrabajadorId.Value);
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

        public IActionResult OnPost(Trabajador trabajador, int cargoId, int Super)
        {
            if (ModelState.IsValid)
            {
                cargo = _repoCargo.GetCargo(cargoId);
                logging = _repoLogging.GetLogging(Super);
            
                if (trabajador.Id > 0)
                {
                    trabajador.Cargo = cargo;
                    trabajador = _repoTrabajador.UpdateTrabajador(trabajador);
                }
                TempData["success"]="Trabajador Editado Correctamente";
                return RedirectToPage("./EditarTrabajador", new { Super = logging.Id});
            }
            else {
                return Page();
            }

        }
    }
}
