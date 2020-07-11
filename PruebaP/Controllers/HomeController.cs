using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaP.Models.Response;
using PruebaP.Models.ViewModels;
using PruebaP.Models;
using Microsoft.EntityFrameworkCore;


namespace PruebaP.Controllers
{
    [Route("api/[controller]")]
    public class HomeController
    {
        private Models.MyDBContext db;
        public HomeController(Models.MyDBContext context)
        {
            db = context;
        }

        [HttpDelete("[action]")]
        public MyResponse Restaurar()
        {
            MyResponse Res = new MyResponse();
            db.Database.ExecuteSqlCommand("TRUNCATE TABLE servicios_pais");
            db.Database.ExecuteSqlCommand("DBCC CHECKIDENT(servicios_pais, RESEED, 1)");

            db.Database.ExecuteSqlCommand("DELETE FROM servicios");
            db.Database.ExecuteSqlCommand("DBCC CHECKIDENT(servicios, RESEED, 0)");

            db.Database.ExecuteSqlCommand("DELETE FROM clientes");
            db.Database.ExecuteSqlCommand("DBCC CHECKIDENT(clientes, RESEED, 0)");

            Res.Message = "ingreso";
            Res.Success = 1;
            return Res;
        }
    }
}
