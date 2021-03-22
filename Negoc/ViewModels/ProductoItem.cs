using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.ViewModels
{
    public class ProductoItem
    {
        public long ProductoId { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public string Marca { get; set; }

        public string Genero { get; set; }

        public double Precio { get; set; }

        public string PrecioStr { get; set; }

    }
}
