using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Models
{
    public class Producto
    {
<<<<<<< HEAD
<<<<<<< HEAD
=======
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
>>>>>>> carro
        public long ProductoId { get; set; }

        //[Display(Name = "Producto nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public long CategoriaId { get; set; }

        public long MarcaId { get; set; }

        public byte GeneroId { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
        public byte ColorId { get; set; }

        public long TalleId { get; set; }

=======
        public long ColorId { get; set; }               

        public long TalleId { get; set; }

=======
        public long ColorId { get; set; }               

        public long TalleId { get; set; }

>>>>>>> carro
        public long DeporteId { get; set; }

        [MaxLength(100)]        
        public string Descripcion { get; set; }

<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro
        public double Precio { get; set; }

        public double PrecioLista { get; set; }

        [MaxLength(30)]
        public string PrecioStr { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
                
=======
=======
>>>>>>> carro

        public float DescuentoPorc { get; set; }

        [MaxLength(2000)]
        public string Detalle { get; set; }

<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro
        [NotMapped]
        public IFormFile FormFile { get; set; }

        public IEnumerable<ProdImagen> Imagenes { get; set; } 

        public Categoria Categoria { get; set; }

        public Marca Marca { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> carro
        public Color Color { get; set; }

        public Genero Genero { get; set; }

        public Deporte Deporte { get; set; }

<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro
    }
}
