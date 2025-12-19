using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarTEDSystem.DAL;
using StarTEDSystem.Entities;

namespace StarTEDSystem.BLL
{
    public class EmployeeServices
    {
        private readonly StarTEDContext _context;

        internal EmployeeServices(StarTEDContext registeredContext)
        {
            _context = registeredContext;
        }
        public Employee Employee_GetById(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentException("Employee ID must be greater than 0");
            Employee? employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (employee == null)
                throw new ArgumentException("Employee not found");
            return employee;
        }

        public List<Employee> Employee_GetByPartialName(string partialName, int pageNumber, int pageSize)
        {
            if (string.IsNullOrWhiteSpace(partialName))
                throw new ArgumentException("Enter part of a first or last name");
            if (pageNumber <= 0)
                throw new ArgumentException("Page number must be 1 or higher.");
            if (pageSize < 5 || pageSize > 25)
                throw new ArgumentException("Page size must be bw 5 and 25");
            partialName = partialName.Trim();
            IEnumerable<Employee> query = _context.Employees.Where(e => e.ReleaseDate == null &&(e.FirstName.Contains(partialName) || e.LastName.Contains(partialName))).OrderBy(e => e.LastName).ThenBy(e => e.FirstName);
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
        public int Employee_GetByPartialName_Count(string partialName)
        {
            if (string.IsNullOrWhiteSpace(partialName))
                return 0;
            partialName = partialName.Trim();
            return _context.Employees.Count(e => e.ReleaseDate == null &&(e.FirstName.Contains(partialName) || e.LastName.Contains(partialName)));
        }
    }
}
