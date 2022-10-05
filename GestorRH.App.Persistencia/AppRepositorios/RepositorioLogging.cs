using System;
using System.Collections.Generic;
using System.Linq;
using GestorRH.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace GestorRH.App.Persistencia
{
    public class RepositorioLogging : IRepositorioLogging
    {
        /// <summary>
        /// Referencia al contexto de Logging
        /// </summary>

        private readonly AppContext _appContext;
       
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        
        public RepositorioLogging(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Logging AddLogging(Logging logging)
        {
            var loggingAdicionado = _appContext.Loggings.Add(logging);
            _appContext.SaveChanges();
            return loggingAdicionado.Entity;
        }

        public void DeleteLogging(int idLogging)
        {
            var loggingEncontrado = _appContext.Loggings.FirstOrDefault(d => d.Id == idLogging);
            if (loggingEncontrado == null)
                return;
            _appContext.Loggings.Remove(loggingEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Logging> GetAllLoggings()
        {
            return  _appContext.Loggings;
        }

        public IEnumerable<Logging> GetLoggingsPorFiltro(string filtro)
        {
            var loggings = GetAllLoggings(); // Obtiene todos los saludos
            if (loggings != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    loggings = loggings.Where(s => s.Usuario.Contains(filtro));
                }
            }
            return loggings;
        }

       
        public Logging GetLogging(int idLogging)
        {
            return _appContext.Loggings.FirstOrDefault(d => d.Id == idLogging);
        }

        public Logging GetLoggingsotro(string usuario)
        {
            return _appContext.Loggings.FirstOrDefault(d => d.Usuario == usuario);
        }

        public Logging UpdateLogging(Logging logging)
        {
            var loggingEncontrado = _appContext.Loggings.FirstOrDefault(d => d.Id == logging.Id);
            if (loggingEncontrado != null)
            {
                loggingEncontrado.Usuario = logging.Usuario;                
                loggingEncontrado.Contrasena = logging.Contrasena;
                loggingEncontrado.SuperUser = logging.SuperUser;
                _appContext.SaveChanges();
            }
            return loggingEncontrado;
        }       
    }
}