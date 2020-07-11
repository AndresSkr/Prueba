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
    public class ClienteController : Controller
    {
        private Models.MyDBContext db;
        public ClienteController(Models.MyDBContext context)
        {
            db = context;
        }
        //es para saber que tipo de accion va ser el api, en este caso es HttpGET
        [HttpGet("[action]")]
        public IEnumerable<ClienteViewModel> Listado()
        {
            List<ClienteViewModel> lst = (from d in db.clientes
                                          orderby d.Id descending
                                          select new ClienteViewModel
                                          {
                                              Id = d.Id,
                                              NIT =d.NIT,
                                              nombre = d.nombre,
                                              correo = d.correo
                                          }).ToList();
            return lst;
        }


        [HttpGet("[action]/{id}")]
        public Clientes Listado(int id)
        {
            var resultado = db.clientes.FirstOrDefault(p => p.Id == id);

            return resultado;
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody] ClienteViewModel ClienteIngresar)
        {
            MyResponse Res = new MyResponse();
            try
            {
                Models.Clientes oCliente = new Models.Clientes();
                oCliente.NIT = ClienteIngresar.NIT;
                oCliente.nombre = ClienteIngresar.nombre;
                oCliente.correo = ClienteIngresar.correo;
                db.clientes.Add(oCliente);
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
        [HttpDelete("[action]/{id}")]
        public MyResponse Delete(int id)
        {
            MyResponse Res = new MyResponse();
            try
            {
                var resultado = db.clientes.FirstOrDefault(p => p.Id == id);
                db.clientes.Remove(resultado);
                db.SaveChanges();
                Res.Success=1;
            }
            catch (Exception e)
            {
                Res.Success = 0;
                Res.Message = e.Message;
            }
            return Res;
        }

        [HttpPut("[action]/{id}")]
        public MyResponse Modificar([FromBody] ClienteViewModel ClienteModificar, int id)
        {
            MyResponse Res = new MyResponse();
            try
            {/*
                db.Entry(ClienteModificar).State = EntityState.Modified;
                db.SaveChanges();*/
                var ClienteExistente = db.clientes.FirstOrDefault(p => p.Id == ClienteModificar.Id);

                if (ClienteExistente != null)
                {

                    if (id == ClienteModificar.Id)
                    {
                        ClienteExistente.NIT = ClienteModificar.NIT;
                        ClienteExistente.nombre = ClienteModificar.nombre;
                        ClienteExistente.correo = ClienteModificar.correo;

                        db.SaveChanges();
                        Res.Success = 1;
                    }
                    else
                    {
                        Res.Success = 0;
                        Res.Message = "Error Diferentes Clientes";
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
