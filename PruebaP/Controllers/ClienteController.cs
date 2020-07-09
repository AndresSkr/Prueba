using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaP.Models.Response;
using PruebaP.Models.ViewModels;
using PruebaP.Models;

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
        public IEnumerable<ClienteViewModel> Message()
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

            /* metodo con IActionResult
             public IActionResult Message()
            {
                List<Models.Message> lst = null;
             //crea una lista y me hace un select * from Message
                lst = db.Message.ToList();
                return Json(lst);
            }*/
        }


        [HttpGet("[action]/{id}")]
        public Clientes message(int id)
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


    }
}
