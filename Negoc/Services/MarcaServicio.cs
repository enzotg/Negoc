using Negoc.Data;
using Negoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Services
{
    public class MarcaServicio
    {
        NegocioContext _context;
        
        public MarcaServicio(NegocioContext Context)
        {
            _context = Context;
        }

        public List<Marca> GetTodos()
        {
            return _context.Marca.ToList();

        }
    }
}
