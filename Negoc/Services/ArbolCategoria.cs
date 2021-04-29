using Negoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Services
{
    public class ArbolCategoria
    {

        List<Categoria> _categorias;
        List<Categoria> categoriasRes;

        public ArbolCategoria(List<Categoria> categorias)
        {
            _categorias = categorias;
            categoriasRes = new List<Categoria>();
        }
        public List<Categoria> GetTodosParents(long catId)
        {
            //Todos las categorias parents de una categoria
            GetParents(catId);
            return categoriasRes;
        }
        public List<Categoria> GetTodosChilds(long catId)
        {
            //Todos las categorias childs de una categoria
            GetChilds(catId);
            return categoriasRes;
        }
        private void GetParents(long catId)
        {
            var categ = _categorias.FirstOrDefault(x => x.CategoriaId == catId);

<<<<<<< HEAD
<<<<<<< HEAD
            if (!categ.ParentId.HasValue)
=======
            if (!categ.ParentId.HasValue || categ.ParentId==0)
>>>>>>> 732283587911371be4fc8312a3aa766a48e3ce57
=======
            if (!categ.ParentId.HasValue || categ.ParentId==0)
>>>>>>> carro
                return;
            else
            {
                var parent = _categorias.FirstOrDefault(x => x.CategoriaId == categ.ParentId);
                categoriasRes.Add(parent);                
                GetParents(parent.CategoriaId);
            }
        }
        private void GetChilds(long catId, int N = 1)
        {
            //Todas las categorias childs de una categoria
            var cats = _categorias
                .Where(x => x.ParentId.HasValue)
                .Where(x => x.ParentId == catId);

            foreach (var c in cats)
            {
                c.NivelId = N;
                categoriasRes.Add(c);
                GetChilds(c.CategoriaId, N + 1);
            }
        }

    }
}
