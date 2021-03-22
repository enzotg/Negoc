using Negoc.Data;
using Negoc.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Negoc.Services
{
    public class ColorServicio
    {
        NegocioContext _context;

        public ColorServicio(NegocioContext Context)
        {
            _context = Context;
        }

        public List<Color> GetTodos()
        {
            return _context.Color.ToList();

        }
    }
}
