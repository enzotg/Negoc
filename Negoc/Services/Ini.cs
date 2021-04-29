using Negoc.Data;
<<<<<<< HEAD
=======
using Negoc.Models;
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
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
<<<<<<< HEAD
            _context.Marca.Add(new Models.Marca { Nombre = "Adid" });
            _context.Marca.Add(new Models.Marca { Nombre = "Nik" });
            _context.Marca.Add(new Models.Marca { Nombre = "Pum" });
            _context.Marca.Add(new Models.Marca { Nombre = "UA" });

            _context.Categoria.Add(new Models.Categoria { CategoriaId = 1,Nombre = "Indumentaria", NivelId = 0, ParentId = 0 });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 2, Nombre = "Calzado", NivelId = 0, ParentId = 0 });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 3, Nombre = "Accesorios", NivelId = 0, ParentId = 0 });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 11, Nombre = "Remeras", NivelId = 1, ParentId = 1 });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 12, Nombre = "Zapatillas", NivelId = 1, ParentId = 2 });
=======
            _context.Marca.Add(new Models.Marca { MarcaId = 1, Nombre = "Adidas" });
            _context.Marca.Add(new Models.Marca { MarcaId = 2, Nombre = "Nike" });
            _context.Marca.Add(new Models.Marca { MarcaId = 3, Nombre = "Puma" });
            _context.Marca.Add(new Models.Marca { MarcaId = 4, Nombre = "Under Armour" });
            _context.Marca.Add(new Models.Marca { MarcaId = 5, Nombre = "Topper" });

            _context.Categoria.Add(new Models.Categoria { CategoriaId = 1,Nombre = "Indumentaria", NivelId = 0, ParentId = 0 , NombreSing = ""});
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 2, Nombre = "Calzado", NivelId = 0, ParentId = 0, NombreSing = "" });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 3, Nombre = "Accesorios", NivelId = 0, ParentId = 0, NombreSing = "" });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 11, Nombre = "Remeras", NivelId = 1, ParentId = 1, NombreSing = "Remera" });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 12, Nombre = "Shorts", NivelId = 1, ParentId = 1, NombreSing = "Short" });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 13, Nombre = "Pantalones", NivelId = 1, ParentId = 1, NombreSing = "Pantalon" });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 14, Nombre = "Buzos", NivelId = 1, ParentId = 1, NombreSing = "Buzo" });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 15, Nombre = "Camperas", NivelId = 1, ParentId = 1, NombreSing = "Campera" });

            _context.Categoria.Add(new Models.Categoria { CategoriaId = 21, Nombre = "Zapatillas", NivelId = 1, ParentId = 2, NombreSing = "Zapatillas" });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 22, Nombre = "Botines", NivelId = 1, ParentId = 2, NombreSing = "Botines" });

            _context.Categoria.Add(new Models.Categoria { CategoriaId = 101, Nombre = "Deportivas", NivelId = 2, ParentId = 11, NombreSing = "Deportiva" });
            _context.Categoria.Add(new Models.Categoria { CategoriaId = 102, Nombre = "Camisetas", NivelId = 2, ParentId = 11, NombreSing = "Camiseta" });

            _context.Genero.Add(new Genero { GeneroId = 1, Nombre = "Hombre" });
            _context.Genero.Add(new Genero { GeneroId = 2, Nombre = "Mujer" });
            _context.Genero.Add(new Genero { GeneroId = 3, Nombre = "Niño" });
            _context.Genero.Add(new Genero { GeneroId = 4, Nombre = "Sin" });

            _context.Color.Add(new Models.Color { ColorId=1, Nombre="Azul"});

            _context.Add(new Producto { ProductoId = 1, Nombre = "Manchester City 20/21", CategoriaId = 11, MarcaId = 3, GeneroId = 1, ColorId = 1, TalleId = 1, Descripcion = "", Precio = 5999, PrecioLista = 5999, PrecioStr = "5999", DescuentoPorc = 0, Detalle = "" });

>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57



        }
    }
}
