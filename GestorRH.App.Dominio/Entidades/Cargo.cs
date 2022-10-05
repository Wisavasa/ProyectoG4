using System;
namespace GestorRH.App.Dominio
{
    public class Cargo
    {
        public int Id {get;set;}
        public string NombreCargo {get;set;}
        public string Profesion {get;set;}
        public int Salario {get;set;}
        public DateTime FechaIngreso {get;set;}
        public DateTime FechaEgreso {get;set;}
        
    }
}