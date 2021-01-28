using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Models
{
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CategoriaId { get; set; }

        [Display(Name = "Producto nombre")]
        public string Nombre { get; set; }

        public long? ParentId { get; set; }

        public int NivelId { get; set; }

    }
}
