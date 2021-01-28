using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
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

                return View(servicioProd.GetProducto(producto.ProductoId));
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
    }
}