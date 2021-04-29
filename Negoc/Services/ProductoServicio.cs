using Negoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negoc.Data;
using Microsoft.EntityFrameworkCore;
using Negoc.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Linq.Expressions;

namespace Negoc.Services
{
    public class ProductoServicio
    {
        NegocioContext _context;
<<<<<<< HEAD
<<<<<<< HEAD
=======
        static double Monto_Envio_Gratis = 5000;

>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
        static double Monto_Envio_Gratis = 5000;

>>>>>>> carro

        public ProductoServicio(NegocioContext Context)
        {
            _context = Context;
        }

        public void Agregar(Producto producto, Microsoft.AspNetCore.Http.IFormFileCollection files, string WebRootPath)
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======

            producto.Descripcion = CalcDescr(producto);

>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======

            producto.Descripcion = CalcDescr(producto);

>>>>>>> carro
            _context.Producto.Add(producto);
            _context.SaveChanges();
            long productoId = producto.ProductoId;

            AgregarImg(productoId, files, WebRootPath);
        }

        public void AgregarImg(long ProductoId, IFormFileCollection files, string WebRootPath)
        {
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var folder = Path.Combine(WebRootPath, "images\\producto");
<<<<<<< HEAD
<<<<<<< HEAD
                    var fileName = Path.Combine(folder,
                        Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName));
=======
                    //var fileName = Path.Combine(folder, Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName));
                    var fileName = Path.Combine(folder, (file.FileName));
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
                    //var fileName = Path.Combine(folder, Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName));
                    var fileName = Path.Combine(folder, (file.FileName));
>>>>>>> carro

                    using (var stream = System.IO.File.Create(fileName))
                    {
                        file.CopyTo(stream);
                    }
                    //-----------
                    ProdImagen img = new ProdImagen();
                    img.Nombre = fileName;
                    img.ImageMimeType = file.ContentType;
                    img.ProductoId = ProductoId;

                    _context.ProdImagen.Add(img);
                }
            }
            _context.SaveChanges();
        }

        public void Modificar(Producto producto)
        {            
            var p = _context.Producto.Where(x => x.ProductoId == producto.ProductoId)
                .FirstOrDefault();
            if (p != null)
            {
                p.CategoriaId = producto.CategoriaId;
                p.ColorId = producto.ColorId;
                p.DeporteId = producto.DeporteId;
                p.GeneroId = producto.GeneroId;
                p.MarcaId = producto.MarcaId;
                p.Nombre = producto.Nombre;
                p.Precio = producto.Precio;
                p.PrecioLista = producto.PrecioLista;
                p.PrecioStr = producto.PrecioStr;
                p.TalleId = producto.TalleId;
<<<<<<< HEAD
<<<<<<< HEAD
                _context.SaveChanges();
            }
        }
=======
                p.Descripcion = CalcDescr(producto);
                p.DescuentoPorc = producto.DescuentoPorc;
                p.Detalle = producto.Detalle;
=======
                p.Descripcion = CalcDescr(producto);
                p.DescuentoPorc = producto.DescuentoPorc;
                p.Detalle = producto.Detalle;

>>>>>>> carro
                _context.SaveChanges();
            }
        }
        private string CalcDescr(Producto producto)
        {
            var cat = _context.Categoria.FirstOrDefault(x => x.CategoriaId == producto.CategoriaId);
            var mar = _context.Marca.FirstOrDefault(x => x.MarcaId == producto.MarcaId);
            var gen = _context.Genero.FirstOrDefault(x => x.GeneroId == producto.GeneroId);
            string sgen = "";

            if (cat == null) return "";
            if (mar == null) return "";

            if (gen.GeneroId < 4)
                sgen = " - " + gen.Nombre;

            return 
                cat.NombreSing + " " +                
                mar.Nombre + " " +
                producto.Nombre + 
                sgen;

        }
<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro

        public List<Categoria> GetCategorias(long CategoriaId)
        {
            ArbolCategoria arbol = new ArbolCategoria(_context.Categoria.ToList());            
            return arbol.GetTodosChilds(CategoriaId);
        }

        public List<Categoria> GetCategorias(long CategoriaId, long NivelId)
        {
            ArbolCategoria arbol = new ArbolCategoria(_context.Categoria.ToList());
            return arbol.GetTodosChilds(CategoriaId).Where(x=>x.NivelId <= NivelId).ToList();
        }
<<<<<<< HEAD
<<<<<<< HEAD
        /*public async Task<List<Categoria>> GetCategoriasAsync(long CategoriaId, long NivelId)
        {
            ArbolCategoria arbol = new ArbolCategoria(_context.Categoria.ToList());
            var res =  arbol.GetTodosChilds(CategoriaId).Where(x => x.NivelId <= NivelId).ToList();
            return   await res.ToAsyncEnumerable() ;
        }*/
=======
        public List<Categoria> GetParents(long ProductoId)
        {
            ArbolCategoria arbol = new ArbolCategoria(_context.Categoria.ToList());
=======
        public List<Categoria> GetParents(long ProductoId)
        {
            ArbolCategoria arbol = new ArbolCategoria(_context.Categoria.ToList());
>>>>>>> carro
            long cat = _context.Producto.FirstOrDefault(x => x.ProductoId == ProductoId).CategoriaId;

            var res = arbol.GetTodosParents(cat);
            res.Add(_context.Categoria.FirstOrDefault(x => x.CategoriaId == cat));

            return res;
        }
<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro
        public Producto GetProducto(long ProductoId)
        {
            return _context.Producto
                .Include(x=>x.Imagenes)
                .Where(x => x.ProductoId == ProductoId).FirstOrDefault();            
        }

        public ProdImagen GetProductoImg(long ProdImagenId)
        {
            return _context.ProdImagen                
                .Where(x => x.ProdImagenId == ProdImagenId).FirstOrDefault();
        }
        public List<ProductoList> GetProductos(long CategoriaId)
        {
            //Todos los productos de una categoria incluidos los que pertenecen a una categoria child
            List<Producto> res = new List<Producto>();
            ArbolCategoria arbol = new ArbolCategoria(_context.Categoria.ToList());

            res.AddRange(_context.Producto
                .Include(x=>x.Categoria)
                .Include(x=> x.Marca)
<<<<<<< HEAD
<<<<<<< HEAD
=======
                .Include(x => x.Genero)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
                .Include(x => x.Genero)
>>>>>>> carro
                .Where(x => x.CategoriaId == CategoriaId));

            foreach (var c in arbol.GetTodosChilds(CategoriaId))
                res.AddRange(_context.Producto
                    .Include(x => x.Categoria)
                    .Include(x => x.Marca)
<<<<<<< HEAD
<<<<<<< HEAD
=======
                    .Include(x => x.Genero)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
                    .Include(x => x.Genero)
>>>>>>> carro
                    .Where(x => x.CategoriaId == c.CategoriaId));

            return res
                .Select(x => ToProdList(x))
                .ToList();

        }
        public List<ProductoList> GetProductos(long CategoriaId, byte GeneroId)
        {
            //Todos los productos de una categoria incluidos los que pertenecen a una categoria child
            List<Producto> res = new List<Producto>();
            ArbolCategoria arbol = new ArbolCategoria(_context.Categoria.ToList());

            res.AddRange(_context.Producto
                .Include(x => x.Categoria)
                .Include(x => x.Marca)
<<<<<<< HEAD
<<<<<<< HEAD
=======
                .Include(x => x.Genero)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
                .Include(x => x.Genero)
>>>>>>> carro
                .Where(x => x.CategoriaId == CategoriaId && x.GeneroId == GeneroId));

            foreach (var c in arbol.GetTodosChilds(CategoriaId))
                res.AddRange(_context.Producto
                    .Include(x => x.Categoria)
                    .Include(x => x.Marca)
<<<<<<< HEAD
<<<<<<< HEAD
=======
                    .Include(x => x.Genero)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
                    .Include(x => x.Genero)
>>>>>>> carro
                    .Where(x => x.CategoriaId == c.CategoriaId));

            return res
                .Select(x => ToProdList(x))
                .ToList();
        }
<<<<<<< HEAD
<<<<<<< HEAD
        public List<ProductoList> GetProductos(long categoriaId, byte generoId, int pageNumber, int pageSize, int TipoOrden)
=======
        private IQueryable<Producto> ArmarQry(long categoriaId, byte generoId, long MarcaId, long ColorId, double PrecioD, double PrecioH, string Descripcion, int TipoOrden)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
        private IQueryable<Producto> ArmarQry(long categoriaId, byte generoId, long MarcaId, long ColorId, long DeporteId, double PrecioD, double PrecioH, string Descripcion, int TipoOrden)
>>>>>>> carro
        {
            var entidad = _context.Producto;
            var item = Expression.Parameter(typeof(Producto), "item");

<<<<<<< HEAD
<<<<<<< HEAD
            Expression exprWhere=null;
=======
            Expression exprWhere = null;
>>>>>>> carro
            if (categoriaId != 0)
            {
                exprWhere = Expression.Equal(Expression.Property(item, "CategoriaId"), Expression.Constant(categoriaId));

                foreach (var cat in this.GetCategorias(categoriaId))
                {
                    exprWhere = Expression.Or(exprWhere,
                        Expression.Equal(Expression.Property(item, "CategoriaId"), Expression.Constant(Convert.ToInt64(cat.CategoriaId))));
                }
            }
            if (generoId != 0)
            {
<<<<<<< HEAD
                if(exprWhere==null)
=======
            Expression exprWhere = null;
            if (categoriaId != 0)
            {
                exprWhere = Expression.Equal(Expression.Property(item, "CategoriaId"), Expression.Constant(categoriaId));

                foreach (var cat in this.GetCategorias(categoriaId))
                {
                    exprWhere = Expression.Or(exprWhere,
                        Expression.Equal(Expression.Property(item, "CategoriaId"), Expression.Constant(Convert.ToInt64(cat.CategoriaId))));
                }
            }
            if (generoId != 0)
            {
                if (exprWhere == null)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
                if (exprWhere == null)
>>>>>>> carro
                    exprWhere = Expression.Equal(Expression.Property(item, "GeneroId"), Expression.Constant(generoId));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Equal(Expression.Property(item, "GeneroId"), Expression.Constant(generoId)));
            }
<<<<<<< HEAD
<<<<<<< HEAD
=======
            if (MarcaId != 0)
            {
                if (exprWhere == null)
                    exprWhere = Expression.Equal(Expression.Property(item, "MarcaId"), Expression.Constant(MarcaId));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Equal(Expression.Property(item, "MarcaId"), Expression.Constant(MarcaId)));
            }
            if (ColorId != 0)
            {
                if (exprWhere == null)
                    exprWhere = Expression.Equal(Expression.Property(item, "ColorId"), Expression.Constant(ColorId));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Equal(Expression.Property(item, "ColorId"), Expression.Constant(ColorId)));
            }
            if (DeporteId != 0)
            {
                if (exprWhere == null)
                    exprWhere = Expression.Equal(Expression.Property(item, "DeporteId"), Expression.Constant(DeporteId));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Equal(Expression.Property(item, "DeporteId"), Expression.Constant(DeporteId)));
            }
            if (PrecioD != 0 && PrecioH != 0)
            {
                if (exprWhere == null)
                {
                    exprWhere = Expression.AndAlso(
                        Expression.GreaterThanOrEqual(Expression.Property(item, "Precio"), Expression.Constant(PrecioD)),
                        Expression.LessThanOrEqual(Expression.Property(item, "Precio"), Expression.Constant(PrecioH)));
                }
                    
                else
                    exprWhere = Expression.And(exprWhere, Expression.AndAlso(
                        Expression.GreaterThanOrEqual(Expression.Property(item, "Precio"), Expression.Constant(PrecioD)),
                        Expression.LessThanOrEqual(Expression.Property(item, "Precio"), Expression.Constant(PrecioH))));
            }
            if(Descripcion != ""&&Descripcion!=null&&Descripcion!="null")
            {
                if (exprWhere == null)
                    exprWhere = Expression.Call(Expression.Property(item, "Descripcion"), typeof(string).GetMethod("Contains", new[] { typeof(string) }),Expression.Constant(Descripcion));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Call(Expression.Property(item, "Descripcion"), typeof(string).GetMethod("Contains", new[] { typeof(string) }), Expression.Constant(Descripcion)));
            }
>>>>>>> carro

            //--------
            if (exprWhere == null)
                exprWhere = Expression.GreaterThan(Expression.Property(item, "ProductoId"), Expression.Constant(Convert.ToInt64(0)));

            var param = Expression.Parameter(typeof(Producto), "producto");
            var lambda = Expression.Lambda<Func<Producto, bool>>(exprWhere, item);
            var result = entidad
                    .Include(x => x.Categoria)
                    .Include(x => x.Marca)    
                    .Include(x => x.Color)
                    .Include(x => x.Genero)
                    .Include(x=>x.Deporte)
                    .Where(lambda);

<<<<<<< HEAD
            if (TipoOrden == 1 )
=======
            if (MarcaId != 0)
            {
                if (exprWhere == null)
                    exprWhere = Expression.Equal(Expression.Property(item, "MarcaId"), Expression.Constant(MarcaId));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Equal(Expression.Property(item, "MarcaId"), Expression.Constant(MarcaId)));
            }
            if (ColorId != 0)
            {
                if (exprWhere == null)
                    exprWhere = Expression.Equal(Expression.Property(item, "ColorId"), Expression.Constant(ColorId));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Equal(Expression.Property(item, "ColorId"), Expression.Constant(ColorId)));
            }
            if (PrecioD != 0 && PrecioH != 0)
            {
                if (exprWhere == null)
                {
                    exprWhere = Expression.AndAlso(
                        Expression.GreaterThanOrEqual(Expression.Property(item, "Precio"), Expression.Constant(PrecioD)),
                        Expression.LessThanOrEqual(Expression.Property(item, "Precio"), Expression.Constant(PrecioH)));
                }
                    
                else
                    exprWhere = Expression.And(exprWhere, Expression.AndAlso(
                        Expression.GreaterThanOrEqual(Expression.Property(item, "Precio"), Expression.Constant(PrecioD)),
                        Expression.LessThanOrEqual(Expression.Property(item, "Precio"), Expression.Constant(PrecioH))));
            }
            if(Descripcion != ""&&Descripcion!=null&&Descripcion!="null")
            {
                if (exprWhere == null)
                    exprWhere = Expression.Call(Expression.Property(item, "Descripcion"), typeof(string).GetMethod("Contains", new[] { typeof(string) }),Expression.Constant(Descripcion));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Call(Expression.Property(item, "Descripcion"), typeof(string).GetMethod("Contains", new[] { typeof(string) }), Expression.Constant(Descripcion)));
            }

            //--------
            if (exprWhere == null)
                exprWhere = Expression.GreaterThan(Expression.Property(item, "ProductoId"), Expression.Constant(Convert.ToInt64(0)));

            var param = Expression.Parameter(typeof(Producto), "producto");
            var lambda = Expression.Lambda<Func<Producto, bool>>(exprWhere, item);
            var result = entidad
                    .Include(x => x.Categoria)
                    .Include(x => x.Marca)    
                    .Include(x => x.Color)
                    .Include(x => x.Genero)
                    .Where(lambda);

            if (TipoOrden == 1)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
            if (TipoOrden == 1)
>>>>>>> carro
            {
                Expression<Func<Producto, Double>> or = Expression.Lambda<Func<Producto, Double>>(Expression.Property(param, "Precio"), param);
                result = result.OrderBy(or);
            }
            if (TipoOrden == 2)
            {
                Expression<Func<Producto, Double>> or = Expression.Lambda<Func<Producto, Double>>(Expression.Property(param, "Precio"), param);
                result = result.OrderByDescending(or);
            }
            if (TipoOrden == 3)
            {
                Expression<Func<Producto, String>> or = Expression.Lambda<Func<Producto, String>>(Expression.Property(param, "Nombre"), param);
                result = result.OrderBy(or);
            }
            if (TipoOrden == 4)
            {
                Expression<Func<Producto, String>> or = Expression.Lambda<Func<Producto, String>>(Expression.Property(param, "Nombre"), param);
                result = result.OrderByDescending(or);
            }
<<<<<<< HEAD
<<<<<<< HEAD
            if (pageNumber==0 || pageSize==0)
                return new List<ProductoList>();


=======

            return result;

        }
        public List<ProductoList> GetProductos(long categoriaId, byte generoId, long MarcaId, long ColorId, double PrecioD, double PrecioH, string Descripcion, int pageNumber, int pageSize, int TipoOrden)
        {

            if (pageNumber==0 || pageSize==0)
                return new List<ProductoList>();

            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, PrecioD, PrecioH, Descripcion, TipoOrden);
            
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======

            return result;

        }
        public List<ProductoList> GetProductos(long categoriaId, byte generoId, long MarcaId, long ColorId, long DeporteId, double PrecioD, double PrecioH, string Descripcion, int pageNumber, int pageSize, int TipoOrden)
        {

            if (pageNumber==0 || pageSize==0)
                return new List<ProductoList>();

            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, DeporteId, PrecioD, PrecioH, Descripcion, TipoOrden);
            
>>>>>>> carro
            result = result
                .Skip((pageNumber-1) * pageSize)
                .Take(pageSize);

<<<<<<< HEAD
<<<<<<< HEAD
            var res = 
                result
                 .Select(x => ToProdList(x))
                .ToList();
=======
            var res = result
                 .Select(x => ToProdList(x))                 
                .ToList();

>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
            var res = result
                 .Select(x => ToProdList(x))                 
                .ToList();

>>>>>>> carro
            if (res == null)
                return new List<ProductoList>();
            else
                return res;
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
        public long GetProductosCantPag(long categoriaId, byte generoId, long MarcaId, long ColorId, double PrecioD, double PrecioH, string Descripcion, int pageNumber, int pageSize, int TipoOrden)
        {            
            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, PrecioD, PrecioH, Descripcion, TipoOrden);
=======
        public long GetProductosCantPag(long categoriaId, byte generoId, long MarcaId, long ColorId, long DeporteId, double PrecioD, double PrecioH, string Descripcion, int pageNumber, int pageSize, int TipoOrden)
        {            
            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, DeporteId, PrecioD, PrecioH, Descripcion, TipoOrden);
>>>>>>> carro
            var res = Math.Ceiling( Convert.ToDouble(result.ToList().Count()) / Convert.ToDouble(pageSize) );
                
            return (long)res;
        }

<<<<<<< HEAD
        public List<Marca> GetMarcas(long categoriaId, byte generoId, long MarcaId, long ColorId, double PrecioD, double PrecioH, string Descripcion, int TipoOrden)
        {
            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, PrecioD, PrecioH, Descripcion, TipoOrden);
=======
        public List<Marca> GetMarcas(long categoriaId, byte generoId, long MarcaId, long ColorId, long DeporteId, double PrecioD, double PrecioH, string Descripcion, int TipoOrden)
        {
            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, DeporteId, PrecioD, PrecioH, Descripcion, TipoOrden);
>>>>>>> carro
            var r = result                
                .GroupBy(x => x.MarcaId)
                .Select(y => new Marca
                {
                    MarcaId = y.Key,
                    Nombre = y.Min(x=>x.Marca.Nombre)                    
                })
                .ToList();

            return r;
        }
 
<<<<<<< HEAD
        public List<Color> GetColores(long categoriaId, byte generoId, long MarcaId, long ColorId, double PrecioD, double PrecioH, string Descripcion, int TipoOrden)
        {
            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, PrecioD, PrecioH, Descripcion, TipoOrden);
=======
        public List<Color> GetColores(long categoriaId, byte generoId, long MarcaId, long ColorId, long DeporteId, double PrecioD, double PrecioH, string Descripcion, int TipoOrden)
        {
            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, DeporteId, PrecioD, PrecioH, Descripcion, TipoOrden);
>>>>>>> carro
            var r = result                
                .GroupBy(x => x.ColorId)
                .Select(y => new Color
                {
                    ColorId = y.Key,
                    Nombre = y.Min(x => x.Color.Nombre)
                })
                .ToList();

            return r;
        }
<<<<<<< HEAD

>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
        public List<Deporte> GetDeportes(long categoriaId, byte generoId, long MarcaId, long ColorId, long DeporteId, double PrecioD, double PrecioH, string Descripcion, int TipoOrden)
        {
            var result = ArmarQry(categoriaId, generoId, MarcaId, ColorId, DeporteId, PrecioD, PrecioH, Descripcion, TipoOrden);
            var r = result
                .GroupBy(x => x.DeporteId)
                .Select(y => new Deporte
                {
                    DeporteId = y.Key,
                    Nombre = y.Min(x => x.Deporte.Nombre)
                })
                .ToList();

            return r;
        }

>>>>>>> carro
        public List<Producto> GetProductos(int Cant = 20)
        {
            return _context.Producto.Take(Cant).ToList();
        }

<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> carro
        public List<Marca> GetMarcas()
        {
            return _context.Marca.ToList();
        }

<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro
        public List<ProductoList> GetProductosList(int Cant = 20)
        {
            return _context.Producto
                .Include(x => x.Categoria)
                .Include(x => x.Marca)
<<<<<<< HEAD
<<<<<<< HEAD
=======
                .Include(x=>x.Genero)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
                .Include(x=>x.Genero)
>>>>>>> carro
                .Take(Cant)
                .Select(x=> ToProdList(x))
                .ToList();
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> carro
        public IEnumerable<ProductoList> GetProductosEnOferta(long OfertaId)
        {
            var res = _context
                .OfertaProducto
                .Where(x => x.Oferta.OfertaId == OfertaId)
                .Include(x => x.Oferta)
                .Include(x => x.Producto)
                .Include(x => x.Producto.Color)
                .Include(x => x.Producto.Categoria)
                .Include(x => x.Producto.Marca)
                .Include(x => x.Producto.Genero)
                .Include(x => x.Producto.Imagenes)                
                .ToList();

            var pr = res.Select(x => ToProdList(x.Producto));

            return pr;
        }
        public ProductoList GetProductoList(long ProductoId)
        {
            return _context.Producto
                .Where(x=>x.ProductoId == ProductoId)
                .Include(x => x.Categoria)
                .Include(x => x.Marca)
                .Include(x => x.Genero)                
                .Include(x=>x.Imagenes)
                .Select(x => ToProdList(x))
                .FirstOrDefault();
        }
<<<<<<< HEAD
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
>>>>>>> carro
        public static ProductoList ToProdList(Producto producto)
        {
            var res = new ProductoList();
            res.ProductoId = producto.ProductoId;
            res.Categoria = producto.Categoria.Nombre;
            res.Marca = producto.Marca.Nombre;
            res.GeneroId = producto.GeneroId;
            res.Nombre = producto.Nombre;
            res.Precio = producto.Precio;
            res.PrecioStr =  producto.Precio.ToString("C2", CultureInfo.CurrentCulture);
            res.PrecioLista = producto.PrecioLista;
<<<<<<< HEAD
<<<<<<< HEAD

            return res;
            /*
            return new ProductoList()
            {
                ProductoId = producto.ProductoId,
                Categoria = producto.Categoria.Nombre,
                Marca = producto.Marca.Nombre,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                PrecioStr = producto.Precio.ToString("C0", CultureInfo.CurrentCulture),
                PrecioLista = producto.PrecioLista
            };*/
            
=======
            res.Descripcion = producto.Descripcion;
            res.Detalle = producto.Detalle;
            res.Genero = producto.Genero.Nombre;
            res.DescuentoPorc = producto.DescuentoPorc;           
            res.EnvioGratis = producto.Precio >= Monto_Envio_Gratis;
            if(producto.Imagenes != null)
                res.Imagenes = producto.Imagenes.Select(
                    x => new ProdImagenList
                    {
                        ImageMimeType = x.ImageMimeType,
                        Nombre = x.Nombre,
                        ProdImagenId = x.ProdImagenId,
                        ProductoId = x.ProductoId
                    }
                    );
            
            return res;            
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
            res.Descripcion = producto.Descripcion;
            res.Detalle = producto.Detalle;
            res.Genero = producto.Genero.Nombre;
            res.DescuentoPorc = producto.DescuentoPorc;           
            res.EnvioGratis = producto.Precio >= Monto_Envio_Gratis;
            if(producto.Imagenes != null)
                res.Imagenes = producto.Imagenes.Select(
                    x => new ProdImagenList
                    {
                        ImageMimeType = x.ImageMimeType,
                        Nombre = x.Nombre,
                        ProdImagenId = x.ProdImagenId,
                        ProductoId = x.ProductoId
                    }
                    );
            
            return res;            
>>>>>>> carro
        }
        //------------        

        public void GetImage(int id)
        {
            /*
             * string ImageMimeType = "image/jpeg";
            var requested = productos.FirstOrDefault(b => b.ProductoId == id);

            if (requested != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requested.Imagenes.FirstOrDefault();
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, ImageMimeType);
                }
                else
                {                    
                     return NotFound();                    
                }
            }
            else
            {
                return NotFound();
            }*/
            
        }
    }
}
