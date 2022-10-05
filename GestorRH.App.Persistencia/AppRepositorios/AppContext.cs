using Microsoft.EntityFrameworkCore;
using GestorRH.App.Dominio;

namespace GestorRH.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Logging> Loggings {get;set;}
        public DbSet<Cargo> Cargos {get;set;}
        public DbSet<Trabajador> Trabajadores {get;set;}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source = recursoshumanosdb.mssql.somee.com; Initial Catalog = recursoshumanosdb;user id=alejandro8020_SQLLogin_1;pwd=ayi8c5dkyi");
                //optionsBuilder
                //.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = GestorRHData");
            }
        }
    }
}