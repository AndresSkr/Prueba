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
    public class ServicioController : Controller
    {
        private Models.MyDBContext db;
        public ServicioController(Models.MyDBContext context)
        {
            db = context;
        }
        //es para saber que tipo de accion va ser el api, en este caso es HttpGET
        [HttpGet("[action]")]
        public IEnumerable<ServicioViewModel> Listado()
        {
            List<ServicioViewModel> lst = (from d in db.servicios
                                          orderby d.Id descending
                                          select new ServicioViewModel
                                          {
                                              Id = d.Id,
                                              nombreServicio=d.nombreServicio,
                                              valorxHora=d.valorxHora,
                                              fk_Cliente=d.fk_Cliente
                                          }).ToList();
            return lst;
        }


        [HttpGet("[action]/{id}")]
        public Servicios Listado(int id)
        {
            var resultado = db.servicios.FirstOrDefault(p => p.Id == id);

            return resultado;
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody] ServicioViewModel ServicioAgregar)
        {
            MyResponse Res = new MyResponse();
            try
            {
               
                
               if (ServicioAgregar!=null)
                {
                    var resultado = db.clientes.FirstOrDefault(p => p.Id == ServicioAgregar.fk_Cliente.Id);


                    Models.Servicios oServicio = new Models.Servicios();
                    oServicio.valorxHora = ServicioAgregar.valorxHora;
                    oServicio.nombreServicio = ServicioAgregar.nombreServicio;
                    oServicio.fk_Cliente = resultado;

                    db.servicios.Add(oServicio);
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
                var resultado = db.servicios.FirstOrDefault(p => p.Id == id);
                db.servicios.Remove(resultado);
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

        [HttpPut("[action]/{id}")]
        public MyResponse Modificar([FromBody] ServicioViewModel ServicioModificar, int id)
        {
            MyResponse Res = new MyResponse();
            try
            {/*
                db.Entry(ClienteModificar).State = EntityState.Modified;
                db.SaveChanges();*/
                var ServicioExistente = db.servicios.FirstOrDefault(p => p.Id == ServicioModificar.Id);

                if (ServicioExistente != null)
                {

                    if (id == ServicioModificar.Id)
                    {
                        ServicioExistente.nombreServicio = ServicioModificar.nombreServicio;
                        ServicioExistente.valorxHora = ServicioModificar.valorxHora;

                        db.SaveChanges();
                        Res.Success = 1;
                    }
                    else
                    {
                        Res.Success = 0;
                        Res.Message = "Error Diferentes Servicios";
                    }

                }
                else
                {
                    Res.Success = 0;
                    Res.Message = "Error cliente nulo";
                }

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
