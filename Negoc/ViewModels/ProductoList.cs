using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.ViewModels
{
    public class ProductoList
    {
        public long ProductoId { get; set; }
                        
        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public string Marca { get; set; }

<<<<<<< HEAD
<<<<<<< HEAD
=======
        public string Genero { get; set; }

>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
        public string Genero { get; set; }

>>>>>>> carro
        public byte GeneroId { get; set; }

        public double Precio { get; set; }

        public string PrecioStr { get; set; }

        public double PrecioLista { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        
        //public string[] Imagenes { get; set; }
=======
=======
>>>>>>> carro

        public string Descripcion { get; set; }

        public string Detalle { get; set; }

        public float DescuentoPorc { get; set; }

        public bool EnvioGratis { get; set; }
                
        public IEnumerable<ProdImagenList> Imagenes { get; set; }
<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro

    }
}
