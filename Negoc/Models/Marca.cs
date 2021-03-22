using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Models
{
    public class Marca
    {
        public long MarcaId { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
