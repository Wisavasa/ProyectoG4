using System;
using System.Collections.Generic;
using System.Linq;
using GestorRH.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.App.Persistencia
{
    public class RepositorioTrabajador : IRepositorioTrabajador
    {
        /// <summary>
        /// Referencia al contexto de Trabajador
        /// </summary>

        private readonly AppContext _appContext;
       
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioTrabajador(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Trabajador AddTrabajador(Trabajador trabajador)
        {
            var trabajadorAdicionado = _appContext.Trabajadores.Add(trabajador);
            _appContext.SaveChanges();
            return trabajadorAdicionado.Entity;
        }

        public void DeleteTrabajador(int idTrabajador)
        {
            var trabajadorEncontrado = _appContext.Trabajadores.FirstOrDefault(d => d.Id == idTrabajador);
            if (trabajadorEncontrado == null)
                return;
            _appContext.Trabajadores.Remove(trabajadorEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Trabajador> GetAllTrabajadores()
        {
            return  _appContext.Trabajadores.Include("Cargo");
        }

        public IEnumerable<Trabajador> GetTrabajadorsPorFiltro(string filtro)
        {
            var trabajadores = GetAllTrabajadores(); // Obtiene todos los saludos
            if (trabajadores != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    trabajadores = trabajadores.Where(s => s.Nombres.Contains(filtro));
                }
            }
            return trabajadores;
        }

       
        public Trabajador GetTrabajador(int idTrabajador)
        {
            return _appContext.Trabajadores.Include("Cargo").FirstOrDefault(d => d.Id == idTrabajador);
        }

        public Trabajador UpdateTrabajador(Trabajador trabajador)
        {
            var trabajadorEncontrado = _appContext.Trabajadores.FirstOrDefault(d => d.Id == trabajador.Id);
            if (trabajadorEncontrado != null)
            {              
                trabajadorEncontrado.Nombres = trabajador.Nombres;
                trabajadorEncontrado.Apellidos = trabajador.Apellidos;
                trabajadorEncontrado.FechaNacimiento = trabajador.FechaNacimiento;
                trabajadorEncontrado.DireccionResidencia = trabajador.DireccionResidencia;
                trabajadorEncontrado.Cedula = trabajador.Cedula;
                trabajadorEncontrado.Telefono = trabajador.Telefono;
                trabajadorEncontrado.CorreoElectronico = trabajador.CorreoElectronico;
                trabajadorEncontrado.Cargo = trabajador.Cargo;
                _appContext.SaveChanges();
            }
            return trabajadorEncontrado;
        } 

        public Cargo AsignarCargo(int idTrabajador, int idCargo)
        {
            var trabajadorEncontrado = _appContext.Trabajadores.FirstOrDefault(m => m.Id == idTrabajador);
            if (trabajadorEncontrado != null)
            {
                var cargoEncontrado = _appContext.Cargos.FirstOrDefault(v => v.Id == idCargo);
                if (cargoEncontrado != null)
                {
                    trabajadorEncontrado.Cargo = cargoEncontrado;
                    _appContext.SaveChanges();
                }
                return cargoEncontrado;
            }
            return null;
        }    
    }
}