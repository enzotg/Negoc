using Negoc.Data;
using Negoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Services
{
    public class GeneroServicio
    {
        NegocioContext _context;

        public GeneroServicio(NegocioContext Context)
        {
            _context = Context;
        }

        public List<Genero> GetTodos()
        {
            return _context.Genero.ToList();

        }
    }
}
