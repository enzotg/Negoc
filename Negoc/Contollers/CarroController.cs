using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Negoc.Data;
using Negoc.Services;
using Negoc.ViewModels;

namespace Negoc.Contollers
{
    public class CarroController : Controller
    {
        CarroServicio servicioCarro;

        public CarroController(NegocioContext context)
        {
            servicioCarro = new CarroServicio(context);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ActualizarCarro([FromBody] IEnumerable<CarroItem> carro)
        {
            return Json(Newtonsoft.Json.JsonConvert.SerializeObject(servicioCarro.ActualizarCarro(carro)));
            //return Json("");

        }
    }
}