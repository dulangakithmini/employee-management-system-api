using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementSystemAPI.Models;

namespace EmployeeManagementSystemAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Get();

        Task<Employee> Get(int id);

        Task<Employee> Create(Employee employee);

        Task Update(Employee employee);

        Task Delete(int id);
    }
}