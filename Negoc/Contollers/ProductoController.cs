using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Negoc.Data;
using Negoc.Models;
using Negoc.Services;

namespace Negoc.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly NegocioContext _context;
        ProductoServicio servicioProd;

        public ProductoController(IHostingEnvironment appEnvironment,NegocioContext context)
        {
            _appEnvironment = appEnvironment;
            _context = context;
            servicioProd = new ProductoServicio(_context);
        }
        public ActionResult List()
        {
            return View(servicioProd.GetProductos().ToList());
        }
        // GET: Producto
        public ActionResult Index()
        {
            return View(servicioProd.GetProductosList().ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            CargarLists();
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            CargarLists();
            try
            {                
                servicioProd.Agregar(producto, Request.Form.Files, _appEnvironment.WebRootPath);

                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult UploadImg()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadImg(long ProductoId)
        {
            if(ProductoId !=0 )
                servicioProd.AgregarImg(ProductoId, Request.Form.Files, _appEnvironment.WebRootPath);

            return View(servicioProd.GetProducto(ProductoId));
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            CargarLists();
            //servicioProd.GetCategorias(0).Select(x => new sele)
            return View(servicioProd.GetProducto(id));
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            try
            {
                // TODO: Add update logic here

                servicioProd.Modificar(producto);
                servicioProd.AgregarImg(producto.ProductoId, Request.Form.Files, _appEnvironment.WebRootPath);

                //return View(servicioProd.GetProducto(producto.ProductoId));
                return RedirectToAction("Index","Producto");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void CargarLists()
        {
            var lCat =
                servicioProd.GetCategorias(0)
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Nombre,
                        Value = x.CategoriaId.ToString()
                    }).ToList();

            ViewBag.cat = lCat;

            var lMar =
                (new MarcaServicio(_context).GetTodos())
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Nombre,
                        Value = x.MarcaId.ToString()
                    }).ToList();
            ViewBag.mar = lMar;

            var lGen =
                (new GeneroServicio(_context).GetTodos())
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Nombre,
                        Value = x.GeneroId.ToString()
                    }).ToList();
            ViewBag.gen = lGen;

            var lCol =
                (new ColorServicio(_context).GetTodos())
                    .Select(x => new SelectListItem()
                    {
                        Text = x.Nombre,
                        Value = x.ColorId.ToString()
                    }).ToList();
            ViewBag.col = lCol;

        }
    }
}