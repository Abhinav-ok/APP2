using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTEDSystem.DAL;
using StarTEDSystem.Entities;


namespace StarTEDSystem.BLL
{
    public class PositionServices
    {
        private readonly StarTEDContext _context;

        internal PositionServices(StarTEDContext registeredContext)
        {
            _context = registeredContext;
        }
        public List<Position> Position_GetList()
        {
            return _context.Positions.OrderBy(p => p.Description).ToList();
        }
    }
}
