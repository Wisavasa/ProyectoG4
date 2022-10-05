using System;
namespace GestorRH.App.Dominio
{
    public class Trabajador
    {
        public int Id {get;set;}
        public string Nombres {get;set;}
        public string Apellidos {get;set;}
        public DateTime FechaNacimiento {get;set;}
        public string DireccionResidencia {get;set;}
        public int Cedula {get;set;}
        public string Telefono {get;set;}
        public string CorreoElectronico {get;set;}
        public Cargo Cargo {get;set;}
        
    }
}