using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GestorRH.App.Dominio;

namespace GestorRH.App.Persistencia
{
    public interface IRepositorioLogging
    {
        IEnumerable<Logging> GetAllLoggings();
        Logging AddLogging(Logging logging);
        Logging UpdateLogging(Logging logging);
        void DeleteLogging(int idLogging);
        Logging GetLogging(int idLogging);
        Logging GetLoggingsotro(string Usuario);
        IEnumerable<Logging> GetLoggingsPorFiltro(string filtro);
    }
}