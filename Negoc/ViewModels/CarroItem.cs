using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.ViewModels
{
    public class CarroItem
    {        
        public long CarroItemId { get; set; }

        public long ProductoId { get; set; }

        public string NombreProd { get; set; }

        public long Cantidad { get; set; }

        public double Precio { get; set; }

        public double Total { get; set; }
    }
}
