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

<<<<<<< HEAD
<<<<<<< HEAD
        [Display(Name = "Producto nombre")]
=======
        [Display(Name = "Nombre")]
        [MaxLength(50)]
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
        [Display(Name = "Nombre")]
        [MaxLength(50)]
>>>>>>> carro
        public string Nombre { get; set; }

        public long? ParentId { get; set; }

        public int NivelId { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> carro
        [Display(Name = "Nombre singular")]
        [MaxLength(50)]
        public string NombreSing { get; set; }

<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro
    }
}
