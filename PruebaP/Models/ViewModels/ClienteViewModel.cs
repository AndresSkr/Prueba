using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaP.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public int NIT { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
    }
}
