using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaP.Models.ViewModels
{
    public class ServicioViewModel
    {
        public int Id { get; set; }
        public string nombreServicio { get; set; }
        public decimal valorxHora { get; set; }
        public Clientes fk_Cliente { get; set; }
    }

}
