using Negoc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Data
{
    public class NegocioContext : DbContext
    {
        public NegocioContext(DbContextOptions <NegocioContext> options )
            :base(options)
        {
        }

        //public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProdImagen> ProdImagen { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Marca> Marca { get; set; }
<<<<<<< HEAD

        
=======
        public DbSet<Color> Color { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Deporte> Deporte { get; set; }
        public DbSet<Oferta> Oferta { get; set; }
        public DbSet<OfertaProducto> OfertaProducto { get; set; }
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
    }
}
