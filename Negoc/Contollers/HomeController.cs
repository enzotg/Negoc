using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Negoc.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Globalization;
 

namespace Negoc.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController(IHostingEnvironment environment)
        {        
            //GetParents(1);            
        }
        public IActionResult Index()
        {

            return View();
        }




    }
}