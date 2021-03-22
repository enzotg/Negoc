using Microsoft.AspNetCore.Mvc;
using Negoc.Data;
using Negoc.Models;
using Negoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.ViewComponents
{
    public class MenuBarViewComponent:ViewComponent
    {
        ProductoServicio servicioProd;
        public MenuBarViewComponent(NegocioContext negocioContext)
        {
            servicioProd = new ProductoServicio(negocioContext);
        }

        public async Task<IViewComponentResult> InvokeAsync(long CategoriaId, long NivelId)
        {
            var lista = servicioProd.GetCategorias(CategoriaId, NivelId);
            var res = await Task.Run(() => lista);

            return View(res);
        }


    }
}
