using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Models
{
    public class Color
    {
        public long ColorId { get; set; }

        [MaxLength(30)]
        public string Nombre { get; set; }

        [MaxLength(20)]
        public string HexCode { get; set; }
    }
}
