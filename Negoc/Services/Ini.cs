using Negoc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Services
{
    public class Ini
    {
        NegocioContext _context;

        public Ini(NegocioContext context)
        {
            _context = context;
        }
        public void Datos()
        {
            _context.Marca.Add(new Models.Marca { Nombre = "Adid" });
            _context.Marca.Add(new Models.Marca { Nombre = "Nik" });
            _context.Marca.Add(new Models.Marca { Nombre = "Pum" });
            _context.Marca.Add(new Models.Marca { Nombre = "UA" });

            _context.Categoria.Add(new Models.Categoria { CategoriaId = 1,Nombre = "Indumentaria", NivelId = 0, ParentId = 0 });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 2, Nombre = "Calzado", NivelId = 0, ParentId = 0 });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 3, Nombre = "Accesorios", NivelId = 0, ParentId = 0 });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 11, Nombre = "Remeras", NivelId = 1, ParentId = 1 });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 12, Nombre = "Zapatillas", NivelId = 1, ParentId = 2 });



        }
    }
}
