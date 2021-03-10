using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Negoc.Models
{
    public class OfertaProducto
    {        
        public long OfertaProductoId { get; set; }

        public long ProductoId { get; set; }

        public Oferta Oferta { get; set; }

        public Producto Producto { get; set; }
    }
}
