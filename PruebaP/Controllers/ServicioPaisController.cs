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
    public class ServicioPaisController : Controller
    {
        private Models.MyDBContext db;
        public ServicioPaisController(Models.MyDBContext context)
        {
            db = context;
        }
        [HttpGet("[action]")]
        public IEnumerable<ServicioPaisViewModel> Listado()
        {
            List<ServicioViewModel> lst = (from d in db.servicios
                                           orderby d.Id descending
                                           select new ServicioViewModel
                                           {
                                               Id = d.Id,
                                               nombreServicio = d.nombreServicio,
                                               valorxHora = d.valorxHora,
                                               fk_Cliente = d.fk_Cliente
                                           }).ToList();

            List<ServicioPaisViewModel> lst1 = (from d in db.servicios_pais
                                            orderby d.fk_IdPais descending
                                            select new ServicioPaisViewModel
                                            {
                                                Id = d.Id,
                                               fk_IdPais = d.fk_IdPais,
                                               fK_IdServicio = d.fK_IdServicio,
                                            }).ToList();
            return lst1;
        }


        [HttpPost("[action]")]
        public MyResponse Add([FromBody] ServicioPaisViewModel ServicioPaisAgregar)
        {
            MyResponse Res = new MyResponse();
            try
            {


                if (ServicioPaisAgregar != null)
                {
                    var resultadopais = db.paises.FirstOrDefault(p => p.Id == ServicioPaisAgregar.fk_IdPais.Id);
                    var resultadoservicio = db.servicios.FirstOrDefault(p => p.Id == ServicioPaisAgregar.fK_IdServicio.Id);

                    Models.Servicios_Pais oServicioPais = new Models.Servicios_Pais();
                    oServicioPais.fk_IdPais = resultadopais;
                    oServicioPais.fK_IdServicio = resultadoservicio;

                    db.servicios_pais.Add(oServicioPais);
                    db.SaveChanges();
                    Res.Success = 1;

                }
                else
                {
                    Res.Message = "Sericio Nulo";
                }

            }
            catch (Exception e)
            {
                Res.Success = 0;
                Res.Message = e.Message;
            }
            return Res;
        }

        [HttpDelete("[action]/{id}")]
        public MyResponse Delete(int id)
        {
            MyResponse Res = new MyResponse();
            try
            {
                var resultado = db.servicios_pais.FirstOrDefault(p => p.Id == id);
                db.servicios_pais.Remove(resultado);
                db.SaveChanges();
                Res.Success = 1;
            }
            catch (Exception e)
            {
                Res.Success = 0;
                Res.Message = e.Message;
            }
            return Res;
        }
    }
}
