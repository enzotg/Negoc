using Negoc.Data;
using Negoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Services
{
    public class DeporteServicio
    {
        NegocioContext _context;

        public DeporteServicio(NegocioContext Context)
        {
            _context = Context;
        }

        public List<Deporte> GetTodos()
        {
            return _context.Deporte.ToList();

        }
    }
}
