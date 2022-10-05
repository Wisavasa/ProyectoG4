using System;
using System.Collections.Generic;
using System.Linq;
using GestorRH.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.App.Persistencia
{
    public class RepositorioCargo : IRepositorioCargo
    {
        /// <summary>
        /// Referencia al contexto de Cargo
        /// </summary>

        private readonly AppContext _appContext;
       
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioCargo(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Cargo AddCargo(Cargo cargo)
        {
            var cargoAdicionado = _appContext.Cargos.Add(cargo);
            _appContext.SaveChanges();
            return cargoAdicionado.Entity;
        }

        public void DeleteCargo(int idCargo)
        {
            var cargoEncontrado = _appContext.Cargos.FirstOrDefault(d => d.Id == idCargo);
            if (cargoEncontrado == null)
                return;
            _appContext.Cargos.Remove(cargoEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Cargo> GetAllCargos()
        {
            return  _appContext.Cargos;
        }

        public IEnumerable<Cargo> GetCargosPorFiltro(string filtro)
        {
            var cargos = GetAllCargos(); // Obtiene todos los saludos
            if (cargos != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    cargos = cargos.Where(s => s.NombreCargo.Contains(filtro));
                }
            }
            return cargos;
        }

       
        public Cargo GetCargo(int idCargo)
        {
            return _appContext.Cargos.FirstOrDefault(d => d.Id == idCargo);
        }

        public Cargo UpdateCargo(Cargo cargo)
        {
            var cargoEncontrado = _appContext.Cargos.FirstOrDefault(d => d.Id == cargo.Id);
            if (cargoEncontrado != null)
            {
                cargoEncontrado.NombreCargo = cargo.NombreCargo;                
                cargoEncontrado.Profesion = cargo.Profesion;
                cargoEncontrado.Salario = cargo.Salario;
                cargoEncontrado.FechaIngreso = cargo.FechaIngreso;
                cargoEncontrado.FechaEgreso = cargo.FechaEgreso;
                _appContext.SaveChanges();
            }
            return cargoEncontrado;
        }     
    }
}