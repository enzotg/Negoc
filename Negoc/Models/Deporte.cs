using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Models
{
    public class Deporte
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long DeporteId { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }
    }
}
