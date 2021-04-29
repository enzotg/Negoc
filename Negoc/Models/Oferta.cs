using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Negoc.Models
{
    public class Oferta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OfertaId { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        public IEnumerable<OfertaProducto> Ofertas { get; set; }
    }
}
