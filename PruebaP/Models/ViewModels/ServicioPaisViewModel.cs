using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaP.Models.ViewModels
{
    public class ServicioPaisViewModel
    {
        public int Id { get; set; }
        public Paises fk_IdPais { get; set; }
        public Servicios fK_IdServicio { get; set; }
    }
}
