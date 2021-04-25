using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagementSystemAPI.Models;
using EmployeeManagementSystemAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public EmployeesController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployees(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees([FromBody] Employee employee)
        {
            var newEmployee = await _repository.Create(employee);
            return CreatedAtAction(nameof(GetEmployees), new {id = newEmployee.Id}, newEmployee);
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> PutEmployees(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _repository.Update(employee);
            
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployees(int id)
        {
            var employeeToDelete = _repository.Get(id);

            if (employeeToDelete == null)
            {
                return NotFound();
            }

            await _repository.Delete(employeeToDelete.Id);
            return NoContent();
        }
    }
}