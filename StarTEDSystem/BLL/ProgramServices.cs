using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTEDSystem.DAL;
using StarTEDSystem.Entities;

namespace StarTEDSystem.BLL
{
    public class ProgramServices
    {
        private readonly StarTEDContext _context;

        internal ProgramServices(StarTEDContext registeredContext)
        {
            _context = registeredContext;
        }

        public List<Entities.Program> Program_GetList()
        {
            return _context.Programs.OrderBy(p => p.ProgramName).ToList();
        }
    }
}
