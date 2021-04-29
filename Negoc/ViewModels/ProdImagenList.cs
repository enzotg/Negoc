using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.ViewModels
{
    public class ProdImagenList
    {
        public long ProdImagenId { get; set; }

        public long ProductoId { get; set; }

        public string Nombre { get; set; }

        public string ImageMimeType { get; set; }
        
    }
}
