using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GestorRH.App.Dominio;

namespace GestorRH.App.Persistencia
{
    public interface IRepositorioCargo
    {
        IEnumerable<Cargo> GetAllCargos();
        Cargo AddCargo(Cargo cargo);
        Cargo UpdateCargo(Cargo cargo);
        void DeleteCargo(int idCargo);
        Cargo GetCargo(int idCargo);
        IEnumerable<Cargo> GetCargosPorFiltro(string filtro);
    }
}