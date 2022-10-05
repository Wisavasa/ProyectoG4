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
    public class CrearTrabajadorModel : PageModel
    {
        private readonly IRepositorioLogging _repoLogging;
        private readonly IRepositorioTrabajador _repoTrabajador;
        private readonly IRepositorioCargo _repoCargo;
        [BindProperty]
        public Trabajador trabajador { get; set; }
        public Cargo cargo { get; set; }
        public IEnumerable<Cargo> listaCargo { get; set; }
        public Logging logging { get; set; }

        public CrearTrabajadorModel()
        {
            this._repoTrabajador = new RepositorioTrabajador(new Persistencia.AppContext());
            this._repoCargo = new RepositorioCargo(new Persistencia.AppContext());
            this._repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? Super)
        {
            listaCargo = _repoCargo.GetAllCargos();
            trabajador = new Trabajador();
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
            if (!ModelState.IsValid)
            {
                return Page();
            }else{ 
                if (cargoId==null){
                TempData["success"]="Debes crear un cargo primero";
                   return RedirectToPage("./ListaTrabajadores"); 
                }
                if (cargoId==0){
                    logging = _repoLogging.GetLogging(Super);
                    trabajador=_repoTrabajador.AddTrabajador(trabajador);
                    _repoTrabajador.AsignarCargo(trabajador.Id,1);
                    TempData["success"]="Trabajador sin Cargo Creado Correctamente"; 
                    return RedirectToPage("./ListaTrabajadores",new { Super = logging.Id});
                } 
                else{
                    logging = _repoLogging.GetLogging(Super);
                    cargo = _repoCargo.GetCargo(cargoId);          
                    trabajador=_repoTrabajador.AddTrabajador(trabajador);
                    _repoTrabajador.AsignarCargo(trabajador.Id,cargo.Id);
                }
                TempData["success"]="Trabajador Creado y Cargo Asignado Correctamente";  
                return RedirectToPage("./ListaTrabajadores",new { Super = logging.Id});
            }              
            return Page();
        }


        
    }
}
