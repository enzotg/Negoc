using Negoc.Data;
using Negoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negoc.ViewModels;

namespace Negoc.Services
{
    public class CarroServicio
    {
        NegocioContext _context;         

        public CarroServicio(NegocioContext Context)
        {
            _context = Context;
        }

        public IEnumerable<CarroItem> ActualizarCarro(IEnumerable<CarroItem> carro)
        {
            //carro.FirstOrDefault().CarroItemId = 1;
            foreach(var c in carro.OrderBy(x=>x.CarroItemId))
            {
                var p =_context.Producto.Where(x => x.ProductoId == c.ProductoId).FirstOrDefault();                

                if (p != null)
                {
                    c.NombreProd = p.Descripcion;
                    c.Precio = p.Precio;
                    c.Total = p.Precio * c.Cantidad;
                    c.CarroItemId++;
                }                    
            }

            return carro;
        }
    }
}
