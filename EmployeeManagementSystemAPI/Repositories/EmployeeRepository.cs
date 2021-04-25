using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystemAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _employeeContext.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await _employeeContext.Employees.FindAsync(id);
        }

        public async Task<Employee> Create(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            await _employeeContext.SaveChangesAsync();

            return employee;
        }

        public async Task Update(Employee employee)
        {
            _employeeContext.Entry(employee).State = EntityState.Modified;
            await _employeeContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employeeToDelete = await _employeeContext.Employees.FindAsync(id);
            _employeeContext.Employees.Remove(employeeToDelete);
            await _employeeContext.SaveChangesAsync();
        }
    }
}