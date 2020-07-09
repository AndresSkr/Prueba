using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaP.Models.ViewModels;

namespace PruebaP.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }

        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Servicios> servicios { get; set; }
        public DbSet<Paises> paises { get; set; }
        public DbSet<Servicios_Pais> servicios_pais{get;set;}

    }

    public class Clientes
    {
        public int Id { get; set; }
        public int NIT { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
    }
    public class Servicios
    {
        public int Id { get; set; }
        public string nombreServicio { get; set; }
        public decimal valorxHora { get; set; }
        public Clientes fk_Cliente { get; set; }

    }

    public class Paises
    {
        public int Id { get; set; }
        public string nombrePais { get; set; }


    }

    public class Servicios_Pais
    {
        public int Id { get; set; }
        public Paises fk_IdPais { get; set; }
        public Servicios fK_IdServicio { get; set; }
    }
}
