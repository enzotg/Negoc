using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Models
{
    public class ProdImagen
    {
        public long ProdImagenId { get; set; }

        public long ProductoId { get; set; }

        public string Nombre { get; set; }

        public string ImageMimeType { get; set; }

        Producto Producto { get; set; }

    }
}
