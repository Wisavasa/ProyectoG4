using System;
using GestorRH.App.Dominio;
using GestorRH.App.Persistencia;
using System.Collections.Generic;
namespace GestorRH.App.Consola
{
    class Program
    {
        private static IRepositorioCargo _repoCargo = new RepositorioCargo(new Persistencia.AppContext());
        private static IRepositorioLogging _repoLogging = new RepositorioLogging(new Persistencia.AppContext());
        private static IRepositorioTrabajador _repoTrabajador = new RepositorioTrabajador(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //AddCargo();
            //AddTrabajador();
            AsignarCargo();
            //AddLogging();
        }

        private static void AddCargo()
        {
            var cargo = new Cargo
            {
                NombreCargo = "Jefe de obra",
                Profesion = "Ingeniero Obrero",
                Salario = 5000000,
                FechaIngreso = new DateTime(2020, 01, 01),
                FechaEgreso = new DateTime(2022, 05, 02)
                
            };
            _repoCargo.AddCargo(cargo);
          
        }

        private static void AddTrabajador()
        {
            var trabajador = new Trabajador
            {
                Nombres = "Efesito",
                Apellidos = "Queso",
                FechaNacimiento = new DateTime(1992, 01, 01),
                DireccionResidencia = "Av asnche #10as0",
                Cedula = 1098562514,
                Telefono = "310789123456",
                CorreoElectronico = "castro@correo.com"
            };
            _repoTrabajador.AddTrabajador(trabajador);
          
        }

        private static void AsignarCargo()
        {
            var cargo = _repoTrabajador.AsignarCargo(6, 2);
            Console.WriteLine(cargo.NombreCargo );
        }

        private static void AddLogging()
        {
            var logging = new Logging
            {
                Usuario = "Peter",
                Contrasena = "mipass123",
                SuperUser = true                
            };
            _repoLogging.AddLogging(logging);
        }


    }
}
