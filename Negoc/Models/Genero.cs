using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Models
{
    public class Genero
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte GeneroId { get; set; }

        public string Nombre { get; set; }
    }
}
