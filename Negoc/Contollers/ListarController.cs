using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Negoc.Data;
using Negoc.Services;

namespace Negoc.Contollers
{
    public class ListarController : Controller
    {
        ProductoServicio servicioProd;
        IHostingEnvironment _environment;
                
        public ListarController(NegocioContext context, IHostingEnvironment environment)
        {
            _environment = environment;
            servicioProd = new ProductoServicio( context);
        }
        public IActionResult Index()
        {
            return View(servicioProd.GetProductos());
        }
        public IActionResult GetProductos(long CategoriaId, byte GeneroId, int PagNumero,int PagCantidad,int TipoOrden)
        {
            var res = servicioProd.GetProductos(CategoriaId, GeneroId, PagNumero, PagCantidad,TipoOrden);

            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(res));
        }

        public IActionResult GetProductosCat(long CategoriaId)
        {
            var res = servicioProd.GetProductos(CategoriaId);            
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(res));
        }
        public IActionResult GetProductosCatGen(long CategoriaId, byte GeneroId)
        {
            var res = servicioProd.GetProductos(CategoriaId, GeneroId);
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(res));
        }
        public IActionResult GetCategorias(long CategoriaId, long NivelId)
        {
            var res = servicioProd.GetCategorias(CategoriaId , NivelId);
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(res));
        }
        


        //----------------
        public IActionResult GetImagePr(long id)
        {
            
            string ImageMimeType = "image/jpeg";
            var requested = servicioProd.GetProducto(id);                

            if (requested != null)
            {                
                string fullPath =  requested.Imagenes.FirstOrDefault().Nombre;
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
            }            
        }
        public IActionResult GetImage(long id)
        {
            var requested = servicioProd.GetProductoImg(id);

            if (requested != null)
            {                        
                string fullPath = requested.Nombre;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes,requested.ImageMimeType);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

    }
}