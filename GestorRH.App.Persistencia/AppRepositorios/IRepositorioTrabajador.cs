using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GestorRH.App.Dominio;

namespace GestorRH.App.Persistencia
{
    public interface IRepositorioTrabajador
    {
        IEnumerable<Trabajador> GetAllTrabajadores();
        Trabajador AddTrabajador(Trabajador trabajador);
        Trabajador UpdateTrabajador(Trabajador trabajador);
        void DeleteTrabajador(int idTrabajador);
        Trabajador GetTrabajador(int idTrabajador);
        IEnumerable<Trabajador> GetTrabajadorsPorFiltro(string filtro);
        Cargo AsignarCargo(int idTrabajador, int idCargo);
    }
}