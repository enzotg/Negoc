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

        public ProductoServicio(NegocioContext Context)
        {
            _context = Context;
        }

        public void Agregar(Producto producto, Microsoft.AspNetCore.Http.IFormFileCollection files, string WebRootPath)
        {
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
                    var fileName = Path.Combine(folder,
                        Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName));

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
                p.GeneroId = producto.GeneroId;
                p.MarcaId = producto.MarcaId;
                p.Nombre = producto.Nombre;
                p.Precio = producto.Precio;
                p.PrecioLista = producto.PrecioLista;
                p.PrecioStr = producto.PrecioStr;
                p.TalleId = producto.TalleId;
                _context.SaveChanges();
            }
        }

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
        /*public async Task<List<Categoria>> GetCategoriasAsync(long CategoriaId, long NivelId)
        {
            ArbolCategoria arbol = new ArbolCategoria(_context.Categoria.ToList());
            var res =  arbol.GetTodosChilds(CategoriaId).Where(x => x.NivelId <= NivelId).ToList();
            return   await res.ToAsyncEnumerable() ;
        }*/
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
                .Where(x => x.CategoriaId == CategoriaId));

            foreach (var c in arbol.GetTodosChilds(CategoriaId))
                res.AddRange(_context.Producto
                    .Include(x => x.Categoria)
                    .Include(x => x.Marca)
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
                .Where(x => x.CategoriaId == CategoriaId && x.GeneroId == GeneroId));

            foreach (var c in arbol.GetTodosChilds(CategoriaId))
                res.AddRange(_context.Producto
                    .Include(x => x.Categoria)
                    .Include(x => x.Marca)
                    .Where(x => x.CategoriaId == c.CategoriaId));

            return res
                .Select(x => ToProdList(x))
                .ToList();
        }
        public List<ProductoList> GetProductos(long categoriaId, byte generoId, int pageNumber, int pageSize, int TipoOrden)
        {
            var entidad = _context.Producto;
            var item = Expression.Parameter(typeof(Producto), "item");

            Expression exprWhere=null;
            if (categoriaId != 0)
            {
                exprWhere = Expression.Equal(Expression.Property(item, "CategoriaId"), Expression.Constant(categoriaId));                
                
                foreach(var cat in this.GetCategorias(categoriaId))
                {
                    exprWhere = Expression.Or(exprWhere,
                        Expression.Equal(Expression.Property(item, "CategoriaId"), Expression.Constant(Convert.ToInt64(cat.CategoriaId))));
                }
            }
            if (generoId != 0)
            {
                if(exprWhere==null)
                    exprWhere = Expression.Equal(Expression.Property(item, "GeneroId"), Expression.Constant(generoId));
                else
                    exprWhere = Expression.And(exprWhere,
                        Expression.Equal(Expression.Property(item, "GeneroId"), Expression.Constant(generoId)));
            }

            /*Expression wh = Expression.AndAlso(
                Expression.Equal(Expression.Property(item, "CategoriaId"), Expression.Constant(categoriaId)),
                Expression.Equal(Expression.Property(item, "GeneroId"), Expression.Constant(generoId)));
                */            

            var param = Expression.Parameter(typeof(Producto), "producto");
            
            var lambda = Expression.Lambda<Func<Producto, bool>>(exprWhere, item);

            var result = entidad
                    .Include(x => x.Categoria)
                    .Include(x => x.Marca)                    
                    .Where(lambda);

            if (TipoOrden == 1 )
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
            if (pageNumber==0 || pageSize==0)
                return new List<ProductoList>();


            result = result
                .Skip((pageNumber-1) * pageSize)
                .Take(pageSize);

            var res = result
                 .Select(x => ToProdList(x))                 
                .ToList();
            if (res == null)
                return new List<ProductoList>();
            else
                return res;
        }

        public List<Producto> GetProductos(int Cant = 20)
        {
            return _context.Producto.Take(Cant).ToList();
        }

        public List<Marca> GetMarcas()
        {
            return _context.Marca.ToList();
        }

        public List<ProductoList> GetProductosList(int Cant = 20)
        {
            return _context.Producto
                .Include(x => x.Categoria)
                .Include(x => x.Marca)
                .Take(Cant)
                .Select(x=> ToProdList(x))
                .ToList();
        }
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
