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

        public byte GeneroId { get; set; }

        public double Precio { get; set; }

        public string PrecioStr { get; set; }

        public double PrecioLista { get; set; }
        
        //public string[] Imagenes { get; set; }

    }
}
