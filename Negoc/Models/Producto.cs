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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ProductoId { get; set; }

        //[Display(Name = "Producto nombre")]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public long CategoriaId { get; set; }

        public long MarcaId { get; set; }

        public byte GeneroId { get; set; }

        public long ColorId { get; set; }               

        public long TalleId { get; set; }

        [MaxLength(100)]        
        public string Descripcion { get; set; }

        public double Precio { get; set; }

        public double PrecioLista { get; set; }

        [MaxLength(30)]
        public string PrecioStr { get; set; }
                
        [NotMapped]
        public IFormFile FormFile { get; set; }

        public IEnumerable<ProdImagen> Imagenes { get; set; } 

        public Categoria Categoria { get; set; }

        public Marca Marca { get; set; }

        public Color Color { get; set; }


    }
}
